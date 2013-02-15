<?php

// Mod Builder by Yoshi2889 - Project List template
function template_mbViewProjects()
{
	global $context, $txt, $scripturl, $settings;
	
	// Transferred a project?
	if (!empty($_GET['transferred']) && !empty($context['mb']['user_link']))
		echo '
			<div class="windowbg" id="profile_success">
				', sprintf($txt['mb']['project_transferred_to'], $context['mb']['user_link']), '
			</div>';
	
	// Deleted one?
	if (isset($_GET['deleted']))
		echo '
			<div class="windowbg" id="profile_success">
				', $txt['mb']['project_removed'], '
			</div>';
	
	// Allow this user to create a project, if they can.
	if ($context['mb']['can_create'])
	{
		$txt['mb_create_project'] = $txt['mb']['create_project'];
		$poll_buttons = array(
			'create' => array('text' => 'mb_create_project', 'lang' => true, 'url' => $scripturl . '?action=mb;sa=create', 'active' => true),
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
			<div class="floatleft projbox" id="proj_', $project['id'], '">
				<div class="cat_bar">
					<h3 class="catbg">
						<span class="floatleft">
							', $context['mb']['can_edit'] ? '<a href="' . $scripturl . '?action=mb;sa=edit;project=' . $project['id'] . '">' . $project['name'] . '</a>' : $project['name'], ' (v', $project['version'], ')
						</span>';
			
			if ($context['mb']['can_delete_projects'])
				echo '
						<span class="floatright">
							<a href="#" onclick="removeProject(', $project['id'], ')">
								<img src="', $settings['default_images_url'], '/icons/delete.gif" alt="" />
							</a>
						</span>';
						
			echo '
					</h3>
				</div>
				<div class="windowbg', $wbg == 1 ? '2' : '', '">
					<span class="topslice"><span></span></span>
					<div style="padding-left:10px">
						', sprintf($txt['mb']['version'], $project['version']), '<br />
						', sprintf($txt['mb']['type'], $txt['mb']['type_' . $project['type']]), '<br />';
					
			if ($context['mb']['can_edit'])
				echo '<br />', $txt['mb']['possible_actions'], '
						<ul>
							<li><a href="', $scripturl, '?action=mb;sa=edit;project=', $project['id'], ';area=details">', $txt['mb']['action_edit'], '</a></li>
							<li><a href="', $scripturl, '?action=mb;sa=edit;project=', $project['id'], ';area=readme">', $txt['mb']['action_edit_readme'], '</a></li>
							<li><a href="', $scripturl, '?action=mb;sa=edit;project=', $project['id'], ';area=instructions">', $txt['mb']['action_edit_instructions'], '</a></li>
							<li><a href="', $scripturl, '?action=mb;sa=compile;project=', $project['id'], '">', $txt['mb']['action_compile'], '</a></li>
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
	{
		echo '
			<div class="cat_bar">
				<h3 class="catbg centertext">';
				
		if ($context['mb']['current_user'] == $context['user']['id'])
			echo sprintf($txt['mb']['no_projects_personal'], ($context['mb']['can_create'] ? '<a href="' . $scripturl . '?action=mb;sa=create">' . $txt['mb']['create_project'] . '</a>' : ''));
		else
			echo $txt['mb']['no_projects'];
			
		echo '
				</h3>
			</div>
			<br class="clear" />';
	}
}
