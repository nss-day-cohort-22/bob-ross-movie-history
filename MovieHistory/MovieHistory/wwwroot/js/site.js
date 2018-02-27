$("#movieSearch__button").click(evt => {
    const userSearchString = $("#movieSearch").val()
    $.ajax({
        method: "GET",
        url: `https://api.themoviedb.org/3/search/movie?api_key=6cc5adb954efa8ba18b1ed8d19b4b1bf&language=en-US&query=${userSearchString}&page=1&include_adult=false`
    }).then(res => {
        let title = ""
        //will hold array of movie rows
        let movies = []
        //array to hold rows of movies
        let movieRow = []
        //counter to help with pushing movieRow to movies after 5 
        // movies have been added
        let counter = 0

        res.results.forEach(m => {
            //change from += to = to capture each movie individually. Wrap each
            //movie in a div tag.
            title = `
                <div>
                <h2>${m.title}</h2>
                <img src="https://image.tmdb.org/t/p/w154${m.poster_path}" />
                </div>
            `
            //push each movie into the movieRow array
            movieRow.push(title)
            //increment counter for each movie added
            counter++
            //every 5th movie push row to movies array and clear row
            if (counter % 5 === 0) {
                movies.push(movieRow)
                movieRow = []
                 }
        })

        //iterate through the collection of rows
        movies.forEach(movArray => {
            //open a div tag and store it in a variable, assign 
            // a class that will make each row a grid
            let wrapper = "<div class='movieRowClass'>"
            //iterate through each movie in the row
            movArray.forEach(mov => {
                //put the movie inside the div
                wrapper += mov
            })
            //close the div after all movies from the row are added
            wrapper += "</div>"
            //'wrapper' now contains 5 movie divs. A row of movies will be appened
            //to the dom on each iteration of the method. 
       $("#movieGrid").append(wrapper)
        })
    })
});

