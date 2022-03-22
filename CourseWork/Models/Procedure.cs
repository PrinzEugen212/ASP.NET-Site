using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace CourseWork.Models
{
    public class Procedure
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Введите имя")]
        [Display(Name = "Имя")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Введите цену")]
        [Display(Name = "Цена")]
        [Range(0, float.MaxValue)]
        public float Cost { get; set; }

        public ICollection<Visit> Visits { get; set; }

        public Procedure()
        {

        }

        public Procedure(string name, float cost)
        {
            Name = name;
            Cost = cost;
        }
    }
}
