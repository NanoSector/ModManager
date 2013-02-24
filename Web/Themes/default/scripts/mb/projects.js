// Mod Builder by Yoshi2889 - Projects JavaScript
$(document).ready(function ()
{
	// For every project, add the handler.
	$.each(mbprojects, function (index, value)
	{
		$('#rem_proj_' + value).click(function ()
		{
			removeProject(value, index);
		});
	});
	function removeProject(pid, arrindex)
	{
		var agr = confirm(mbtexts['really_delete_project']);
		if (agr)
		{
			$.ajax(smf_scripturl + '?action=mb;sa=remove;project=' + pid + ';mb_ajax',
			{
				dataType: "json",
				success: function (response)
				{
					if (typeof response.error != 'undefined')
						alert(response.error);
					else
					{
						$('div#proj_' + pid).hide('fast');
						mbprojects.splice(arrindex, 1);
						setTimeout(function ()
						{
							if (mbprojects.length == 0)
							{
								$('#no_projects').show();
								$('br#proj_clear').hide();
							}
						}, 500);
					}
				}
			});
		}
	}
	if (mbprojects.length == 0)
		$('#no_projects').show();
});