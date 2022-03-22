using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace CourseWork.Models
{
    public class Visit
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        public Animal Animal { get; set; }

        public Employee Employee { get; set; }

        public Employee HelperEmployee { get; set; }

        public Client Client { get; set; }

        public ICollection<Procedure> Procedures { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int AnimalId { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int EmployeeId { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int? HelperEmployeeId { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int ClientId { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Дата приёма")]
        public DateTime Date { get; set; }

        [Display(Name = "Диагноз")]
        public string Diagnosis { get; set; }

        [Display(Name = "Назначение")]
        public string Assignment { get; set; }

        [Display(Name = "Общая стоимость")]
        public float TotalCost { get; set; }

        public Visit()
        {

        }

        public Visit(int iDAnimal, int iDEmployee, int? iDHelperEmployee, int iDClient, DateTime date, string diagnosis, string assignment, float cost)
        {
            AnimalId = iDAnimal;
            EmployeeId = iDEmployee;
            HelperEmployeeId = iDHelperEmployee;
            ClientId = iDClient;
            Date = date;
            Diagnosis = diagnosis;
            Assignment = assignment;
            TotalCost = cost;
        }
    }
}
