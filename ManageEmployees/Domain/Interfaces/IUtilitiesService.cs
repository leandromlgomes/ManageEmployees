using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces
{
    public interface IUtilitiesService
    {
        string CreateMD5Hash(string input);
        bool ValidateEmail(string email);
        string GenerateJSONWebToken();
    }
}
