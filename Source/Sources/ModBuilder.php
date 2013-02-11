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
		'create' => 'Add',
		'edit' => 'Edit',
		'edit2' => 'Edit2',
		'delete' => 'Remove',
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
		
	// Verify the user ID once more.
	if (empty($u))
		$u = $context['user']['id'];
		
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
