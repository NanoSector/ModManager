<?php

// Mod Builder - Hooks
function mbAction(&$actionArray)
{
	// Add in the action.
	$actionArray['mb'] = array('ModBuilder.php', 'ModBuilderMain');
}

function mbPermissions(&$permissionGroups, &$permissionList)
{
	loadLanguage('ModBuilderPermissions');
	
	// Permission groups.
	$permissionGroups['membergroup']['simple'] = array('mb_simple');
	$permissionGroups['membergroup']['classic'] = array('mb_classic');
	
	// Permission name => any and own (true) or not (false)
	$permissions = array(
		'view_projects' => true,
		'view_private_projects' => true,
		
		'add' => false,
		
		'remove_projects' => true,
	);

	// Insert the permissions.
	foreach ($permissions as $perm => $ownany)
	{
		if ($ownany)
		{
			$permissionList['membergroup']['mb_' . $perm . '_own'] = array(false, 'mb_classic', 'mb_simple');
			$permissionList['membergroup']['mb_' . $perm . '_any'] = array(false, 'mb_classic', 'mb_simple');
		}
		else
			$permissionList['membergroup']['mb_' . $perm] = array(false, 'mb_classic', 'mb_simple');
	}
}
