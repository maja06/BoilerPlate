using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Abp.AutoMapper;
using BoilerPlate.Models;

namespace BoilerPlate.OsobaUredjajAppService.Dto
{
    [AutoMap(typeof(OsobaUredjaj))]
    public class OsobaUredjajGetDto
    {
        public string Osoba { get; set; }
        public string Uredjaj { get; set; }
        public DateTime VrijemeOd { get; set; }
        public DateTime? VrijemeDo { get; set; }
    }
}
