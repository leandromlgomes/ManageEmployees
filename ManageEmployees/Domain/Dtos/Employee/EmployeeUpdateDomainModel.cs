using System.ComponentModel.DataAnnotations;

namespace Domain.Dtos.Employee
{
    public class EmployeeUpdateDomainModel
    {
        [Required(ErrorMessage = "Id é um campo obrigatório")]
        public long Id { get; set; }

        [Required(ErrorMessage = "Nome é um campo obrigatório")]
        [StringLength(50, ErrorMessage = "Nome deve ter no máximo {1} caracteres.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Sobrenome é um campo obrigatório")]
        [StringLength(150, ErrorMessage = "Sobrenome deve ter no máximo {1} caracteres.")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Email é um campo obrigatório")]
        [StringLength(200, ErrorMessage = "Email deve ter no máximo {1} caracteres.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Número de chapa é um campo obrigatório")]
        [StringLength(150, ErrorMessage = "Número de chapa deve ter no máximo {1} caracteres.")]
        public string EmployeeNumber { get; set; }

        [StringLength(50, ErrorMessage = "Telefone deve ter no máximo {1} caracteres.")]
        public string Phone { get; set; }

        [StringLength(50, ErrorMessage = "Senha deve ter no máximo {1} caracteres.")]
        public string Password { get; set; }

        [StringLength(50, ErrorMessage = "Nome do Lider deve ter no máximo {1} caracteres.")]
        public string LeaderName { get; set; }
    }
}
