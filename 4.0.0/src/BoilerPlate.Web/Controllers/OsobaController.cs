using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BoilerPlate.KancelariajAppService;
using BoilerPlate.KancelarijaAppService;
using BoilerPlate.OsobaAppService.Dto;
using BoilerPlate.Web.Dto;
using log4net.Appender;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Internal;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp;

namespace BoilerPlate.Web.Controllers
{
    public class OsobaController : BoilerPlateControllerBase
    {
        private readonly IOsobaAppService _osobaAppService;
        private readonly IKancelarijaAppService _kancelarijaAppService;

        public OsobaController(IOsobaAppService osobaAppService, IKancelarijaAppService kancelarijaAppService)
        {
            _osobaAppService = osobaAppService;
            _kancelarijaAppService = kancelarijaAppService;
        }

        public IActionResult Index()
        {
            var output = _osobaAppService.Get();
            var model = new OsobaGetAllDto(output);
            return View(model);
        }


        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(OsobaPostDto input)
        {
            _osobaAppService.Insert(input);
            return RedirectToAction("Index");

        }

        public IActionResult Delete(int? id)
        {
            OsobaGetDto output = null;

            if (id.HasValue)
            {
                output = _osobaAppService.GetById(id.Value);
            }

            return View(output);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _osobaAppService.Delete(id);
            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            var osoba = _osobaAppService.GetOsoba(id);
            OsobaPutDto newOsoba = new OsobaPutDto
            {
                Ime = osoba.Ime,
                Prezime = osoba.Prezime,
                KancelarijaId = osoba.KancelarijaId
            };

            var listaKancelarija = SelectKancelarija();
            ViewData["KancelarijaLista"] = listaKancelarija;
            return View(newOsoba);

        }

        public SelectList SelectKancelarija()
        {
            var kancelaija = new KancelarijaSelectListaDto(_kancelarijaAppService);

            var listaKancelarija = kancelaija.ListaKancelarija.ToList();

            SelectList selectKan = new SelectList(listaKancelarija, "id", "Opis");
            

            return selectKan;



        }
    }
}
