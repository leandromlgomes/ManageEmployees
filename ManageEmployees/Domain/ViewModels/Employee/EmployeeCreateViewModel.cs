using System.ComponentModel.DataAnnotations;

namespace Domain.ViewModels.Employee
{
    public class EmployeeCreateViewModel
    {
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
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string Password { get; set; }

        [Display(Name = "Número de chapa")]        
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string EmployeeNumber { get; set; }

        [Display(Name = "Nome do Líder")]             
        public string LeaderName { get; set; }

        [Display(Name = "Telefone")]
        [Phone]        
        public string Phone { get; set; }
    }
}
