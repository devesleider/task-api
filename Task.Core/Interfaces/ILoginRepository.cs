using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Core.DTOs;
using Task.Core.Entities;

namespace Task.Core.Interfaces
{
    public interface ILoginRepository
    {
        Task<User> Login(LoginDto login);
    }
}
