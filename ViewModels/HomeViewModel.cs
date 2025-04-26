using restaurant_management.Models;

namespace restaurant_management.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Restaurant> Restaurants { get; set; } = new List<Restaurant>();
        public IEnumerable<Table> Tables { get; set; } = new List<Table>();
        public IEnumerable<MenuItem> MenuItems { get; set; } = new List<MenuItem>();
        public IEnumerable<Reservation> Reservations { get; set; } = new List<Reservation>();
    }
}