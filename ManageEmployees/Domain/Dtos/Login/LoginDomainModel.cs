using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Dtos.Login
{
    public class LoginDomainModel
    {
        [Required(ErrorMessage = "Login é um campo obrigatório")]
        [StringLength(50, ErrorMessage = "Login deve ter no máximo {1} caracteres.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Senha é um campo obrigatório")]
        [StringLength(50, ErrorMessage = "Senha deve ter no máximo {1} caracteres.")]
        public string Password { get; set; }
    }
}
