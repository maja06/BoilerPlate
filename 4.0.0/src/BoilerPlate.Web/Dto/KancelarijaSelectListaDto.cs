﻿using System.Collections.Generic;
using System.Linq;
using BoilerPlate.KancelarijaAppService;
using BoilerPlate.KancelarijaAppService.Dto;

namespace BoilerPlate.Web.Dto
{
    public class KancelarijaSelectListaDto
    {
        public List<KancelarijaGetDto> ListaKancelarija { get; set; }

        public KancelarijaSelectListaDto(IKancelarijaAppService kancelarijaAppService)
        {
            ListaKancelarija = kancelarijaAppService.Get().ToList();
        }
    }
}
