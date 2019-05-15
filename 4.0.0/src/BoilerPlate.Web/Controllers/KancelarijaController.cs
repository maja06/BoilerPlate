using BoilerPlate.KancelarijaAppService;
using BoilerPlate.KancelarijaAppService.Dto;
using Microsoft.AspNetCore.Mvc;

namespace BoilerPlate.Web.Controllers
{
    
    public class KancelarijaController : BoilerPlateControllerBase
    {
        private readonly IKancelarijaAppService _kancelarijaAppService;

        public KancelarijaController(IKancelarijaAppService kancelarijaAppService)
        {
            _kancelarijaAppService = kancelarijaAppService;
        }
    
        
        public IActionResult Index()
        {
            var output = _kancelarijaAppService.Get();
            var model = new KancelarijaGetAllDto(output);
            return View(model);
        }

        
        public IActionResult Add()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Add(KancelarijaDto input)
        {
             _kancelarijaAppService.Insert(input);
           
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Kancelarija(int? id)
        {
            KancelarijaGetDto output = null;
            if (id.HasValue)
            {
                output = _kancelarijaAppService.GetKancelarija(id.Value);
            }
            return View(output);
        }

        public IActionResult Delete(int? id)
        {
            KancelarijaDto output = null;
            if (id.HasValue)
            {
                output = _kancelarijaAppService.GetById(id.Value);
            }

            return View(output);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult Delete(int id)
        {
            _kancelarijaAppService.Delete(id);
            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            var kancelarija = _kancelarijaAppService.GetKancelarija(id);
            KancelarijaPutDto novaKancelarija = new KancelarijaPutDto
            {
                Opis = kancelarija.Opis
            };

            return View(novaKancelarija);

        }

        [HttpPost]
        public IActionResult Update(int id, KancelarijaPutDto input)
        {
            _kancelarijaAppService.Update(id, input);
            return RedirectToAction("Index");
        }
            
        







    }

}
