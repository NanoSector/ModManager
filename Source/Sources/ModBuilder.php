<?php

// ModBuilder by Yoshi2889 - Core file
function ModBuilderMain()
{
	global $context, $scripturl, $txt;
	
	// Load the language for the Mod Builder.
	loadLanguage('ModBuilder');
	
	// Our array of actions.
	$mbActions = array(
		'view' => 'ViewProjects',
		'create' => 'mbAdd',
		'edit' => 'mbEdit',
		'remove' => 'mbRemove',
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
		
	// Now run the function.
	$mbActions[$sa]();
}

// Viewing someones projects
function ViewProjects()
{
	global $context, $smcFunc, $txt, $user_profile, $scripturl;
	
	// Grab the current user ID.
	$u = $context['user']['id'];
	
	// Are we loading data for a different user?
	if (!empty($_GET['u']) && allowedTo('mb_view_projects_any'))
		$u = (int) $_GET['u'];
	elseif (!empty($_GET['u']))
		fatal_lang_error('mb_no_permission');
		
	// Before we start, attempt to load the author data.
	if ($u != $context['user']['id'])
	{
		$check = loadMemberData($u);
	
		// Empty? No valid user. Period.
		if (empty($check) || !in_array($u, $check))
			fatal_lang_error('mb_u_no_exists', false);
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
	
	// Can we delete projects?
	$context['mb']['can_delete_projects'] = allowedTo('mb_remove_projects_any') || ($u == $context['user']['id'] && allowedTo('mb_remove_projects_own'));
	
	// Or can we edit this project?
	$context['mb']['can_edit'] = allowedTo('mb_edit_projects_any') || ($u == $context['user']['id'] && allowedTo('mb_edit_projects_own'));
	
	// Can we create projects?
	$context['mb']['can_create'] = allowedTo('mb_add') && $u == $context['user']['id'];
	
	// Set the page title.
	$context['mb']['username'] = ($u == $context['user']['id'] ? $context['user']['name'] : $user_profile[$u]['member_name']);
	$context['page_title'] = sprintf($txt['mb_vp_title'], $context['mb']['username']);
	
	// Then load and set the template.
	loadTemplate('ModBuilder/ProjectIndex');
	$context['sub_template'] = 'mbViewProjects';
	
	// And set the linktree.
	$context['linktree'][] = array(
		'name' => sprintf($txt['mb_vp_title'], $context['mb']['username']),
		'url' => $scripturl . '?action=mb;u=' . $u,
	);
}

// Edit a project.
function mbEdit()
{
	global $context, $smcFunc, $txt;
	
	// Check if the project ID is there.
	if (empty($_GET['project']))
		fatal_lang_error('mb_p_no_exists');
		
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
		fatal_lang_error('mb_p_no_exists');
		
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
			'readme' => 'EditModReadme',
			'instructions' => 'EditModInstructions',
		);
		
		// Current area defaults to details.
		$current_area = 'details';
		
		// Figure out the current area if it's not default.
		if (!empty($_GET['area']) && array_key_exists($_GET['area'], $areas))
			$current_area = $_GET['area'];
			
		// Start the function.
		$areas[$current_area]();
	}
	else
		fatal_lang_error('mb_no_permission');
}

