using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Dtos.Employee
{
    public class EmployeeCreateDomainModel
    {
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
