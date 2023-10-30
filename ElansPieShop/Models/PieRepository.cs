using Microsoft.EntityFrameworkCore;

namespace ElansPieShop.Models
{
    public class PieRepository : IPieRepository
    {
        private readonly ElansPieShopDbContext _elansPieShopDbContext; // instance

        public PieRepository(ElansPieShopDbContext elansPieShopDbContext)
        {
            _elansPieShopDbContext = elansPieShopDbContext;
        }

        public IEnumerable<Pie> AllPies
        {
            get
            {
                return _elansPieShopDbContext.Pies.Include(c => c.Category);
            }
        }

        public IEnumerable<Pie> PiesOfTheWeek
        {
            get
            {
                return _elansPieShopDbContext.Pies.Include(c => c.Category).Where(p => p.IsPieOfTheWeek);
            }
        }

        public Pie? GetPieById(int pieId)
        {
            return _elansPieShopDbContext.Pies.FirstOrDefault(p => p.PieId == pieId);
        }

        public IEnumerable<Pie> SearchPies(string searchQuery)
        {
            throw new NotImplementedException();
        }
    }
}
