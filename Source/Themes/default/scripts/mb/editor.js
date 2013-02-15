// Mod Builder by Yoshi2889 - Editor JavaScript
$(document).ready(function ()
{
	$('#mbformadvsettings').click(function ()
	{	
		if ($('#mbformadvsettings_content').is(":hidden"))
		{
			$('#mbformadvsettings_content').show('slow')
			$('#mbformadvsettings_text').text(mbtexts.advanced_options_hide);
			$('#mbformadvsettings_icon').attr('src', smf_images_url + '/collapse.gif');
		}
		else
		{
			$('#mbformadvsettings_content').hide('slow')
			$('#mbformadvsettings_text').text(mbtexts.advanced_options);
			$('#mbformadvsettings_icon').attr('src', smf_images_url + '/expand.gif');
		}
	});
	
	function genModID()
	{
		var modname = $('input#mod_name').val();
		modname = modname.replace(/[^A-Za-z0-9_-]/g, "");
		var username = smf_user_name;
		username = username.replace(/[^A-Za-z0-9_-]/g, '');
		
		var modid = username + ':' + modname;
		
		if (modid.length > 32)
			modid = modid.substr(0, 32);
		$('input#mod_id').val(modid);
	}
			
	function mbValidateForm()
	{
		$('ul#form_errors').empty();
		if ($('input#mod_name').val() === "")
		{
			$('ul#form_errors').append('<li class="error">' + mbtexts.empty_mod_name + '</li>');
			$('span#l_mod_name').addClass('error');
		}
		else
			$('span#l_mod_name').removeClass('error');
				if ($('input#mod_version').val() === "")
		{
			$('ul#form_errors').append('<li class="error">' + mbtexts.empty_mod_version + '</li>');
			$('span#l_mod_version').addClass('error');
		}
		else
			$('span#l_mod_version').removeClass('error');
		
		var modid = $('input#mod_id').val();
		var gmodid = $('input#mod_autogenid').is(':checked');
		if (!gmodid && modid !== "" && (modid[modid.length - 1] === ":" || modid.indexOf(':') === -1))
		{
			$('ul#form_errors').append('<li class="error">' + mbtexts.invalid_mod_id + '</li>');
			$('span#l_mod_id').addClass('error');
		}
		
		if (modid === "" && !gmodid)
		{
			$('ul#form_errors').append('<li class="error">' + mbtexts.empty_mod_id + '</li>');
			$('span#l_mod_id').addClass('error');
		}
		else if (!gmodid)
			$('span#l_mod_id').removeClass('error');
			
		if ($('ul#form_errors').html() !== "")
		{
			$('div#errors_container').show('slow');
			return false;
		}
		else
		{
			$('div#errors_container').hide('fast');
			return true;
		}
	}
			
	$('#mod_autogenid').change(function ()
	{
		if (this.checked === false)
		{
			$('div#mod_modid_container').show('fast');
		}
		else
		{
			$('div#mod_modid_container').hide('fast');
			genModID();
		}
	});
			
	$('button#genmodid').click(function ()
	{
		genModID();
	});
	
	$('form#mod_form').submit(function (event)
	{
		var check = $('input#mod_autogenid').is(':checked');
		if (check)
			genModID();
			
		event.preventDefault();
		
		//if (mbValidateForm() === false)
		//	return false;
		
		if (mbmethod === 'edit')
			$.post(
				smf_scripturl + '?action=mb;sa=edit;project=' + mbpid + ';save;mb_ajax',
				$(this).serialize(),
                		function(data)
                		{
                			if (typeof data.error != 'undefined')
					{
						$('ul#form_errors').empty();
						$.each(data.error, function (key, value)
						{
							$('ul#form_errors').append('<li class="error">' + value + '</li>');
						});
						$('div#errors_container').show('slow');
					}
					else
					{
						$('div#errors_container').hide('fast');
						$('div#profile_success').show('slow');
						setTimeout(function ()
						{
							$('#profile_success').fadeOut('slow');
						}, 5000);
					}
                		},
                		'json'
			);
		else if (mbmethod === 'create')
			$.post(
				smf_scripturl + '?action=mb;sa=create;save;mb_ajax',
				$(this).serialize(),
				function (data)
				{
					if (typeof data.error != 'undefined')
					{
						$('ul#form_errors').empty();
						$.each(data.error, function (key, value)
						{
							console.log(key);
							$('ul#form_errors').append('<li class="error">' + value + '</li>');
						});
						$('div#errors_container').show('slow');
					}
					else if (typeof data.success != 'undefined')
						window.location = data.success;
				},
				'json'
			);
	});
	
	// Loose JS bits.	
	$('#mbformadvsettings_content').hide();
	$('#profile_success').hide();
	
	if ($('#profile_success').length !== 0 && typeof is_saved != 'undefined')
	{
		$('#profile_success').show();
		setTimeout(function ()
		{
			$('#profile_success').fadeOut('slow');
		}, 5000);
	}
});
