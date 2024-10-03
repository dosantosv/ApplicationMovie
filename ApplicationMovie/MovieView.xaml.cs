using API.Model;
using System.Diagnostics;
using System.Windows;
using System.Windows.Media.Imaging;

namespace ApplicationMovie
{
    /// <summary>
    /// Interaction logic for MovieView.xaml
    /// </summary>
    public partial class MovieView : Window
    {
        private Movie movie;
        public MovieView(Movie movie)
        {
            InitializeComponent();

            UpdateValueFields(movie);
        }

        private void UpdateValueFields(Movie movie)
        {
            this.movie = movie;

            txtMovieName.Text = movie.Title;
            txtMovieOverview.Text = string.IsNullOrWhiteSpace(movie.Overview) ? "Sinopse indisponível para este filme." : movie.Overview;
            imgMoviePoster.Source = new BitmapImage(new Uri($"https://image.tmdb.org/t/p/w220_and_h330_face{movie.Poster}", UriKind.RelativeOrAbsolute));

            FillDataInDatagridCast(movie.Cast);
        }

        private void FillDataInDatagridCast(List<Actor> cast)
        {
            if (cast is null || cast.Count is 0)
            {
                var noData = new List<Actor>
                {
                    new()
                    {
                        Name = "Informação indisponível",
                        Character = "Personagem não informado"
                    }
                };

                datagridCast.ItemsSource = noData;

                return;
            }

            foreach (var author in cast)
            {
                author.Character = string.IsNullOrWhiteSpace(author.Character) ? "Personagem não informado" : author.Character;
                author.Name = string.IsNullOrWhiteSpace(author.Name) ? "Informação indisponível" : author.Name;
            }

            datagridCast.ItemsSource = cast;
        }

        private void ButtonTrailer_Click(object sender, RoutedEventArgs e)
        {

            if (movie.Videos.Count is 0)
            {
                System.Windows.MessageBox.Show("Trailer indisponível para esse filme.");
                return;
            }

            var trailer = movie.Videos.FirstOrDefault(m => m.Type == "Trailer" || m.Type == "Official Trailer");

            if (trailer is null)
                trailer = movie.Videos.FirstOrDefault();
           
            string videoUrl = $"https://www.youtube.com/watch?v={trailer.Key}";

            Process.Start(new ProcessStartInfo
            {
                FileName = videoUrl,
                UseShellExecute = true
            });
        }
    }
}
