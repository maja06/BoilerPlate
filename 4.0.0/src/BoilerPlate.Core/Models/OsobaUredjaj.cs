using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Abp.Domain.Entities;

namespace BoilerPlate.Models
{
    public class OsobaUredjaj : Entity
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long OsobaUredjajId { get; set; }
        public DateTime VrijemeOd { get; set; }
        public DateTime? VrijemeDo { get; set; }


        public long UredjajId { get; set; }
        [ForeignKey("UredjajId")]
        public Uredjaj Uredjaj { get; set; }

        public long OsobaId { get; set; }
        [ForeignKey("OsobaId")]
        public Osoba Osoba { get; set; }
    }
}
