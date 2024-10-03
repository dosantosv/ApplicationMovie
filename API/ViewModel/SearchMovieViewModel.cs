using API.APIClient;
using API.Model;

namespace API.ViewModel
{
    public class SearchMovieViewModel : BindingHandler
    {

        private ThemoviedbAPIClient _client = new();
        private List<Movie> _movies;
        private Movie _selectedMovie;

        private int _currentPage = 1;
        private int _totalPages;

        private string _searchedMovieName;
 

        public List<Movie> Movies
        {

            get { return _movies; }

            set { _movies = value; OnPropertyChanged(); }

        }

        public string SearchedMovieName
        {

            get { return _searchedMovieName; }

            set { _searchedMovieName = value; OnPropertyChanged(); }

        }

        public string PageInformationHolder
        {
            get 
            {
                if (Movies is null or { Count: 0 })
                    return string.Empty;

                return $"{_currentPage} to {_totalPages}"; 
            }
        }

        public Movie SelectedMovie
        {

            get { return _selectedMovie; }

            set { _selectedMovie = value; OnPropertyChanged(); }

        }

        public Movie GetCompletedMovie()
        {
            SelectedMovie.Cast = GetActors(SelectedMovie.Id);
            SelectedMovie.Videos = GetVideos(SelectedMovie.Id);

            return SelectedMovie;
        }

        public void NavigateToPreviousPage()
        {
            if (_currentPage == 1 || Movies is null)
                return;

            _currentPage--;

            SearchMovies();
        }

        public void NavigateToFirstPage()
        {
            if (Movies is null)
                return;

            _currentPage = 1;

            SearchMovies();
        }

        public void NavigateToNextPage()
        {
            if (_currentPage == _totalPages || Movies is null)
                return;

            _currentPage++;

            SearchMovies();
        }

        public void NavigateToLastPage()
        {
            if (Movies is null)
                return;

            _currentPage = _totalPages;

            SearchMovies();
        }

        public FunctionResponse SearchMovies()
        {
            var functionResponse = new FunctionResponse();

            (_totalPages, Movies) = _client.GetMovies(_searchedMovieName, _currentPage);

            if (Movies is null or { Count: 0})
            {
                functionResponse.ErrorMessage = "Não encontramos o filme. Verifique o nome e tente novamente!";
                return functionResponse;
            }  

            OnPropertyChanged(nameof(PageInformationHolder));

            return functionResponse;
        }

        public List<Actor> GetActors(int movieId)
        {
            return _client.GetActors(movieId);
        }

        public List<Video> GetVideos(int movieId)
        {
            return _client.GetVideos(movieId);
        }

    }
}
