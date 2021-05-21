using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace MVD_CRL.Models
{
    [Table("Виды_преступлений")]
    public partial class ВидыПреступлений
    {
        public ВидыПреступлений()
        {
            Преступники = new HashSet<Преступники>();
        }

        [Key]
        [Column("Код_вида_преступления")]
        public int КодВидаПреступления { get; set; }
        [StringLength(50)]
        public string Наименование { get; set; }
        [StringLength(50)]
        public string Статья { get; set; }
        [StringLength(50)]
        public string Наказание { get; set; }
        public int? Срок { get; set; }

        [InverseProperty("КодВидаПреступленияNavigation")]
        public virtual ICollection<Преступники> Преступники { get; set; }
    }
}
