using API.ViewModel;
using System.Windows;
using System.Windows.Input;

namespace ApplicationMovie
{
    /// <summary>
    /// Interaction logic for MovieView.xaml
    /// </summary>
    public partial class SearchMovieView : Window
    {

        private SearchMovieViewModel _viewModel = new();

        public SearchMovieView()
        {
            InitializeComponent();
            this.DataContext = _viewModel;
        }

        private void ButtonSearch_Click(object sender, RoutedEventArgs e)
        {
            if (txtMovie.Text == string.Empty)
            {
                System.Windows.MessageBox.Show("É necessário informar o nome de um filme.");
                return;
            }

            var result = _viewModel.SearchMovies();

            if (!result.Success)
                System.Windows.MessageBox.Show(result.ShowErrorMessage());

        }

        private void DataGrid_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (dataGridMovies.SelectedIndex is -1)
                return;

            MovieView moviewView = new(_viewModel.GetCompletedMovie());
            moviewView.ShowDialog();
        }

        private void ButtonPrevious_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.NavigateToPreviousPage();
        }

        private void ButtonFirst_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.NavigateToFirstPage();
        }

        private void ButtonNext_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.NavigateToNextPage();
        }

        private void ButtonLast_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.NavigateToLastPage();
        }
    }
}
