$(document).ready(function () {

$('H1').addClass('text-center');

$('H2').addClass('text-center');

$('H1').removeClass("myBannerHeading");

$('H1').addClass("page-header");

$("#yellowHeading").text("Yellow Team");

$('div.orange').css('background-color','orange' );

$('div.blue').css('background-color','blue' );

$('div.red').css('background-color','red' );

$('div.yellow').css('background-color','yellow' );

$("#yellowTeamList").html("<li>Joseph Banks</li><li>Simon Jones</li>");

$("#oops").hide();

$('#footerPlaceholder').remove();

$('#footer').html("<center>Ben Etzkorn &nbsp  benetzkorn@gmail.com</center>");

$('#footer').css('text-center');

$('#footer').css("font-size", "24px");

$('#footer').css("font-family", "courier");
});

