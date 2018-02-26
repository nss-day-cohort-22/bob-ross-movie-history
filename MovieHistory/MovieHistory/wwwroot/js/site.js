// Write your JavaScript code.

$("#movieSearch__button").click(evt => {
    const userSearchString = $("#movieSearch").val()

    let keywords = userSearchString.replace(/ {2}/g, "+").replace(/ /g, "+")

    let movieString = "http://www.omdbapi.com/?apikey=7bdab718&s=" + keywords

    $.ajax({
        "url": movieString,
        "method": "GET"
    }).then(result => {
        console.log(result)
    })

});
