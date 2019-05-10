using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BoilerPlate.KancelariajAppService;
using BoilerPlate.OsobaAppService.Dto;
using Microsoft.AspNetCore.Mvc;

namespace BoilerPlate.Web.Controllers
{
    public class OsobaController : BoilerPlateControllerBase
    {
        private readonly IOsobaAppService _osobaAppService;

        public OsobaController(IOsobaAppService osobaAppService)
        {
            _osobaAppService = osobaAppService;
        }

        public IActionResult Index()
        {
            var output = _osobaAppService.Get();
            var model = ObjectMapper.Map<OsobaGetAllDto>(output);
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
    }
}
