using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace CourseWork.Models
{
    public class Client
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        public ICollection<Animal> Animals { get; set; }

        [Required(ErrorMessage = "Введите имя клиента")]
        [Display(Name = "Имя клиента")]
        public string FullName { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Номер телефона")]
        public string Phone { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Дата рождения")]
        public DateTime? BirthDate { get; set; }

        public Client()
        {
            Animals = new List<Animal>();
        }

        public Client(string fullName, string phone, DateTime? birthDate)
        {
            Animals = new List<Animal>();
            FullName = fullName;
            Phone = phone;
            BirthDate = birthDate;
        }
    }
}
