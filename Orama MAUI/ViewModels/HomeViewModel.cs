
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Orama_MAUI.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
namespace Orama_MAUI.ViewModels
{
    public partial class HomeViewModel : ObservableObject
    {
        public ObservableCollection<HomeCarouselItem> CarouselItems { get; set; }  //Image Carousel
        public ICommand OpenCarouselLinkCommand { get; }
        public HomeViewModel()
        {
            OpenCarouselLinkCommand = new Command<HomeCarouselItem>(OpenCarouselLink);
            CarouselItems = new ObservableCollection<HomeCarouselItem>
            {
                 new HomeCarouselItem 
                 { 
                     Title="Chainsaw Man",
                     ImageUrl="https://i.postimg.cc/dLHHvMZz/Chainsaw-Man.jpg",
                     Description= "\"Chainsaw Man follows Denji, a devil hunter fused with a chainsaw demon, battling grotesque devils in a brutal world.\"",
                     NavigateUrl="https://www.justwatch.com/in/tv-show/chainsaw-man"
                 },
                 new HomeCarouselItem
                 { 
                     Title = "Demon Slayer",
                     ImageUrl= "https://i.postimg.cc/Q9JmyvrY/Demon-Slayer.jpg",
                     Description= "\"Demon Slayer follows Tanjiro, a kind-hearted boy, battling demons to avenge his family and cure his sister, Nezuko.\"",
                     NavigateUrl="https://www.justwatch.com/in/tv-show/demon-slayer-kimetsu-no-yaiba/season-1"
                 },
                 new HomeCarouselItem
                 { 
                     Title = "One Piece",
                     ImageUrl= "https://i.postimg.cc/hJxp9fZB/OnePiece.jpg",
                     Description ="\"One Piece follows Luffy and his pirate crew on an epic journey to find the legendary treasure, the One Piece.\"",
                     NavigateUrl="https://www.justwatch.com/in/tv-show/one-piece"
                 },
                 new HomeCarouselItem
                 {
                     Title = "Weathering With You",
                     ImageUrl= "https://i.postimg.cc/BPZp9NSS/weathering-With-You.jpg",
                     Description = "\"Weathering With You follows a runaway boy who meets a girl with the mysterious ability to control the weather.\"",
                     NavigateUrl="https://www.justwatch.com/in/movie/weathering-with-you"
                 },
                 new HomeCarouselItem 
                 { 
                     Title = "Your Name", 
                     ImageUrl= "https://i.postimg.cc/k6mwwqLt/YourName.jpg", 
                     Description = "\"Your Name is a romantic fantasy anime where two strangers mysteriously swap bodies and form a deep, fateful connection.\"",
                     NavigateUrl = "https://www.justwatch.com/in/movie/your-name"
                 }
            };
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private int _currentPosition;
        public int CurrentPosition
        {
            get => _currentPosition;
            set
            {
                if (_currentPosition != value)
                {
                    _currentPosition = value;
                    OnPropertyChanged();
                }
            }
        }
        private void OpenCarouselLink(HomeCarouselItem item)
        {
            if (!string.IsNullOrEmpty(item?.NavigateUrl))
            {
                Launcher.Default.OpenAsync(item.NavigateUrl);
            }
        }
    }
}
