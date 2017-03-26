using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Core.Service.Impl
{
    class UserServiceImpl : IUserService
    {
        public void Create(string email, string password)
        { 
            var context = new Entities();
            context.Users.Add(new User { email = email, password = password });
            context.SaveChanges();

        }

        public User FindByEmail(string email)
        {
            var context = new Entities();            
                var query = from user in context.Users
                            where user.email == email
                            select user;

                return query.FirstOrDefault();
            
        }

        public User FindByEmailAndPassword(string email, string password)
        {
            var context = new Entities();
            var query = from user in context.Users
                        where user.email == email &&
                        user.password == password
                        select user;

            return query.FirstOrDefault();
        }
    }
}
