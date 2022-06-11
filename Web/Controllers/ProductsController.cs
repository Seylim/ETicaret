using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService productService;
        private readonly ICategoryService categoryService;

        public ProductsController(IProductService productService, ICategoryService categoryService)
        {
            this.productService = productService;
            this.categoryService = categoryService;
        }
        public async Task<IActionResult> Index()
        {
            var products = await productService.GetProducts();
            return View(products);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            List<SelectListItem> selectedItems = GetCategoriesForDropDown();
            ViewBag.Categories = selectedItems;
            return View();
        }

        private List<SelectListItem> GetCategoriesForDropDown()
        {
            var selectedItems = new List<SelectListItem>();

            categoryService.GetCategories().ToList().ForEach(cat => selectedItems.Add(new SelectListItem
            {
                Text = cat.Name,
                Value = cat.Id.ToString()
            }));
            return selectedItems;
        }
    }
}
