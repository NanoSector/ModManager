<?php

// ModBuilder by Yoshi2889 - Core file
function ModBuilderMain()
{
	global $context, $scripturl, $txt;
	
	// Load the language for the Mod Builder.
	loadLanguage('ModBuilder');
	
	// Are we running AJAX?
	$context['mb']['is_ajax'] = isset($_GET['mb_ajax']);
	
	// Our array of actions.
	$mbActions = array(
		'create' => 'mbAdd',
		'edit' => 'mbEdit',
		'remove' => 'mbRemove',
		'view' => 'ViewProjects',
	);
	
	// Our default action.
	$sa = 'view';
	
	// Try to figure out any other action we may have.
	if (!empty($_GET['sa']) && array_key_exists($_GET['sa'], $mbActions))
		$sa = $_GET['sa'];
		
	// Build up a bit of the linktree.
	$context['linktree'][] = array(
		'name' => $txt['modbuilder'],
		'url' => $scripturl . '?action=mb',
	);
	
	// Insert our stylesheet.
	loadTemplate(false, 'mb');
	
	// Insert jQuery.
	$context['html_headers'] .= '
	<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.9.1/jquery.min.js"></script>';
		
	// Now run the function.
	call_user_func($mbActions[$sa]);
}

// Because we can.
function mb_throw_error($txtstring, $log = true)
{
	global $context, $txt;
	
	// Create a temporary string because we have our strings in $txt['mb'].
	$txt[$txtstring] = $txt['mb'][str_replace('mb_', '', $txtstring)];
	
	// Are we running in AJAX mode? Pass through to mb_throw_error.
	if (!$context['mb']['is_ajax'])
		fatal_lang_error($txtstring, $log);
	
	// Else we should send some JSON along.
	else
	{
		echo json_encode(array('error' => $txt[$txtstring]));
		exit;
	}
}

