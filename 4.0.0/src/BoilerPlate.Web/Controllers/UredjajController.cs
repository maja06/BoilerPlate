using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BoilerPlate.OsobaAppService.Dto;
using BoilerPlate.OsobaUredjajAppService;
using BoilerPlate.UredjajAppService;
using BoilerPlate.UredjajAppService.Dto;
using BoilerPlate.Web.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis;

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

        public IActionResult Uredjaj(int? id)
        {
            UredjajDto output = null;
            if (id.HasValue)
            {
                output = _uredjajAppService.GetById(id.Value);
            }

            return View(output);
        }

        [Authorize]
        public IActionResult Add()
        {
            var listaOsoba = SelectOsobu();
            ViewData["SelectOsobu"] = listaOsoba;
            return View();
        }

        [Authorize]
        public IActionResult Add(UredjajPostDto input)
        {
            var inserted = _uredjajAppService.Insert(input);
            var uredjajId = inserted;
            var osobaId = input.OsobaId;
            _osobaUredjajAppService.AddKoriscenje(uredjajId, osobaId);
            return RedirectToAction("Index");

        }

        public IActionResult Update(int id)
        {
            var uredjaj = _uredjajAppService.GetUredjaj(id);
            UredjajPutDto newUredjaj = new UredjajPutDto
            {
                Ime = uredjaj.UredjajIme,
                OsobaId = uredjaj.OsobaId


            };

            var listaOsoba = SelectOsobu();
            ViewData["SelectOsobu"] = listaOsoba;
            return View(newUredjaj);
        }

        [HttpPost]
        public IActionResult Update(int id, UredjajPutDto input)
        {
            _uredjajAppService.IzmijeniKorisnika(input.OsobaId, id);
            _osobaUredjajAppService.EndKoriscenje(id);
            _osobaUredjajAppService.AddKoriscenje(id, input.OsobaId);
            _uredjajAppService.Update(id, input);
            return RedirectToAction("Index");


        }


        public SelectList SelectOsobu()
        {
            var osoba = new OsobaSelectListaDto(_osobaAppService);

            var listaOsoba = osoba.ListaOsoba.ToList();

            var selectOsobu = listaOsoba.Select(x => new
            {
                Id = x.Id,
                Ime = x.Ime + "" + x.Prezime
            });

            SelectList selectOsobe = new SelectList(selectOsobu, "Id", "Ime");

            return selectOsobe;
        }




    }
}
