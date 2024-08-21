// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

src = "https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js" >
src="https://code.jquery.com/jquery-3.6.0.min.js" >
$(document).ready(function () {
    $('.table-container').height($(window).height() - $('.table-container').offset().top + 'px');
});

 

$(document).ready(function () {
    // Filter items by name
    $("#searchInput").on("keyup", function () {
        var value = $(this).val().toLowerCase();
        $("#itemsContainer .item").filter(function () {
            $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
        });
    });

    // Show "Back to Top" button
    var btn = $('#backToTopBtn');
    $(window).scroll(function () {
        if ($(window).scrollTop() > 300) {
            btn.addClass('flex');
            btn.removeClass('hidden');
        } else {
            btn.addClass('hidden');
            btn.removeClass('flex');
        }
    });

    btn.on('click', function (e) {
        e.preventDefault();
        $('html, body').animate({ scrollTop: 0 }, '300');
    });
});           


$(document).ready(function () {
    // Toggle between Part 1 and Part 2
    $('#part1Btn').click(function () {
        $('#part1').removeClass('hidden');
        $('#part2').addClass('hidden');
        $(this).addClass('bg-gray-200');
        $('#part2Btn').removeClass('bg-gray-200');
    });

    // $('#part2Btn').click(function () {
    //     $('#part2').removeClass('hidden');
    //     $('#part1').addClass('hidden');
    //     $(this).addClass('bg-gray-200');
    //     $('#part1Btn').removeClass('bg-gray-200');
    // });

    // Search functionality (Part 1)
    $('#searchPart1').keyup(function () {
        var searchText = $(this).val().toLowerCase();
        $('.part-container#part1 tbody tr').each(function () {
            var found = false;
            $(this).find('td').each(function () {
                if ($(this).text().toLowerCase().indexOf(searchText) !== -1) {
                    found = true;
                    return false; // break the loop
                }
            });
            found ? $(this).show() : $(this).hide();
        });
    });
});

document.addEventListener('DOMContentLoaded', function () {
    const part1Btn = document.getElementById('part1Btn');
    const part1Dropdown = document.getElementById('part1Dropdown');
    const part1Arrow = document.getElementById('part1Arrow');

    const part2Btn = document.getElementById('part2Btn');
    const part2Dropdown = document.getElementById('part2Dropdown');
    const part2Arrow = document.getElementById('part2Arrow');

    part1Btn.addEventListener('click', function () {
        part1Dropdown.classList.toggle('hidden');
        part1Arrow.classList.toggle('rotate-90');
    });

    part2Btn.addEventListener('click', function () {
        part2Dropdown.classList.toggle('hidden');
        part2Arrow.classList.toggle('rotate-90');
    });

    // Close dropdowns when clicking outside
    document.addEventListener('click', function (event) {
        if (!part1Btn.contains(event.target)) {
            part1Dropdown.classList.add('hidden');
            part1Arrow.classList.remove('rotate-90');
        }
        if (!part2Btn.contains(event.target)) {
            part2Dropdown.classList.add('hidden');
            part2Arrow.classList.remove('rotate-90');
        }
    });
});   




