<?php

// Mod Builder by Yoshi2889 - Project List template
function template_mbViewProjects()
{
	global $context, $txt, $scripturl, $settings;
	
//	echo '<span class="subject">', sprintf($txt['mb_vp_title'], $context['mb']['username']), '</span>';
	
	if (!empty($context['mb']['projects']))
	{
		echo '
	<table style="width: 100%">
		<tr>';
		
		$i = 0;
		$wbg = 0;
		foreach ($context['mb']['projects'] as $index => $project)
		{
			echo '
			<td style="width:25%">
				<div class="cat_bar">
					<h3 class="catbg">
						<span class="floatleft">
							<a href="', $scripturl, '?action=mb;sa=edit;project=', $project['id'], '">', $project['name'], '</a>
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
						', $txt['mb_possible_actions'], '
						<ul>
							<li>Test</li>
							<li>Test</li>
							<li>Test</li>
							<li>Test</li>
						</ul>
					</div>
					<span class="botslice"><span></span></span>
				</div>
			</td>';
			
			$i++;
			if ($i == 4 && $index != count($context['mb']['projects']) - 1)
			{
				echo '
		</tr>
		<tr>';
				$i = 0;
			}
			$wbg = $wbg == 1 ? 0 : 1;
		}
		echo '
		</tr>
	</table>';
	}
}
