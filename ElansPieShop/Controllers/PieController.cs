using ElansPieShop.Models;
using ElansPieShop.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ElansPieShop.Controllers
{
    public class PieController : Controller
    {
      private readonly IPieRepository _pieRepository;
        private readonly ICategoryRepository _categoryRepository;

        public PieController(IPieRepository pieRepository, ICategoryRepository categoryRepository)//constructor 
        {
            _pieRepository = pieRepository; 
            _categoryRepository = categoryRepository;//constructor injection
        }

        public IActionResult List()
        {
            //ViewBag.CurrentCategory = "Cheese cakes";
            //return View(_pieRepository.AllPies);

            PieListViewModels pieListViewModels = new PieListViewModels
                (_pieRepository.AllPies, "Cheese cakes");
            return View(pieListViewModels);
        }
        public IActionResult Details(int id) //action method returns the view that contains details
        {
            var pie = _pieRepository.GetPieById(id);
            if (pie == null)
                return NotFound();
            return View(pie);
            

        }
    }
}
