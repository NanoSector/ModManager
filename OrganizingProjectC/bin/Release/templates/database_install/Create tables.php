<?php

if (file_exists(dirname(__FILE__) . '/SSI.php') && !defined('SMF'))
	require_once(dirname(__FILE__) . '/SSI.php');
elseif (!defined('SMF'))
	die('<b>Error:</b> Cannot uninstall - please verify you put this file in the same place as SMF\'s SSI.php.');

db_extend('packages');
global $smcFunc;

// The table columns.
$columns = array(
	array(
		'name' => 'id',
		'type' => 'int',
		'size' => 10,
		'unsigned' => true,
		'auto' => true,
	),
	array(
		'name' => 'name',
		'type' => 'text',
	)
);

// And the index for the table.
$indexes = array(
	array(
		'type' => 'primary',
		'columns' => array('id')
	),
);

$smcFunc['db_create_table']('{db_prefix}table_name', $columns, $indexes, array(), 'ignore');