$("#movieSearch__button").click(evt => {
    const userSearchString = $("#movieSearch").val()
    $.ajax({
        method: "GET",
        url: `https://api.themoviedb.org/3/search/movie?api_key=858deec9a8305f575390bb92f4c3eab8&language=en-US&query=${userSearchString}&page=1&include_adult=false`,
    }).then(res => {
        let titles = ""
        res.results.forEach(m => {
            titles += `<h2>${m.title}</h2>`
        })

        $("#movieGrid").html(titles)
    })
});