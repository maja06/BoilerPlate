using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using BoilerPlate.Models;

namespace BoilerPlate.OsobaAppService.Dto
{
    [AutoMap(typeof(Uredjaj))]
     public class UredjajGetDto : EntityDto
    {
        public string UredjajIme { get; set; }
    }
}
