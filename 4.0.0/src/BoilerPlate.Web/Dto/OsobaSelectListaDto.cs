using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BoilerPlate.Models;
using BoilerPlate.OsobaAppService.Dto;

namespace BoilerPlate.Web.Dto
{
    public class OsobaSelectListaDto
    {
        public List<OsobaGetDto> ListaOsoba { get; set; }

        public OsobaSelectListaDto(IOsobaAppService osobaAppService)
        {
            ListaOsoba = osobaAppService.Get().ToList();
        }
    }
}
