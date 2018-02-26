// Write your JavaScript code.

$("#movieSearch__button").click(evt => {
    //what the user searches for
    const userSearchString = $("#movieSearch").val()
       //ajax call using the user search
    $.ajax({
        "url": `https://api.themoviedb.org/3/search/movie?api_key=858deec9a8305f575390bb92f4c3eab8&query=${userSearchString}`,
        "method": "GET"
    }).then(apiResults => {
        console.log(apiResults)
    })

});