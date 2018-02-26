// Write your JavaScript code.

$("#movieSearch__button").click(evt => {
    //what the user searches for
    const userSearchString = $("#movieSearch").val()
    //function to make the api call with user's search
    function searchMovieAPI(userSearch) {
        //if the userSearch is more than one word, split the string at the space and join back together with a plus sign (capitalization does not matter for the api search)
        let apiSearch = userSearch.split(" ").join("+")
        $.ajax({
            "url": `https://api.themoviedb.org/3/search/movie?api_key=858deec9a8305f575390bb92f4c3eab8&query=${apiSearch}`,
               "method": "GET"
        }).then(apiResults => {
            console.log(apiResults)
        })
    }
    //passing the user's search into the function to make the api call
    searchMovieAPI(userSearchString)
});
