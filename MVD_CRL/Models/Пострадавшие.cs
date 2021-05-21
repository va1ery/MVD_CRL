using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace MVD_CRL.Models
{
    public partial class Пострадавшие
    {
        public Пострадавшие()
        {
            Преступники = new HashSet<Преступники>();
        }

        [Key]
        [Column("Код_пострадавшего")]
        public int КодПострадавшего { get; set; }
        [Column("ФИО")]
        [StringLength(50)]
        public string Фио { get; set; }
        [Column("Дата_рождения", TypeName = "date")]
        public DateTime? ДатаРождения { get; set; }
        [StringLength(50)]
        public string Пол { get; set; }
        [StringLength(50)]
        public string Адрес { get; set; }

        [InverseProperty("КодПострадавшегоNavigation")]
        public virtual ICollection<Преступники> Преступники { get; set; }
    }
}
