using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace CourseWork.Models
{
    public class Animal
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        public Client Client { get; set; }

        [Required]
        public int ClientId { get; set; }

        [Required(ErrorMessage = "Введите кличку питомца")]
        [Display(Name = "Кличка")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Введите пол питомца")]
        [Display(Name = "Пол")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Введите вид питомца")]
        [Display(Name = "Вид")]
        public string Type { get; set; }

        [Display(Name = "Порода")]
        public string Breed { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Введите дату рождения питомца")]
        [Display(Name = "Дата рождения")]
        public DateTime BirthDate { get; set; }

        [Display(Name = "Фотография")]
        public string Photo { get; set; }

        public Animal()
        {

        }
        public Animal(int clientId, string name, string gender, string type, string breed, DateTime birthDate, string photo)
        {
            ClientId = clientId;
            Name = name;
            Gender = gender;
            Type = type;
            Breed = breed;
            BirthDate = birthDate;
            Photo = photo;
        }
    }
}
