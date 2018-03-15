/*
 * functions.js
 * Descripción: Funciones Generales para todo el sitio
 * tamaulipas.gob.mx
*/

//Documentos cargado
$(document).ready(function() { 
    //Slider Principal
    $('#banner-ninesixty').cycle({
		fx: 'scrollUp', // choose your transition type, ex: fade, scrollUp, shuffle, etc...
    	speed:   1200, 
    	timeout: 2000
	});
	   
    //Slider Principal
    $('#row-one .three-news').cycle({
		fx: 'fade', // choose your transition type, ex: fade, scrollUp, shuffle, etc...
    	speed:   1200, 
    	timeout: 8000
	});
	
	//Noticias
	$('#row-two .six-news').cycle({
		fx: 'fade', // choose your transition type, ex: fade, scrollUp, shuffle, etc...
    	speed:   1200, 
    	timeout: 6000
	});
	
	//Banner
	$('#row-two .three-banners .left').cycle({
		fx: 'scrollLeft', // choose your transition type, ex: fade, scrollUp, shuffle, etc...
    	speed:   1200, 
    	timeout: 6500
	});
	
	//Banner
	$('#row-two .three-banners .right').cycle({
		fx: 'scrollRight', // choose your transition type, ex: fade, scrollUp, shuffle, etc...
    	speed:   1200, 
    	timeout: 5500
	});
	
	//Fancybox $('.fancybox').fancybox();	
	$(".thr a").attr('rel', 'gallery').fancybox({
	   openEffect : 'elastic',
	   closeEffect : 'elastic',
	   nextEffect : 'elastic',
	   prevEffect : 'elastic',
	   padding : 10,
	   margin : 50,
	   helpers : {title : null}
	});
	
	//Fix Menu
	var nav = $('#downmenu');
	if ($(this).scrollTop() > 210) { nav.fadeIn(150); } else { nav.fadeOut(150); }
    $(window).scroll(function () {
        if ($(this).scrollTop() > 210) {
            nav.fadeIn(150);
        } else {
            nav.fadeOut(150);
        }
    });
});

//Redes Sociales
$('ul.social li').mouseover(function(){
   $(this).children('a').stop(true, true).animate({opacity:"1.0"}, 600); 
});

$('ul.social li').mouseleave(function(){
   $(this).children('a').stop(true, true).animate({opacity:"0.0"}, 400); 
});

//Servicios en Línea
$('ul.important-three li').mouseenter(function(event){$(this).children("ul.important-three ul").stop(true, true).fadeIn(350);});
$('ul.important-three li').mouseleave(function(event){$(this).children("ul.important-three ul").stop(true, true).fadeOut(350);});

//Menu 
$('li').mouseenter(function(event){$(this).children("ul.menu ul").stop(true, true).fadeIn(350);});
$('li').mouseleave(function(event){$(this).children("ul.menu ul").stop(true, true).fadeOut(125);});