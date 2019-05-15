using System.Collections.Generic;
using Abp.AutoMapper;
using BoilerPlate.Models;

namespace BoilerPlate.KancelarijaAppService.Dto
{
    [AutoMap(typeof(Kancelarija))]
    public class KancelarijaGetAllDto
    {
        public IReadOnlyList<KancelarijaGetDto> ListaKancelarija { get; }

        public KancelarijaGetAllDto(IReadOnlyList<KancelarijaGetDto> listaKancelarija)
        {
            ListaKancelarija = listaKancelarija;
        }
    }
}
