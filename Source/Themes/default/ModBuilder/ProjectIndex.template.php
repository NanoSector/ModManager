<?php

// Mod Builder by Yoshi2889 - Project List template
function template_mbViewProjects()
{
	global $context, $txt, $scripturl, $settings;
	
	// Allow this user to create a project, if they can.
	if ($context['mb']['can_create'])
	{
		$poll_buttons = array(
			'vote' => array('text' => 'mb_create_project', 'lang' => true, 'url' => $scripturl . '?action=mb;sa=create', 'active' => true),
		);

		template_button_strip($poll_buttons);
		
		echo '<br />';
	}
	
	if (!empty($context['mb']['projects']))
	{
		$wbg = 0;
		foreach ($context['mb']['projects'] as $index => $project)
		{	
			echo '
			<div class="floatleft projbox">
				<div class="cat_bar">
					<h3 class="catbg">
						<span class="floatleft">
							', $context['mb']['can_edit'] ? '<a href="' . $scripturl . '?action=mb;sa=edit;project=' . $project['id'] . '">' . $project['name'] . '</a>' : $project['name'], ' (v', $project['version'], ')
						</span>';
			
			if ($context['mb']['can_delete_projects'])
				echo '
						<span class="floatright">
							<a href="', $scripturl, '?action=mb;sa=remove;project=', $project['id'], '" onclick="return confirm(', javascriptescape($txt['mb_really_delete_project']), ');">
								<img src="', $settings['default_images_url'], '/icons/delete.gif" alt="" />
							</a>
						</span>';
						
			echo '
					</h3>
				</div>
				<div class="windowbg', $wbg == 1 ? '2' : '', '">
					<span class="topslice"><span></span></span>
					<div style="padding-left:10px">
						', sprintf($txt['mb_version'], $project['version']), '<br />
						', sprintf($txt['mb_type'], $txt['mb_type_' . $project['type']]), '<br />';
					
			if ($context['mb']['can_edit'])
				echo '<br />', $txt['mb_possible_actions'], '
						<ul>
							<li><a href="', $scripturl, '?action=mb;sa=edit;project=', $project['id'], ';area=details">', $txt['mb_action_edit'], '</a></li>
							<li><a href="', $scripturl, '?action=mb;sa=edit;project=', $project['id'], ';area=readme">', $txt['mb_action_edit_readme'], '</a></li>
							<li><a href="', $scripturl, '?action=mb;sa=edit;project=', $project['id'], ';area=instructions">', $txt['mb_action_edit_instructions'], '</a></li>
							<li><a href="', $scripturl, '?action=mb;sa=compile;project=', $project['id'], '">', $txt['mb_action_compile'], '</a></li>
						</ul>';
						
			echo '
					</div>
					<span class="botslice"><span></span></span>
				</div>
			</div>';
			
			$wbg = $wbg == 1 ? 0 : 1;
		}
		echo '
			<br class="clear" />';
	}
	else
		echo '
			<div class="cat_bar">
				<h3 class="catbg centertext">
					', $txt['mb_no_projects'], '
				</h3>
			</div>
			<br class="clear" />';
}
