//
// window.onload = function() {
//
// 	var gifs = Gifffer();
//
// 	$("body").on("click", function(){
// 		gifs[0].click();
//
//
// 	});
//
//
//
// }
$(".photo").click(function () {
    $(".search").toggleClass("active")
});
$(".arrow-down").click(function () {
  $(".arrow-down").toggleClass("rotate")
  $(".hide").toggleClass("shown")
  $(".text-hide").toggleClass("text-shown")
});
$(document).ready(function(){
		  $('.gallery').slick({
			centerMode: true,
  centerPadding: '60px',
  slidesToShow: 3,
  adaptiveHeight: true,
  autoplay: true,
  autoplaySpeed: 470,
  responsive: [
    {
      breakpoint: 768,
      settings: {
        arrows: false,
        centerMode: true,
        centerPadding: '40px',
        slidesToShow: 3
      }
    },
    {
      breakpoint: 480,
      settings: {
        arrows: false,
        centerMode: true,
        centerPadding: '40px',
        slidesToShow: 1
      }
    }
  ]
			});
		});