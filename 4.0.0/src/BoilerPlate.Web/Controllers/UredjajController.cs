using System.Collections.Generic;
using System.Linq;
using BoilerPlate.OsobaAppService.Dto;
using BoilerPlate.OsobaUredjajAppService;
using BoilerPlate.OsobaUredjajAppService.Dto;
using BoilerPlate.UredjajAppService;
using BoilerPlate.UredjajAppService.Dto;
using BoilerPlate.Web.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BoilerPlate.Web.Controllers
{
    public class UredjajController : BoilerPlateControllerBase
    {
        private readonly IUredjajAppService _uredjajAppService;
        private readonly IOsobaAppService _osobaAppService;
        private readonly IOsobaUredjajAppService _osobaUredjajAppService;


        public UredjajController(IUredjajAppService uredjajAppService, IOsobaAppService osobaAppService, IOsobaUredjajAppService osobaUredjajAppService)
        {
            _uredjajAppService = uredjajAppService;
            _osobaAppService = osobaAppService;
            _osobaUredjajAppService = osobaUredjajAppService;
        }


        public IActionResult Index()
        {
            var sviUredjaji = _uredjajAppService.Get();
            var model = new UredjajGetAllDto(sviUredjaji);
            return View(model);
        }

        [HttpGet]
        public IActionResult Uredjaj(int? id)
        {
            UredjajGetDto output = null;
            if (id.HasValue)
            {
                output = _uredjajAppService.GetById(id.Value);
            }

            return View(output);
        }

        
        public IActionResult Add()
        {
            var listaOsoba = SelectOsobu();
            ViewData["SelectOsobu"] = listaOsoba;
            return View();
        }

       
        [HttpPost]
        public IActionResult Add(UredjajPostDto input)
        {
            var inserted = _uredjajAppService.Insert(input);
            var uredjajId = inserted;
            var osobaId = input.OsobaId;
            if (osobaId != null) _osobaUredjajAppService.AddKoriscenje(uredjajId, (int) osobaId);
            return RedirectToAction("Index");

        }

        public IActionResult Update(int id)
        {
            var uredjaj = _uredjajAppService.GetUredjaj(id);
            UredjajPutDto newUredjaj = new UredjajPutDto
            {
                UredjajIme = uredjaj.UredjajIme,
                OsobaId =  uredjaj.OsobaId


            };

            var listaOsoba = SelectOsobu();
            ViewData["SelectOsobu"] = listaOsoba;
            return View(newUredjaj);
        }

        [HttpPost]
        public IActionResult Update(int id, UredjajPutDto input)
        {
            if (input.OsobaId != null)
            {
                _uredjajAppService.IzmijeniKorisnika((int) input.OsobaId, id);
                _osobaUredjajAppService.EndKoriscenje(id);
                _osobaUredjajAppService.AddKoriscenje(id, (int) input.OsobaId);
            }

            _uredjajAppService.Update(id, input);
            return RedirectToAction("Index");


              
        }

        public IActionResult Delete(int? id)
        {
            UredjajGetDto output = null;
            if (id.HasValue)
            {
                output = _uredjajAppService.GetById(id.Value);
            }

            return View(output);

        }

        [HttpPost, ActionName("Delete")]
        public IActionResult Delete(int id)
        {
            _uredjajAppService.Delete(id);
            return RedirectToAction("Index");
        }

        public SelectList SelectOsobu()
        {
            var osoba = new OsobaSelectListaDto(_osobaAppService);

            var listaOsoba = osoba.ListaOsoba.ToList();

            var selectOsobu = listaOsoba.Select(x => new
            {
                x.Id,
                Ime = x.Ime + "" + x.Prezime
            });

            SelectList selectOsobe = new SelectList(selectOsobu, "Id", "Ime");

            return selectOsobe;
        }

        public IActionResult Istorija(int id)
        {
            var koriscenje = _osobaUredjajAppService.SvePoUredjaju(id);
            ViewData["ListaKoriscenje"] = koriscenje;
            KoriscenjeUredjajajDto lista = new KoriscenjeUredjajajDto();
            lista.Koriscenja = ObjectMapper.Map<List<OsobaUredjajGetDto>>(koriscenje);
            return View(lista);
        }

      




    }
}
