using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Abp.Domain.Entities;

namespace BoilerPlate.Models
{
   public class Osoba : Entity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OsobaId { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }

        public int KancelarijaId { get; set; }

        [ForeignKey("KancelarijaId")]
        public Kancelarija Kancelarija { get; set; }

        public IList<OsobaUredjaj> ListaKoriscenje { get; set; }

        public IList<Uredjaj> ListaUredjaji { get; set; }



    }
}
