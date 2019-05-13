using System;
using System.Collections.Generic;
using System.Text;
using Abp.Application.Services.Dto;

namespace BoilerPlate.OsobaUredjajAppService.Dto
{
    public class KoriscenjeUredjajajDto : EntityDto
    {

        public IList<OsobaUredjajGetDto> Koriscenja = new List<OsobaUredjajGetDto>();
    }
}
