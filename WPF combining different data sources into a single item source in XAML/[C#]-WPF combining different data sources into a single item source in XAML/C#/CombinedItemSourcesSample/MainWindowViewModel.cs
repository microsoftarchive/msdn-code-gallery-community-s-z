using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombinedItemSourcesSample
{
    public class MainWindowViewModel
    {
        public MainWindowViewModel()
        {
            //Instantiate the ObservableCollections and set up some test data.
            this.Movies = new ObservableCollection<Movie>
            {
                new Movie{ Id=1, Title="Scarface", Director="Brian De Palma"},
                new Movie{ Id=2, Title="Trainspotting", Director="Danny Boyle"},
                new Movie{ Id=3, Title="Pi", Director="Darren Aronofsky"}
            };

            this.Albums = new ObservableCollection<Album>
            {
                new Album{Id=1, Title="Pills, Thrills and Bellyaches", Artist="Happpy Mondays" },
                new Album{Id=2, Title="Youth and young manhood", Artist="The Kings of Leon" },
                new Album{Id=3, Title="El Camino", Artist="The Black Keys" }
            };

            this.Books = new ObservableCollection<Book>
            {
                new Book{ Id=1, Title="1984", Author="George Orwell" },
                new Book{ Id=2, Title="Zero History", Author="William Gibson" },
                new Book{ Id=3, Title="Surface Detail", Author="Iain M Banks" }
            };

        }

        public ObservableCollection<Movie> Movies { get; set; }

        public ObservableCollection<Book> Books { get; set; }

        public ObservableCollection<Album> Albums { get; set; }
    }
}
