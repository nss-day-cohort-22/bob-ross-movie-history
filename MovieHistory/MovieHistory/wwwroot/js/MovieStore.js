const movieCollection = Symbol()


const MovieStore = Object.create(null, {
    init: {
        value: function () {
            this[movieCollection] = []
        }
    },
    movies: {
        set: function (movieArray) {
            this[movieCollection] = movieArray
        },
        get: function () {
            return this[movieCollection]
        }
    }
})