using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace MVD_CRL.Models
{
    public partial class Должности
    {
        public Должности()
        {
            Сотрудники = new HashSet<Сотрудники>();
        }

        [Key]
        [Column("Код_должности")]
        public int КодДолжности { get; set; }
        [Column("Наименование_должности")]
        [StringLength(50)]
        public string НаименованиеДолжности { get; set; }
        public int? Оклад { get; set; }
        [StringLength(50)]
        public string Обязанности { get; set; }
        [StringLength(50)]
        public string Требования { get; set; }

        [InverseProperty("КодДолжностиNavigation")]
        public virtual ICollection<Сотрудники> Сотрудники { get; set; }
    }
}
