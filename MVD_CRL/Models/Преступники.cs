using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace MVD_CRL.Models
{
    public partial class Преступники
    {
        [Key]
        [Column("Номер_дела")]
        public int НомерДела { get; set; }
        [Column("ФИО")]
        [StringLength(50)]
        public string Фио { get; set; }
        [Column("Дата_рождения", TypeName = "date")]
        public DateTime? ДатаРождения { get; set; }
        [StringLength(50)]
        public string Пол { get; set; }
        [StringLength(50)]
        public string Адрес { get; set; }
        [StringLength(50)]
        public string Состояние { get; set; }
        [Column("Код_сотрудника")]
        public int КодСотрудника { get; set; }
        [Column("Код_пострадавшего")]
        public int КодПострадавшего { get; set; }
        [Column("Код_вида_преступления")]
        public int КодВидаПреступления { get; set; }

        [ForeignKey(nameof(КодВидаПреступления))]
        [InverseProperty(nameof(ВидыПреступлений.Преступники))]
        public virtual ВидыПреступлений КодВидаПреступленияNavigation { get; set; }
        [ForeignKey(nameof(КодПострадавшего))]
        [InverseProperty(nameof(Пострадавшие.Преступники))]
        public virtual Пострадавшие КодПострадавшегоNavigation { get; set; }
        [ForeignKey(nameof(КодСотрудника))]
        [InverseProperty(nameof(Сотрудники.Преступники))]
        public virtual Сотрудники КодСотрудникаNavigation { get; set; }
    }
}
