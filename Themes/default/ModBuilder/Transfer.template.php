<?php

// Mod Builder by Yoshi2889 - Transfer Ownership template
function template_mb_transfer_ownership()
{
	global $context, $scripturl, $settings, $txt;
	
	echo '
	<div class="cat_bar">
		<h3 class="catbg">
			', $txt['mb']['transfer_ownership'], '
		</h3>
	</div>
	<div class="windowbg">
		<span class="topslice"><span></span></span>
		<div style="padding: 0 12%">
			<div style="padding: 0 12%">
				<form action="', $scripturl, '?action=mb;sa=edit;area=transfer;project=', $context['mb']['project']['id'], ';save" method="post">
					<table>
						<tr>
							<td><strong>', $txt['mb']['transfer_to'], '&nbsp;&nbsp;</strong></td>
							<td>
								<input type="text" id="mod_transfer_to_id" name="mod_transfer_to" class="input_text" size="20" />
								<script type="text/javascript" src="', $settings['default_theme_url'], '/scripts/suggest.js?fin20"></script>
								<script type="text/javascript"><!-- // --><![CDATA[
									var oBypassMembers = new smc_AutoSuggest({
										sSelf: \'oBypassMembers\',
										sSessionId: \'', $context['session_id'], '\',
										sSessionVar: \'', $context['session_var'], '\',
										sControlId: \'mod_transfer_to_id\',
										sSearchType: \'member\',
										sPostName: \'mod_transfer_to\',
										sURLMask: \'action=profile;u=%item_id%\',
										bItemList: false,
									});
								// ]]></script>
							</td>
						</tr>
					</table><br />
				
					<strong>', $txt['mb']['transferring'], '</strong>
					<div class="cat_bar">
						<h3 class="catbg">
							<span class="floatleft">
								', $context['mb']['project']['name'], ' (v', $context['mb']['project']['version'], ')
							</span>
						</h3>
					</div>
					<div class="windowbg2">
						<span class="topslice"><span></span></span>
						<div style="padding-left:10px">
							', sprintf($txt['mb']['version'], $context['mb']['project']['version']), '<br />
							', sprintf($txt['mb']['type'], $txt['mb']['type_' . $context['mb']['project']['type']]), '<br />
						</div>
						<span class="botslice"><span></span></span>
					</div>
					<input type="hidden" name="mod_pid" value="', $context['mb']['project']['id'], '" />
					<div class="floatright">
						', $txt['mb']['is_sure'], '
						<input type="submit" value="', $txt['yes'], '" />
						<button type="button" onclick="javascript:history.go(-1)">', $txt['no'], '</button>
					</div>
					<br class="clear" />
				</form>
			</div>
		</div>
		<span class="botslice"><span></span></span>
	</div>';
}
