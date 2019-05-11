using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Abp.Domain.Entities;

namespace BoilerPlate.Models
{
  
    public class Uredjaj : Entity
    {
        public string UredjajIme { get; set; }

        public int? OsobaId { get; set; }
        [ForeignKey("OsobaId")]
        public Osoba Osoba { get; set; }

        public IList<OsobaUredjaj> ListaKoriscenje { get; set; }


    }
}
