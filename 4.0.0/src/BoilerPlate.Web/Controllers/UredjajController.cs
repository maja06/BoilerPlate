using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BoilerPlate.OsobaAppService.Dto;
using BoilerPlate.UredjajAppService;
using BoilerPlate.UredjajAppService.Dto;
using Microsoft.AspNetCore.Mvc;

namespace BoilerPlate.Web.Controllers
{
    public class UredjajController : BoilerPlateControllerBase
    {
        //    private readonly IUredjajAppService _uredjajAppService;
        //    private readonly IOsobaAppService _osobaAppService;

        //    public UredjajController(IUredjajAppService uredjajAppService, IOsobaAppService osobaAppService)
        //    {
        //        _uredjajAppService = uredjajAppService;
        //        _osobaAppService = osobaAppService;
        //    }

        //    public IActionResult Index()
        //    {
        //        var sviUredjaji = _uredjajAppService.Get();
        //        var model = new UredjajGetAllDto(sviUredjaji);
        //        return View(model);
        //    }

        //    public IActionResult Uredjaj(int? id)
        //    {
        //        UredjajGetDto output = null;
        //        if (id.HasValue)
        //        {
        //            output = _uredjajAppService.GetById(id.Value);
        //        }

        //        return View(output);
        //    }

        //    public IActionResult Add()
        //    {
        //        var osoba = SelectPerson();


        //    }

    }
}

