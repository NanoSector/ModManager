<?php

require(dirname(__FILE__) . '/SSI.php');

$function = '';
if (!isset($_GET['uninstall']) && !isset($_GET['reinstall']))
	$function = 'add_integration_function';
else
	$function = 'remove_integration_function';
	
$hooks = array(
	'integrate_pre_include' => '$sourcedir/Hooks-ModBuilder.php',
	'integrate_actions' => 'mbAction',
	'integrate_load_permissions' => 'mbPermissions',
);

foreach ($hooks as $hook => $value)
	$function($hook, $value);
	
echo 'Hooks adapted. ', count($hooks), ' hooks have been ', isset($_GET['uninstall']) ? 'un' : '', 'installed.';

if (isset($_GET['reinstall']))
{
	global $boardurl;
	redirectexit($boardurl . '/mbHooks.php');
}
