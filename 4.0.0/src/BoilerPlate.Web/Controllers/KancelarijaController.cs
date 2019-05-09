using BoilerPlate.KancelariajAppService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BoilerPlate.KancelariajAppService.Dto;
using Microsoft.AspNetCore.Mvc;
using BoilerPlate.KancelarijaAppService;

namespace BoilerPlate.Web.Controllers
{
    public class KancelarijaController : BoilerPlateControllerBase
    {

        private readonly IKancelarijaAppService _kancelarijaAppSevice;

        public KancelarijaController(IKancelarijaAppService kancelarijaAppService)
        {
            _kancelarijaAppSevice = kancelarijaAppService;
        }

        [HttpGet]
        public IActionResult Kancelarija(int? id)
        {
            KancelarijaGetDto output = null;
            if (id.HasValue)
            {
                output = _kancelarijaAppSevice.GetKancelarija(id.Value);
            }

            return View(output);
        }

        public IActionResult Index()
        {
            var output = _kancelarijaAppSevice.Get();
            var model = new KancelarijaGetAllDto(output);
            return View(model);
        }

        [HttpPost]
        public IActionResult Add()
        {
            return View();
        }


        public IActionResult Delete(int id)
        {
            KancelarijaDto output = 
            if (id.HasValue)
            {
               

            return View(output);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult Delete(int id)
        {
            _kancelarijaAppSevice.Delete(id);
            return RedirectToAction();
        }


        public IActionResult Update(int id)
        {
            var kancelarija = _kancelarijaAppSevice.GetKancelarija(id);
            KancelarijaPutDto newKancelarija = new KancelarijaPutDto()
            {
                Opis = kancelarija.Opis
            };
            

            return View(newKancelarija);

        }

        [HttpPost]
        public IActionResult Update(int id, KancelarijaPutDto input)
        {
            _kancelarijaAppSevice.Update(id, input);
            return RedirectToAction("Index");


        }
    }
}

