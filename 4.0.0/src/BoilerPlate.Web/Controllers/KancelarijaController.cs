using BoilerPlate.KancelariajAppService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BoilerPlate.KancelariajAppService.Dto;
using Microsoft.AspNetCore.Mvc;

namespace BoilerPlate.Web.Controllers
{
    public class KancelarijaController : BoilerPlateControllerBase
    {

        private readonly IKancelarijaAppService _kancelarijaAppSevice;

        public KancelarijaController(IKancelarijaAppService kancelarijaAppService)
        {
            _kancelarijaAppSevice = kancelarijaAppService;
        }

        public IActionResult Index()
        {
            var output = _kancelarijaAppSevice.Get();
            var model = new KancelarijaGetAllDto(output);
            return View(model);
        }
    }
}
