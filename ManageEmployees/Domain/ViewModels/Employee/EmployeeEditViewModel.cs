using Domain.Dtos.Employee;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.ViewModels.Employee
{
    public class EmployeeEditViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string Name { get; set; }

        [Display(Name = "Sobrenome")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string Surname { get; set; }

        [Display(Name = "E-mail")]
        [EmailAddress]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string Email { get; set; }

        [Display(Name = "Senha")]
        [EmailAddress]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string Password { get; set; }

        [Display(Name = "Número de chapa")]
        [EmailAddress]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string EmployeeNumber { get; set; }

        [Display(Name = "Nome do Líder")]
        [EmailAddress]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string LeaderName { get; set; }

        [Display(Name = "Telefone")]
        [Phone]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string Phone { get; set; }
    }
}
