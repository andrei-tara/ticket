using Core.Service;
using Core.Util;
using Model;
using System;


namespace Core.Manager
{
    public class UserManager
    {
        
        private static UserManager _instance = new UserManager();
        private UserManager() { }
        public static UserManager Instance => _instance;

        public User Login(String email, String password)
        {
            return ServiceProvider.UserService.FindByEmailAndPassword(email, TextUtil.MD5Hash(password));
        }

        public User FindOrCreate(String email, String password)
        {
            var user = ServiceProvider.UserService.FindByEmailAndPassword(email, TextUtil.MD5Hash(password));
            if(user != null)
            {
                return user;
            }

            ServiceProvider.UserService.Create(email, TextUtil.MD5Hash(password));
            return ServiceProvider.UserService.FindByEmailAndPassword(email, TextUtil.MD5Hash(password));
        }
    }
}
