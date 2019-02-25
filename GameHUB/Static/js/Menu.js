/* Set the width of the side navigation to 250px and the left margin of the page content to 250px */
function openNav() {
    document.getElementById("mySidenav").style.width = "250px";
    document.getElementById("main").style.marginLeft = "250px";
    document.getElementById("site-footer").style.paddingLeft = "250px";
}

/* Set the width of the side navigation to 0 and the left margin of the page content to 0 */
function closeNav() {
    document.getElementById("mySidenav").style.width = "0";
    document.getElementById("main").style.marginLeft = "0";
    document.getElementById("site-footer").style.paddingLeft = "0";
    
}

var open = false;
//https://codepen.io/rss/pen/vIDKH/
$(".toggle-icon, .hamburger").click(function () {
    $('#nav-container').toggleClass("pushed");
    $('.hamburger').toggleClass("is-active");
    if (open) {
        open = false;
        closeNav();
    } else {
        open = true;
        openNav();
    }
});

