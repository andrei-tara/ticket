using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Core.Service
{
    public interface IUserService
    {
        User FindByEmail(String email);
        User FindByEmailAndPassword(String email, String password);
        void Create(string email, string password);
    }
}
