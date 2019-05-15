using System.Collections.Generic;
using Abp.AutoMapper;
using BoilerPlate.Models;

namespace BoilerPlate.OsobaAppService.Dto
{
    [AutoMap(typeof(Osoba))]
    public class OsobaGetAllDto 
    {
        public IReadOnlyList<OsobaGetDto> ListaOsoba { get; }

        public OsobaGetAllDto(IReadOnlyList<OsobaGetDto> listaOsoba)
        {
            ListaOsoba = listaOsoba;
        }

    }
}
