using ElansPieShop.Models;

namespace ElansPieShop.ViewModels
{
    public class PieListViewModels
    {
        public IEnumerable <Pie> Pies { get; }

        public string? CurrentCategory { get; }

        public PieListViewModels (IEnumerable <Pie> pies, string? currentCategory)
        {
            Pies = pies;
            CurrentCategory = currentCategory;
        }

    }
}
