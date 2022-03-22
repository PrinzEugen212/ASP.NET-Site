using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace CourseWork.Models
{
    public class Employee
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Введите имя сотрудника")]
        [Display(Name = "Имя сотрудника")]
        public string Name { get; set; }

        [Display(Name = "Логин")]
        public string Login { get; set; }

        [DataType(DataType.Password)]
        [UIHint("Password")]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Номер телефона")]
        public string Phone { get; set; }

        [Display(Name = "Должность")]
        public string Post { get; set; }

        [Display(Name = "Специальность")]
        public string Speciality { get; set; }

        [UIHint("Boolean")]
        [Display(Name = "Администратор")]
        public bool Admin { get; set; }

        [UIHint("Boolean")]
        [Display(Name = "Помощник")]
        public bool CanHelp { get; set; }

        public Employee()
        {

        }

        public Employee(string name, string login, string password, string phone, string post, string speciality, bool admin, bool canHelp)
        {
            Name = name;
            Login = login;
            Password = password;
            Phone = phone;
            Post = post;
            Speciality = speciality;
            Admin = admin;
            CanHelp = canHelp;
        }
    }
}
