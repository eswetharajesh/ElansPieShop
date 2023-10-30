namespace ElansPieShop.Models
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ElansPieShopDbContext _elansPieShopDbContext;

        public CategoryRepository(ElansPieShopDbContext elansPieShopDbContext)
        {
            _elansPieShopDbContext = elansPieShopDbContext;
        }

        public IEnumerable<Category> AllCategories =>
            _elansPieShopDbContext.Categories.OrderBy(p => p.CategoryName);
    }
}
