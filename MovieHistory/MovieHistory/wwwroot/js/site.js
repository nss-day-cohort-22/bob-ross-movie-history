$("#movieSearch__button").click(evt => {
    const userSearchString = $("#movieSearch").val()
    $.ajax({
        method: "GET",
        url: `https://api.themoviedb.org/3/search/movie?api_key=ec2f1e210a4d2150e069b9b93b4a4c12&language=en-US&query=${userSearchString}&page=1&include_adult=false`,
        success: (Response => console.log(Response))
    })
});