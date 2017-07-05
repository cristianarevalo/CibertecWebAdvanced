using Cibertec.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cibertec.Repositories.Northwind
{
    public interface IUserRepository
    {
        User ValidateUser(string email, string password);
    }
}
