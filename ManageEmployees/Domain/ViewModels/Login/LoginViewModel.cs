using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.ViewModels.Login
{
    public class LoginViewModel
    {
        [Display(Name = "Usuário")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string UserName { get; set; }

        [Display(Name = "Senha")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string Password { get; set; }
    }
}