function mbAdd()
{
	global $context, $scripturl, $txt, $smcFunc, $user_profile;
	
	// Load the Forms template.
	loadTemplate('ModBuilder/Forms');
	
	// Set up some config vars.
	$context['mb']['config_vars'] = array(
		array('text', 'name', 'mod_name', $txt['mb_mod_name'], '', 80),
		array('text', 'version', 'mod_version', $txt['mb_mod_version'], ''),
		array('select', 'type', 'mod_type', $txt['mb_mod_type'], '1', array('1' => $txt['mb_type_1'], '2' => $txt['mb_type_2'])),
		array('text', 'modid', 'mod_id', $txt['mb_mod_id'], 'Username:ModName', 32, 32),
		array('check', 'autogenmodid', 'mod_id_autogen', $txt['mb_mod_id_autogen'], true),
	);
	
	// Is there data to be saved?
	if (isset($_GET['save']))
	{
		// Try to sanitize every setting.
		$keys = array();
		$values = array();
		foreach ($context['mb']['config_vars'] as $key => $setting)
		{
			// Skip links.
			if ($setting[0] == 'link')
				continue;
			
			// If there is no $_POST variable for this, something is wrong.
			if (empty($_POST[$setting[2]]))
				fatal_lang_error('mb_err_saving_proj');
			
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
		
		// We still need to insert the author ID.
		$keys['authorid'] = 'int';
		$values[] = $context['user']['id'];
		
		echo var_dump($keys, $values);
		
		// And run a query.
		$smcFunc['db_insert']('insert',
			'{db_prefix}mb_projects',
			$keys,
			$values,
			array());
		
		// And exit.
		redirectexit('action=mb');
	}
	
	// Set up the post_url.
	$context['mb']['post_url'] = $scripturl . '?action=mb;sa=create;save';
	
	// Also insert a nice title.
	$context['mb']['settings_title'] = $txt['mb_mod_create_ptitle'];
		
	// Insert a linktree item.
	$context['linktree'][] = array(
		'name' => $txt['mb_mod_create_ptitle'],
		'url' => $scripturl . '?action=mb;sa=create',
	);
	
	// And set the sub template.
	$context['sub_template'] = 'mb_mod_settings';
	
	// And our page title.
	$context['page_title'] = $txt['mb_mod_create_ptitle'];
}

function EditModDetails()
{
	global $context, $scripturl, $txt, $smcFunc, $user_profile;
	
	// Load the Forms template.
	loadTemplate('ModBuilder/Forms');
	
	// Set up some config vars.
	$context['mb']['config_vars'] = array(
		array('text', 'name', 'mod_name', $txt['mb_mod_name'], $context['mb']['project']['name'], 80),
		array('text', 'version', 'mod_version', $txt['mb_mod_version'], $context['mb']['project']['version']),
		array('select', 'type', 'mod_type', $txt['mb_mod_type'], $context['mb']['project']['type'], array('1' => $txt['mb_type_1'], '2' => $txt['mb_type_2'])),
		array('text', 'modid', 'mod_id', $txt['mb_mod_id'], $context['mb']['project']['modid'], 32, 32),
		array('check', 'autogenmodid', 'mod_id_autogen', $txt['mb_mod_id_autogen'], $context['mb']['project']['autogenmodid']),
		array('link', $scripturl . '?action=mb;sa=edit;area=transfer;project=' . $context['mb']['project']['id'], $txt['mb_mod_transfer_ownership']),
	);
	
	// Some hidden config vars.
	$context['mb']['hidden_config_vars'] = array(
		array('mod_pid', $context['mb']['project']['id'])
	);
	
	// Is there data to be saved?
	if (isset($_GET['save']))
	{
		// Compare the version in the URL with the POSTed version.
		if (empty($_GET['project']) || $_GET['project'] != $_POST['mod_pid'])
			fatal_lang_error('mb_err_saving_proj');
			
		// Try to sanitize every setting.
		$query = '';
		$queryParams = array();
		$settingsCount = 0;
		foreach ($context['mb']['config_vars'] as $key => $setting)
		{
			// Skip links.
			if ($setting[0] == 'link')
				continue;
			
			// If there is no $_POST variable for this, something is wrong.
			if (empty($_POST[$setting[2]]))
				fatal_lang_error('mb_err_saving_proj');
				
			// Count one up to the settings count.
			$settingsCount++;
			
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
		
		// Remove the trailing comma from $query.
		$query = substr($query, 0, -2);
		
		echo var_dump($query, $queryParams);
		
		// And run a query.
		$smcFunc['db_query']('', '
			UPDATE {db_prefix}mb_projects
			SET ' . $query . '
			WHERE id = {int:pid}',
			array_merge($queryParams, array(
				'pid' => $context['mb']['project']['id']
			)));
		
		// And exit.
		redirectexit('action=mb;sa=edit;project=' . $context['mb']['project']['id'] . ';saved');
	}
	
	// Set up the post_url.
	$context['mb']['post_url'] = $scripturl . '?action=mb;sa=edit;project=' . $context['mb']['project']['id'] . ';save';
	
	// Also insert a nice title.
	$context['mb']['settings_title'] = sprintf($txt['mb_editing'], $context['mb']['project']['name']);
	
	// If we were viewing someone else's project, add a linktree item
	if ($context['mb']['project']['authorid'] != $context['user']['id'])
		$context['linktree'][] = array(
			'name' => sprintf($txt['mb_vp_linktree'], $user_profile[$context['mb']['project']['authorid']]['member_name']),
			'url' => $scripturl . '?action=mb;u=' . $context['mb']['project']['authorid'],
		);
		
	// Insert a linktree item.
	$context['linktree'][] = array(
		'name' => $context['mb']['settings_title'],
		'url' => $scripturl . '?action=mb;sa=edit;project=' . $context['mb']['project']['id'],
	);
	
	// And set the sub template.
	$context['sub_template'] = 'mb_mod_settings';
	
	// And our page title.
	$context['page_title'] = $context['mb']['settings_title'];
}

function EditModReadme()
{
	global $context, $sourcedir, $smcFunc, $txt, $scripturl, $user_profile;
	
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
			fatal_lang_error('mb_err_saving_proj');
			
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
	
	// Undo the preparsecode on the text.
	un_preparsecode($readmeText);
	
	// Some settings for the upcoming editor.
	$editorOptions = array(
		'id' => 'mod_readme',
		'value' => $smcFunc['htmlspecialchars']($readmeText, ENT_QUOTES),
		'height' => '175px',
		'width' => '100%',
		// XML preview.
		'preview_type' => 2,
	);
	create_control_richedit($editorOptions);
	
	$context['post_box_name'] = $editorOptions['id'];
	
	// Set up the page title.
	if ($createReadme)
		$context['mb']['page_title'] = $context['page_title'] = sprintf($txt['mb_create_readme'], $context['mb']['project']['name']);
	else
		$context['mb']['page_title'] = $context['page_title'] = sprintf($txt['mb_edit_readme'], $context['mb']['project']['name']);
		
	// If we were viewing someone else's project, add a linktree item
	if ($context['mb']['project']['authorid'] != $context['user']['id'])
		$context['linktree'][] = array(
			'name' => sprintf($txt['mb_vp_linktree'], $user_profile[$context['mb']['project']['authorid']]['member_name']),
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
}

function mbRemove()
{
	global $context, $smcFunc;
	
	// Get the project.
	$pid = (int) $_GET['project'];
	
	// Do we have a project ID?
	if (empty($pid))
		fatal_lang_error('mb_p_no_exists');
		
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
		fatal_lang_error('mb_p_no_exists');
		
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
		
		// Exit back to the project index.
		$ext = '';
		if ($project['authorid'] != $context['user']['id'])
			$ext = ';u=' . $project['authorid'];
		redirectexit('action=mb' . $ext);
	}
}
