using AutoGlass.Model;
using AutoGlassWeb.Services;
using Microsoft.AspNetCore.Mvc;

namespace AutoGlassWeb.Controllers
{
    public class ProdutoController:Controller
    {
        private readonly WebApiService _webApiService;

        public ProdutoController(WebApiService webApiService)
        {
            _webApiService = webApiService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var produto = await _webApiService.GetProductsAsync();
            return View(produto);
        }
        [HttpPost]
        public async Task<IActionResult> Criar(Produto produto)
        {
            var response = await _webApiService.PostProductAsync(produto);
            return RedirectToAction("Index"); 
        }
    }
}
