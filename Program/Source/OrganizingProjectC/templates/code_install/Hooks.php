<?php

if (!defined('SMF') && file_exists(dirname(__FILE__) . '/SSI.php'))
    require_once(dirname(__FILE__) . '/SSI.php');
elseif (!defined('SMF'))
    die('<b>Error:</b> Cannot install - please verify you put this in the same place as SMF\'s index.php.');

// Insert the hooks
$hooks = array(
	'hook' => 'file/function',
	'hook2' => 'file/function',
	'hook3' => 'file/function'
);

foreach ($hooks as $hook => $func)
	add_integration_function($hook, $func);