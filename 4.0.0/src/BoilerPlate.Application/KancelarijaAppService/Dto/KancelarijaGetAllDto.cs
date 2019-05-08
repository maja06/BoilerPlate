using System;
using System.Collections.Generic;
using System.Text;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using BoilerPlate.Models;

namespace BoilerPlate.KancelariajAppService.Dto
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
