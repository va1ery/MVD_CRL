using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace MVD_CRL.Models
{
    public partial class Сотрудники
    {
        public Сотрудники()
        {
            Преступники = new HashSet<Преступники>();
        }

        [Key]
        [Column("Код_сотрудника")]
        public int КодСотрудника { get; set; }
        [Column("ФИО")]
        [StringLength(50)]
        public string Фио { get; set; }
        public int? Возраст { get; set; }
        [StringLength(50)]
        public string Пол { get; set; }
        [StringLength(50)]
        public string Адрес { get; set; }
        [StringLength(50)]
        public string Телефон { get; set; }
        [Column("Паспортные_данные")]
        [StringLength(50)]
        public string ПаспортныеДанные { get; set; }
        [Column("Код_должности")]
        public int КодДолжности { get; set; }
        [Column("Код_звания")]
        public int КодЗвания { get; set; }

        [ForeignKey(nameof(КодДолжности))]
        [InverseProperty(nameof(Должности.Сотрудники))]
        public virtual Должности КодДолжностиNavigation { get; set; }
        [ForeignKey(nameof(КодЗвания))]
        [InverseProperty(nameof(Звания.Сотрудники))]
        public virtual Звания КодЗванияNavigation { get; set; }
        [InverseProperty("КодСотрудникаNavigation")]
        public virtual ICollection<Преступники> Преступники { get; set; }
    }
}
