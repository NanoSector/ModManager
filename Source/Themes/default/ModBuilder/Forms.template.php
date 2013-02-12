<?php

// Mod Builder by Yoshi2889 - Forms and Inputs
function template_mb_mod_settings()
{
	global $context, $txt;
	
	// Show a message if we have saved.
	if (isset($_GET['saved']))
		echo '
	<div class="windowbg" id="profile_success">
		', $txt['mb_mod_saved'], '
	</div>';
	
	// First show a title if we have one.
	if (!empty($context['mb']['settings_title']))
		echo '
	<div class="cat_bar">
		<h3 class="catbg">', $context['mb']['settings_title'], '</h3>
	</div>';
	
	// Open up a windowbg.
	echo '
	<div class="windowbg">
		<span class="topslice"><span></span></span>
		<div style="padding: 0 12%">';
		
	// Now enter the configuration stuff.
	if (!empty($context['mb']['config_vars']))
	{
		echo '
			<form action="', $context['mb']['post_url'], '" method="post">
				<table>';
		
		foreach ($context['mb']['config_vars'] as $setting)
		{
			// Show the label.
			echo '
					<tr>';
					
			// Show a label?
			if (!in_array($setting[0], array('check', 'link')))
				echo '
						<td style="padding-right:10px"><strong>', $setting[3], '</strong></td>
						<td>';
			else
				echo '
						<td></td>
						<td>';
				
			// Figure out the setting type.
			switch ($setting[0])
			{
				// A checkbox?
				case 'check':
					echo '
							<input type="checkbox" id="', $setting[2], '" name="', $setting[2], '"', $setting[4] ? ' checked="checked"' : '', ' /> ', $setting[3];
					break;
				case 'text':
					echo '
							<input type="text" id="', $setting[2], '" name="', $setting[2], '" value="', $setting[4], '"', !empty($setting[5]) ? ' size="' . $setting[5] . '"' : '', !empty($setting[6]) ? ' maxlength="' . $setting[6] . '"' : '', ' />';
					break;
				case 'textarea':
					echo '
							<textarea id="', $setting[2], '" name="', $setting[2], '"', !empty($setting[5]) ? ' rows="' . $setting[5] . '"' : '', !empty($setting[6]) ? ' cols="' . $setting[6] . '"' : '', '>', $setting[4], '</textarea>';
					break;
				case 'select':
					echo '
							<select name="', $setting[2], '">';
							
					foreach ($setting[5] as $option => $text)
					{
						echo '
								<option value="', $option, '"', $setting[4] == $option ? ' selected="selected"' : '', '>', $text, '</option>';
					}
					
					echo '
							</select>';
					break;
				case 'link':
					echo '
							<a href="', $setting[1], '">', $setting[2], '</a>';
					break;
			}
			
			echo '
						</td>
					</tr>';
		}
		
		echo '
				</table>';
				
		// Any hidden settings.
		if (!empty($context['mb']['hidden_config_vars']))
		{
			foreach ($context['mb']['hidden_config_vars'] as $hcv)
			{
				echo '
				<input type="hidden" name="', $hcv[0], '" value="', $hcv[1], '" />';
			}
		}
		
		echo '
				<div class="floatright">
					<input type="submit" value="', $txt['mb_mod_submit'], '" onclick="return submitThisOnce(this);" class="button_submit" />
				</div>
				<br class="clear" />
			</form>';
	}
	
	echo '
				</table>
			</form>';
	
	echo '
		</div>
		<span class="botslice"><span></span></span>
	</div>
	<br class="clear" />';
}

function template_mb_mod_readme()
{
	global $context, $txt;
	
	// Show a message if we have saved.
	if (isset($_GET['saved']))
		echo '
	<div class="windowbg" id="profile_success">
		', $txt['mb_mod_saved'], '
	</div>';
	
	echo '
	<div class="cat_bar">
		<h3 class="catbg">
			', $context['mb']['page_title'], '
		</h3>
	</div>
	<div class="windowbg">
		<span class="topslice"><span></span></span>
		<div style="padding: 0 12%">
			<form action="', $context['mb']['post_url'], '" method="post">
				<div id="bbcBox_message"></div>
				<div id="smileyBox_message"></div>
				', template_control_richedit($context['post_box_name'], 'smileyBox_message', 'bbcBox_message') . '
				<input type="hidden" name="mod_pid" value="', $context['mb']['project']['id'], '" />
				<div class="floatright">
					<input type="submit" value="', $txt['mb_mod_submit'], '" onclick="return submitThisOnce(this);" class="button_submit" />
				</div>
				<br class="clear" />
			</form>
		</div>
		<span class="botslice"><span></span></span>
	</div>';
}
