<?php

// Mod Builder by Yoshi2889 - Forms and Inputs
function template_mb_project_settings()
{
	global $context, $txt, $settings;
	
	// Show a message if we have saved.
	if (isset($_GET['saved']))
		echo '
	<div class="windowbg" id="profile_success">
		', $txt['mb']['mod_saved'], '
	</div>';
	
	// Any errors, doc?
	if (!empty($context['mb']['errors']))
	{
		// Unfortunately, yes...
		echo '
	<div class="errorbox">
		<strong>', $txt['mb']['errors_occured'], '</strong>
		<ul class="reset">';

		foreach ($context['mb']['errors'] as $error)
			echo '
			<li class="error">', $txt['mb'][$error], '</li>';

		echo '
		</ul>
	</div>';
	}
	
	// Then start up our regular stuff.
	echo '
	<div class="cat_bar">
		<h3 class="catbg">
			', $context['mb']['settings_title'], '
		</h3>
	</div>
	<div class="windowbg">
		<span class="topslice"><span></span></span>
		<div class="mbformcontent">
			<a id="mbformadvsettings">
				<img id="mbformadvsettings_icon" class="icon" src="', $settings['images_url'], '/expand.gif" alt="" /> 
				<span id="mbformadvsettings_text">', $txt['mb']['advanced_options'], '</span>
			</a>
			<div id="mbformadvsettings_content">
				<strong>', $txt['mb']['advanced_settings_desc'], '</strong><br />
				<label for="mod_modid"><strong>', $txt['mb']['mod_id'], '&nbsp;</strong></label>
				<input type="text" id="mod_modid" name="mod_modid" value="', $context['mb']['project']['modid'], '" maxlength="32" />
				<br class="clear" />
			</div>
		</div>
		<span class="botslice"><span></span></span>
	</div>';
}

function template_mb_mod_readme()
{
	global $context, $txt;
	
	// Show a message if we have saved.
	if (isset($_GET['saved']))
		echo '
	<div class="windowbg" id="profile_success">
		', $txt['mb']['mod_saved'], '
	</div>';
	
	// If the user wants to see how their readme looks - the preview section is where it's at!
	if (!empty($context['mb']['previewing']))
		echo '
	<div id="preview_section">
		<div class="cat_bar">
			<h3 class="catbg">
				<span id="preview_subject">', $txt['mb']['preview_readme'], '</span>
			</h3>
		</div>
		<div class="windowbg">
			<span class="topslice"><span></span></span>
			<div class="content">
					', empty($context['mb']['preview_readme']) ? $txt['mb']['readme_left_empty'] : $context['mb']['preview_readme'], '
			</div>
			<span class="botslice"><span></span></span>
		</div>
	</div><br />';
	
	echo '
	<div class="cat_bar">
		<h3 class="catbg">
			', $context['mb']['page_title'], '
		</h3>
	</div>
	<div class="windowbg">
		<span class="topslice"><span></span></span>
		<div class="mbformcontent">
			<form action="', $context['mb']['post_url'], '" method="post">
				<div id="bbcBox_message"></div>
				<div id="smileyBox_message"></div>
				', template_control_richedit($context['post_box_name'], 'smileyBox_message', 'bbcBox_message') . '
				<input type="hidden" name="mod_pid" value="', $context['mb']['project']['id'], '" />
				<div class="floatright">
					', template_control_richedit_buttons($context['post_box_name']), '
				</div>
				<br class="clear" />
			</form>
		</div>
		<span class="botslice"><span></span></span>
	</div>';
}

function template_mb_flexible_settings()
{
	global $context, $txt;
	
	// Show a message if we have saved.
	if (isset($_GET['saved']))
		echo '
	<div class="windowbg" id="profile_success">
		', $txt['mb']['mod_saved'], '
	</div>';
	
	// Any errors, doc?
	if (!empty($context['mb']['errors']))
	{
		// Unfortunately, yes...
		echo '
	<div class="errorbox">
		<strong>', $txt['mb']['errors_occured'], '</strong>
		<ul class="reset">';

		foreach ($context['mb']['errors'] as $error)
			echo '
			<li class="error">', $txt['mb']['' . $error], '</li>';

		echo '
		</ul>
	</div>';
	}
	
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
		<div class="mbformcontent">';
		
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
						<td style="padding-right:10px">
							<strong>', !empty($context['mb']['mark_errors']) && empty($context['mb']['project'][$setting[1]]) ? '<span class="error">' . $setting[3] . '</span>' : $setting[3], '</strong>
						</td>
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
							<input type="checkbox" id="', $setting[2], '" name="', $setting[2], '"', $context['mb']['project'][$setting[1]] ? ' checked="checked"' : '', ' /> ', $setting[3];
					break;
				case 'text':
					echo '
							<input type="text" id="', $setting[2], '" name="', $setting[2], '" value="', $context['mb']['project'][$setting[1]], '"', !empty($setting[4]) ? ' size="' . $setting[4] . '"' : '', !empty($setting[5]) ? ' maxlength="' . $setting[5] . '"' : '', ' />';
					break;
				case 'textarea':
					echo '
							<textarea id="', $setting[2], '" name="', $setting[2], '"', !empty($setting[4]) ? ' rows="' . $setting[4] . '"' : '', !empty($setting[5]) ? ' cols="' . $setting[5] . '"' : '', '>', $context['mb']['project'][$setting[1]], '</textarea>';
					break;
				case 'select':
					echo '
							<select name="', $setting[2], '">';
							
					foreach ($setting[4] as $option => $text)
					{
						echo '
								<option value="', $option, '"', $context['mb']['project']['type'] == $option ? ' selected="selected"' : '', '>', $text, '</option>';
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
					<input type="submit" value="', $txt['mb']['mod_submit'], '" onclick="return submitThisOnce(this);" class="button_submit" />
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