// Viewing someones projects
function ViewProjects()
{
	global $context, $smcFunc, $txt, $user_profile, $scripturl, $settings;
	
	// Grab the current user ID.
	$u = $context['user']['id'];
	
	// Are we loading data for a different user?
	if (!empty($_GET['u']) && allowedTo('mb_view_projects_any'))
		$u = (int) $_GET['u'];
	elseif (!empty($_GET['u']))
		mb_throw_error('mb_no_permission');
		
	// Before we start, attempt to load the author data.
	if ($u != $context['user']['id'])
	{
		$check = loadMemberData($u);
	
		// Empty? No valid user. Period.
		if (empty($check) || !in_array($u, $check))
			mb_throw_error('mb_u_no_exists', false);
	}
		
	// Set up the query.
	$result = $smcFunc['db_query']('', '
		SELECT id, name, version, type, modid, autogenmodid
		FROM {db_prefix}mb_projects
		WHERE authorid = {int:uid}',
		array(
			'uid' => $u
		));
		
	// Start empty.
	$context['mb']['projects'] = array();
	
	// Load up the projects.
	while ($tproject = $smcFunc['db_fetch_assoc']($result))
	{
		// Add it up
		$context['mb']['projects'][] = $tproject;
	}
	
	// Free the result.
	$smcFunc['db_free_result']($result);
	
	// If we have just transferred a project, we want to be able to jump to that person. Assemble the link if the user exists.
	if (!empty($_GET['transferred']))
	{
		// Sanitize the variable.
		$to = (int) $_GET['transferred'];
		
		// We aren't loading the data for ourselves are we...?
		if ($to != $u)
		{
			// Try to load the member data.
			$status = loadMemberData($to);
		
			// It's a member... Assemble the link.
			if (!empty($status))// Assemble the link...
				$context['mb']['user_link'] = '<a href="' . $scripturl . '?action=mb;u=' . $to . '">' . $user_profile[$to]['real_name'] . '</a>';
		
			// Not a member? Unset the $_GET variable.
			else
				unset($_GET['transferred']);
		}
	}
	
	// Can we delete projects?
	$context['mb']['can_delete_projects'] = allowedTo('mb_remove_projects_any') || ($u == $context['user']['id'] && allowedTo('mb_remove_projects_own'));
	
	// Or can we edit this project?
	$context['mb']['can_edit'] = allowedTo('mb_edit_projects_any') || ($u == $context['user']['id'] && allowedTo('mb_edit_projects_own'));
	
	// Can we create projects?
	$context['mb']['can_create'] = allowedTo('mb_add') && $u == $context['user']['id'];
	
	// Set the page title.
	$context['mb']['username'] = ($u == $context['user']['id'] ? $context['user']['name'] : $user_profile[$u]['member_name']);
	$context['mb']['current_user'] = $u;
	$context['page_title'] = sprintf($txt['mb']['vp_title'], $context['mb']['username']);
	
	// Then load and set the template.
	loadTemplate('ModBuilder/ProjectIndex');
	$context['sub_template'] = 'mbViewProjects';
	
	// And set the linktree.
	$context['linktree'][] = array(
		'name' => sprintf($txt['mb']['vp_title'], $context['mb']['username']),
		'url' => $scripturl . '?action=mb;u=' . $u,
	);
	
	// Insert some jQuery.
	$context['html_headers'] .= '
	<script type="text/javascript">
		//<![CDATA[
		function removeProject(pid)
		{
			var agr = confirm(' . javascriptescape($txt['mb']['really_delete_project']) . ');
			
			if (agr)
			{
				$.ajax(smf_scripturl + \'?action=mb;sa=remove;project=\' + pid + \';mb_ajax\',
				{
					dataType: "json",
					success: function (response)
					{
						if (typeof response.error != \'undefined\')
							alert(response.error);
						else
							$(\'div#proj_\' + pid).hide(\'slow\');
					}
				});
			}
		}
		//]]>
	</script>';
}

// Edit a project.
function mbEdit()
{
	global $context, $smcFunc, $txt;
	
	// Check if the project ID is there.
	if (empty($_GET['project']))
		mb_throw_error('mb_p_no_exists');
		
	// It is.
	$pid = (int) $_GET['project'];
	
	// Set up the query.
	$result = $smcFunc['db_query']('', '
		SELECT id, name, version, type, modid, autogenmodid, authorid
		FROM {db_prefix}mb_projects
		WHERE id = {int:pid}
		LIMIT 1',
		array(
			'pid' => $pid
		));
		
	// No row? No project.
	if ($smcFunc['db_num_rows']($result) == 0)
		mb_throw_error('mb_p_no_exists');
		
	// Grab the data.
	$context['mb']['project'] = $smcFunc['db_fetch_assoc']($result);
	
	// Free the result
	$smcFunc['db_free_result']($result);
	
	// Well then, check if we have access.
	if (allowedTo('mb_edit_projects_any') || ($context['mb']['project']['authorid'] == $context['user']['id'] && allowedTo('mb_edit_projects_own')))
	{
		// Okay, grab a list of all areas we are allowed to access.
		$areas = array(
			'details' => 'EditModDetails',
			'instructions' => 'EditModInstructions',
			'readme' => 'EditModReadme',
			'transfer' => 'TransferModOwnership',
		);
		
		// Current area defaults to details.
		$current_area = 'details';
		
		// Figure out the current area if it's not default.
		if (!empty($_GET['area']) && array_key_exists($_GET['area'], $areas))
			$current_area = $_GET['area'];
			
		// Start the function.
		call_user_func($areas[$current_area]);
	}
	else
		mb_throw_error('mb_no_permission');
}

function mbAdd()
{
	global $context, $scripturl, $txt, $smcFunc, $user_profile, $settings;
	
	// Load the Forms template.
	loadTemplate('ModBuilder/Forms');
	
	// Set up some config vars.
	$context['mb']['config_vars'] = array(
		array('text', 'name', 'mod_name'),
		array('text', 'version', 'mod_version'),
		array('select', 'type', 'mod_type'),
		array('text', 'modid', 'mod_id'),
		array('check', 'autogenmodid', 'mod_id_autogen'),
	);
	
	// Is there data to be saved?
	if (isset($_GET['save']))
	{
		// Try to sanitize every setting.
		$keys = array();
		$values = array();
		$context['mb']['errors'] = array();
		//die(var_dump($_POST['mod_id_autogen'], $_POST['mod_id']));
		foreach ($context['mb']['config_vars'] as $key => $setting)
		{
			// Skip links.
			if ($setting[0] == 'link')
				continue;
			
			// If there is no $_POST variable for this, something is wrong.
			if (empty($_POST[$setting[2]]) && $setting[0] != 'check')
				$context['mb']['errors'][] = 'empty_' . $setting[2];
			
			// Get the type.
			switch ($setting[0])
			{
				case 'check':
					$keys[$setting[1]] = 'int';
					$values[] = (int) !empty($_POST[$setting[2]]);
					break;
				default:
					$keys[$setting[1]] = 'string';
					$values[] = $smcFunc['htmlspecialchars']($_POST[$setting[2]]);
					break;
			}
		}
		
		// No errors? Good.
		if (empty($context['mb']['errors']))
		{
			// We still need to insert the author ID.
			$keys['authorid'] = 'int';
			$values[] = $context['user']['id'];
		
			// And run a query.
			$smcFunc['db_insert']('insert',
				'{db_prefix}mb_projects',
				$keys,
				$values,
				array());
				
			// Grab the ID.
			$id = $smcFunc['db_insert_id']('{db_prefix}mb_projects', 'id');
			$url = $scripturl . '?action=mb;sa=edit;project=' . $id . ';saved';
		
			// And exit.
			if ($context['mb']['is_ajax'])
			{
				echo json_encode(array('success' => $url));
				exit;
			}
			else
				redirectexit($url);
		}
		
		// We do... Try to find any valid fields.
		else
		{
			// Though not if we're in AJAX mode.
			if ($context['mb']['is_ajax'])
			{
				$errortexts = array();
				foreach ($context['mb']['errors'] as $error)
				{
					$errortexts[$error] = $txt['mb']['ferrors'][$error];
				}
				echo json_encode(array('error' => $errortexts));
				exit;
			}
			
			$context['mb']['project'] = array(
				'name' => $smcFunc['htmlspecialchars']($_POST['mod_name']),
				'version' => $smcFunc['htmlspecialchars']($_POST['mod_version']),
				'type' => (int) $_POST['mod_type'],
				'modid' => $smcFunc['htmlspecialchars']($_POST['mod_id']),
				'autogenmodid' => !empty($_POST['mod_id_autogen'])
			);
			
			// Tell the form template to mark any empty fields as error-ish.
			$context['mb']['mark_errors'] = true;
		}
	}
	else
	{
		$context['mb']['project'] = array(
			'name' => '',
			'version' => '',
			'type' => 1,
			'modid' => 'Username:ModName',
			'autogenmodid' => true
		);
	}
	
	// We can't transfer projects which have yet to be created.
	$context['mb']['can_transfer'] = false;
	
	// Set up the post_url.
	$context['mb']['post_url'] = $scripturl . '?action=mb;sa=create;save';
	
	// Also insert a nice title.
	$context['mb']['settings_title'] = $txt['mb']['mod_create_ptitle'];
		
	// Insert a linktree item.
	$context['linktree'][] = array(
		'name' => $txt['mb']['mod_create_ptitle'],
		'url' => $scripturl . '?action=mb;sa=create',
	);
	
	// And set the sub template.
	$context['sub_template'] = 'mb_project_settings';
	
	// And our page title.
	$context['page_title'] = $txt['mb']['mod_create_ptitle'];
	
	// And the JS bits.
	$context['html_headers'] .= '
	<script type="text/javascript">
		//<![CDATA[
		
		var smf_user_name = ' . javascriptescape($context['user']['name']) . ';
		var mbtexts = ' . json_encode($txt['mb']['ferrors']) . ';
		var mbmethod = \'create\';
		
		// Since this is a new project, check the autogenid thing and hide the mod ID textbox.
		$(\'input#mod_autogenid\').prop(\'checked\', true);
		$(\'input#mod_modid\').prop(\'disabled\', true);
		$(\'div#mod_modid_container\').hide();
		
		//]]>
	</script>
	<script type="text/javascript" src="' . $settings['default_theme_url'] . '/scripts/mb/editor.js"></script>';
}

function EditModDetails()
{
	global $context, $scripturl, $txt, $smcFunc, $user_profile, $settings;
	
	// Load the Forms template.
	loadTemplate('ModBuilder/Forms');
	
	// Set up some config vars.
	$context['mb']['config_vars'] = array(
		array('text', 'name', 'mod_name'),
		array('text', 'version', 'mod_version'),
		array('select', 'type', 'mod_type'),
		array('text', 'modid', 'mod_id'),
		array('check', 'autogenmodid', 'mod_id_autogen'),
	);
	
	if (allowedTo('mb_transfer_projects_any') || ($context['mb']['project']['authorid'] == $context['user']['id'] && allowedTo('mb_transfer_projects_own')))
		$context['mb']['config_vars'][] = array('link', $scripturl . '?action=mb;sa=edit;area=transfer;project=' . $context['mb']['project']['id'], $txt['mb']['mod_transfer_ownership']);
	
	// Some hidden config vars.
	$context['mb']['hidden_config_vars'] = array(
		array('mod_pid', $context['mb']['project']['id'])
	);
	
	// Is there data to be saved?
	if (isset($_GET['save']))
	{
		// Compare the version in the URL with the POSTed version.
		if (empty($_GET['project']) || empty($_POST['mod_pid']) || $_GET['project'] != $_POST['mod_pid'])
			mb_throw_error('mb_err_saving_proj');
			
		// Try to sanitize every setting.
		$query = '';
		$queryParams = array();
		$context['mb']['errors'] = array();
		foreach ($context['mb']['config_vars'] as $key => $setting)
		{
			// Skip links.
			if ($setting[0] == 'link')
				continue;
			
			// If there is no $_POST variable for this, something is wrong.
			if (empty($_POST[$setting[2]]) && $setting[0] != 'check')
				$context['mb']['errors'][] = 'empty_' . $setting[2];
			else
			{
				// Get the type.
				switch ($setting[0])
				{
					case 'check':
						$query .= $setting[1] . ' = {int:' . $setting[1] . '}';
						$queryParams[$setting[1]] = (int) !empty($_POST[$setting[2]]);
						break;
					default:
						$query .= $setting[1] . ' = {string:' . $setting[1] . '}';
						$queryParams[$setting[1]] = $smcFunc['htmlspecialchars']($_POST[$setting[2]]);
						break;
				}
			
				$query .= ', ';
			}
		}
		
		// No errors? Good.
		if (empty($context['mb']['errors']))
		{
			// Remove the trailing comma from $query.
			$query = substr($query, 0, -2);
			
			// And run a query.
			$smcFunc['db_query']('', '
				UPDATE {db_prefix}mb_projects
				SET ' . $query . '
				WHERE id = {int:pid}',
				array_merge($queryParams, array(
					'pid' => $context['mb']['project']['id']
				)));
		
			// And exit.
			if (!$context['mb']['is_ajax'])
				redirectexit('action=mb;sa=edit;project=' . $context['mb']['project']['id'] . ';saved');
			else
			{
				echo json_encode(array('success' => true));
				exit;
			}
		}
		else
		{
			if ($context['mb']['is_ajax'])
			{
				$errortexts = array();
				foreach ($context['mb']['errors'] as $error)
				{
					$errortexts[$error] = $txt['mb']['ferrors'][$error];
				}
				echo json_encode(array('error' => $errortexts));
				exit;
			}
			
			// Try to save some data.
			$context['mb']['project'] = array_merge(
				$context['mb']['project'],
				array(
					'name' => $smcFunc['htmlspecialchars']($_POST['mod_name']),
					'version' => $smcFunc['htmlspecialchars']($_POST['mod_version']),
					'type' => (int) $_POST['mod_type'],
					'modid' => $smcFunc['htmlspecialchars']($_POST['mod_id']),
					'autogenmodid' => !empty($_POST['mod_id_autogen'])
				)
			);
			
			// Tell the form template to mark any empty fields as error-ish.
			$context['mb']['mark_errors'] = true;
		}
	}
	
	// Can we transfer this project?
	$context['mb']['can_transfer'] = allowedTo('mb_transfer_projects_any') || (allowedTo('mb_transfer_projects_own') && $context['user']['id'] == $context['mb']['project']['authorid']);
	
	// Set up the post_url.
	$context['mb']['post_url'] = $scripturl . '?action=mb;sa=edit;project=' . $context['mb']['project']['id'] . ';save';
	
	// Also insert a nice title.
	$context['mb']['settings_title'] = sprintf($txt['mb']['editing'], $context['mb']['project']['name']);
	
	// If we were viewing someone else's project, add a linktree item
	if ($context['mb']['project']['authorid'] != $context['user']['id'])
		$context['linktree'][] = array(
			'name' => sprintf($txt['mb']['vp_linktree'], $user_profile[$context['mb']['project']['authorid']]['member_name']),
			'url' => $scripturl . '?action=mb;u=' . $context['mb']['project']['authorid'],
		);
		
	// Insert a linktree item.
	$context['linktree'][] = array(
		'name' => $context['mb']['settings_title'],
		'url' => $scripturl . '?action=mb;sa=edit;project=' . $context['mb']['project']['id'],
	);
	
	// And set the sub template.
	$context['sub_template'] = 'mb_project_settings';
	
	// And our page title.
	$context['page_title'] = $context['mb']['settings_title'];
	
	// Then insert the JS/jQuery bits.
	$context['html_headers'] .= '
	<script type="text/javascript">
		//<![CDATA[
		
			var smf_user_name = ' . javascriptescape($context['user']['name']) . ';
			var mbtexts = ' . json_encode($txt['mb']['ferrors']) . ';
			var mbpid = ' . javascriptescape($context['mb']['project']['id']) . ';
			var mbmethod = \'edit\';';
	
	if (!empty($context['mb']['project']['autogenmodid']))
		$context['html_headers'] .= '
		$(document).ready(function ()
		{
			$(\'input#mod_autogenid\').prop(\'checked\', true);
			$(\'div#mod_modid_container\').hide();
		});';
		
	if (isset($_GET['saved']))
		$context['html_headers'] .= '
		var is_saved = true;';
		
	$context['html_headers'] .= '
		//]]>
	</script>
	<script type="text/javascript" src="' . $settings['default_theme_url'] . '/scripts/mb/editor.js"></script>';
}

function EditModReadme()
{
	global $context, $sourcedir, $smcFunc, $txt, $scripturl, $user_profile, $settings;
	
	// Try to load the readme for this mod.
	$request = $smcFunc['db_query']('', '
		SELECT text
		FROM {db_prefix}mb_readmes
		WHERE pid = {int:pid}',
		array(
			'pid' => $context['mb']['project']['id'],
		));
		
	// No rows? We have no readme yet.
	$createReadme = false;
	if ($smcFunc['db_num_rows']($request) == 0)
		$createReadme = true;
		
	// Fetch it.
	list ($readmeText) = $smcFunc['db_fetch_row']($request);
	
	// Load up some requirements.
	require_once($sourcedir . '/Subs-Editor.php');
	include($sourcedir . '/Subs-Post.php');
	
	// Are we saving?
	if (isset($_GET['save']))
	{
		// Check if the GET project ID is the same as the POST one.
		if ($_GET['project'] != $_POST['mod_pid'])
			mb_throw_error('mb_err_saving_proj');
			
		// Are we previewing?
		$context['mb']['previewing'] = !empty($_POST['preview']);
		
		// Only save the readme if we are not previewing.
		if (!$context['mb']['previewing'])
		{
			// Sanitize the readme.
			preparsecode($smcFunc['htmlspecialchars']($_POST['mod_readme']));
		
			// We're good to go, determine the query type.
			if ($createReadme)
			{
				// Insert a new row.
				$smcFunc['db_insert']('insert',
				'{db_prefix}mb_readmes',
				array(
					'pid' => 'int', 'text' => 'string'
				),
				array(
					$context['mb']['project']['id'], $_POST['mod_readme']
				),
				array());
			}
			else
			{
				$smcFunc['db_query']('', '
					UPDATE {db_prefix}mb_readmes
					SET text = {string:text}
					WHERE pid = {int:pid}',
					array(
						'text' => $_POST['mod_readme'],
						'pid' => $context['mb']['project']['id'],
					));
			}
		
			// And exit.
			redirectexit('action=mb;sa=edit;area=readme;project=' . $context['mb']['project']['id'] . ';saved');
		}
		
		// Otherwise prepare the submitted readme for preview.
		else
		{
			
			echo var_dump($_POST);
			// We shall insert back the POSTed readme.
			$readmeText = $_POST['mod_readme'];
			
			// And we shall also insert it to the preview handler.
			$context['mb']['preview_readme'] = parse_bbc($smcFunc['htmlspecialchars']($_POST['mod_readme'], ENT_QUOTES));
		}
	}
	
	// Undo the preparsecode on the text.
	un_preparsecode($readmeText);
	
	// Some settings for the upcoming editor.
	$editorOptions = array(
		'id' => 'mod_readme',
		'value' => $smcFunc['htmlspecialchars']($readmeText, ENT_QUOTES),
		'labels' => array(
			'post_button' => $txt['mb']['mod_submit']
		),
		'height' => '175px',
		'width' => '100%',
		// We will handle our own preview here.
		'preview_type' => 1,
	);
	create_control_richedit($editorOptions);
	
	$context['post_box_name'] = $editorOptions['id'];
	
	// Set up the page title.
	if ($createReadme)
		$context['mb']['page_title'] = $context['page_title'] = sprintf($txt['mb']['create_readme'], $context['mb']['project']['name']);
	else
		$context['mb']['page_title'] = $context['page_title'] = sprintf($txt['mb']['edit_readme'], $context['mb']['project']['name']);
		
	// If we were viewing someone else's project, add a linktree item
	if ($context['mb']['project']['authorid'] != $context['user']['id'])
		$context['linktree'][] = array(
			'name' => sprintf($txt['mb']['vp_linktree'], $user_profile[$context['mb']['project']['authorid']]['member_name']),
			'url' => $scripturl . '?action=mb;u=' . $context['mb']['project']['authorid'],
		);
	
	// Insert data into the linktree.
	$context['linktree'][] = array(
		'name' => $context['mb']['page_title'],
		'url' => $scripturl . '?action=mb;sa=edit;area=readme;project=' . $context['mb']['project']['id'],
	);
		
	// And the post URL.
	$context['mb']['post_url'] = $scripturl . '?action=mb;sa=edit;area=readme;project=' . $context['mb']['project']['id'] . ';save';
	
	// Then load and set the template.
	loadTemplate('ModBuilder/Forms');
	$context['sub_template'] = 'mb_mod_readme';
	
	$context['html_headers'] .= '
	<script type="text/javascript" src="' . $settings['theme_url'] . '/scripts/editor.js"></script>';
}

function mbRemove()
{
	global $context, $smcFunc;
	
	// Get the project.
	$pid = (int) $_GET['project'];
	
	// Do we have a project ID?
	if (empty($pid))
		mb_throw_error('mb_p_no_exists');
		
	// Grab the project.
	$result = $smcFunc['db_query']('', '
		SELECT id, name, version, type, modid, autogenmodid, authorid
		FROM {db_prefix}mb_projects
		WHERE id = {int:pid}
		LIMIT 1',
		array(
			'pid' => $pid
		));
		
	// No row? No project.
	if ($smcFunc['db_num_rows']($result) == 0)
		mb_throw_error('mb_p_no_exists');
		
	// Grab the data.
	$project = $smcFunc['db_fetch_assoc']($result);
	
	// Free the result
	$smcFunc['db_free_result']($result);
		
	// Check if we have permission to do this.
	if (allowedTo('mb_remove_projects_any') || ($project['authorid'] == $context['user']['id'] && allowedTo('mb_remove_projects_own')))
	{
		// We have permission, so remove the project first.
		$smcFunc['db_query']('', '
			DELETE FROM {db_prefix}mb_projects
			WHERE id = {int:pid}',
			array(
				'pid' => $project['id'],
			));
		
		// Delete the readme associated, if it exists.
		$smcFunc['db_query']('', '
			DELETE FROM {db_prefix}mb_readmes
			WHERE pid = {int:pid}',
			array(
				'pid' => $project['id'],
			));
			
		// !!! Remove the other data for this project.
		
		// Redirect if not AJAX.
		if (!$context['mb']['is_ajax'])
			redirectexit('action=mb;u=' . $project['authorid'] . ';deleted');
			
		// Else send some JSON.
		else
		{
			echo json_encode(array('success' => true));
			exit;
		}
	}
	else
		mb_throw_error('mb_no_permission');
}

function TransferModOwnership()
{
	global $context, $smcFunc, $user_profile, $txt;
	
	// Can we transfer the ownership of this project?
	if (allowedTo('mb_transfer_projects_any') || ($context['user']['id'] == $context['mb']['project']['authorid'] && allowedTo('mb_transfer_projects_own')))
	{
		if (isset($_GET['save']))
		{
			// Compare the two PIDs we've got.
			if (empty($_GET['project']) || empty($_POST['mod_pid']) || $_GET['project'] != $_POST['mod_pid'])
				mb_throw_error('mb_transfer_error_occured');
			
			// Try to grab the member.
			$result = $smcFunc['db_query']('', '
				SELECT id_member
				FROM {db_prefix}members
				WHERE real_name = {string:member_name}',
				array(
					'member_name' => $_POST['mod_transfer_to'],
				));
				
			// No rows? Damn.
			if ($smcFunc['db_num_rows']($result) == 0)
				mb_throw_error('mb_u_no_exists', false);
				
			// We do? Great. Grab the ID.
			$mem_id = $smcFunc['db_fetch_row']($result);
			$mem_id = (int) $mem_id[0];
			
			// Clean up after us.
			$smcFunc['db_free_result']($result);
			
			// ID empty? What's this about?
			if (empty($mem_id))
				mb_throw_error('mb_transfer_error_occured');
				
			// Looks like we are transferring the project to ourselves...
			if ($mem_id == $context['mb']['project']['authorid'])
				mb_throw_error('mb_transfer_project_is_yours', false);
				
			// Now we can transfer the actual project.
			$smcFunc['db_query']('', '
				UPDATE {db_prefix}mb_projects
				SET authorid = {int:newid}
				WHERE id = {int:pid}',
				array(
					'newid' => $mem_id,
					'pid' => $context['mb']['project']['id'],
				));
			
			// Now we can exit, to the project index of the person the project belonged to.
			redirectexit('action=mb;u=' . $context['mb']['project']['authorid'] . ';transferred=' . $mem_id);
		}
		
		$context['page_title'] = $txt['mb']['transfer_ownership'];
		loadTemplate('ModBuilder/Transfer');
		$context['sub_template'] = 'mb_transfer_ownership';
	}
	else
		mb_throw_error('mb_no_permission');
}

function EditModInstructions()
{
	global $context, $smcFunc, $txt;
	
	if (allowedTo('mb_edit_project_instructions_any') || (allowedTo('mb_edit_project_instructions_own') && $context['user']['id'] == $context['mb']['project']['authorid']))
	{
		// Load the instructions for this project.
		
		// Another layer of actions.
		
		// Load the template and set the sub template and title.
		$context['page_title'] = sprintf($txt['mb']['editing_instructions_project'], $context['mb']['project']['name']);
		loadTemplate('ModBuilder/Instructions');
		$context['sub_template'] = 'mb_show_instructions';
	}
	else
		mb_throw_error('mb_no_permission');
}
