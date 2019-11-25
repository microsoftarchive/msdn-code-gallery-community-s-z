var $j = jQuery.noConflict();

$j(function() {
	BindTopNav();
	BindWPMenu();
	BindBodySpans();
});
/*top nav*/
function BindTopNav() {
	var sn = $j('.s4-tn').eq(0);
	if (sn.length > 0)
		sn.addClass('nav').removeClass('s4-tn');
	var u = $j('#topnavbar ul.root');
	if (u.length > 0) {
		u.find('.dynamic-children > .menu-item').each(function() {
			//if hover events, then try
			var l = $j(this).parent('li');
			var s = $j(this).children('span').eq(0);
			l.hover(
				function () {HoverTopNav($j(this));},
				function () {HoverTopNav($j(this));}
			);
			//trap link clicked
			$j(this).bind('click',function(e) {
				var w = $j(this).outerWidth(true);
				var s = $j(this).children('span').eq(0);
				var rs = parseInt($j(this).css("padding-right")) + parseInt($j(this).css("margin-right")) + parseInt(s.css("padding-right")) + parseInt(s.css("margin-right"));
				var x = e.pageX - $j(this).offset().left;
				if (x > (w-rs))
					DropTopNav($j(this));
				else
					return true;
		    	return false;
			});
			//need to trap span too for some browsers
			s.bind('click',function(e) {
				var w = $j(this).outerWidth(true);
				var rs = parseInt($j(this).css("padding-right")) + parseInt($j(this).css("margin-right"));
				var x = e.pageX - $j(this).offset().left;
				if ((x > (w-rs)) || ($j(this).parent('a').eq(0).length < 1))
					DropTopNav($j(this).parent('.menu-item').eq(0));
				else
					window.location.href = $j(this).parent('a').eq(0).attr('href');
		    	return false;
			});
		});
	}
}
function HoverTopNav(l) {
	if (l.length > 0) {
		var m = $j('.navbar .btn-navbar');
		if (m.length > 0) {
			if (m.css('display') != 'block')
				DropTopNav(l.children('.dynamic-children').eq(0));
		}
	}
}
function DropTopNav(l) {
	if (l.length > 0) {
		var u = l.siblings('ul').eq(0);
		if (u.length > 0) {
			if (u.css('display') != 'block') {
				u.css('display','block');
				l.addClass('selected');
			}
			else {
				u.css('display','none');
				l.removeClass('selected');
			}
		}
	}
}
/*end top nav*/

/*WebPartMenu*/
function BindWPMenu() {
	if ($j('#MSOTlPn_Tbl').length > 0) {
		var myDiv2Para = $j('#MSOTlPn_Tbl').detach();
		$j('#s4-bodyContainer').prepend('<div id="MSOTlPn_MainTD_Div"></div>');
		myDiv2Para.appendTo('#MSOTlPn_MainTD_Div');
		$j('#MSOTlPn_ToolPaneCaption').dragdrop({root:'#MSOTlPn_Tbl',SwapHorz:false});
	}
}
/*end WebPartMenu*/

/*body spans*/
/*used to hide left nav bar if empty, or to ensure that primary content span set to span12 if not left nav*/
function BindBodySpans() {
	var bHideLeftNav = false;
	if (($j('#s4-leftpanel').length > 0) && ($j('#MSO_ContentTable').length > 0)) {
		if ($j('#s4-leftpanel').css('display') == 'none') {
			bHideLeftNav = true;
		}
	}
	if (bHideLeftNav) {
		$j('#MSO_ContentTable').removeClass('span9').addClass('span12').css({'margin-left':'0px'});
		$j('#s4-leftpanel').css({'display':'none'});
	}
}
/*end body spans*/