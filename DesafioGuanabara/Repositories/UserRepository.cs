using DesafioGuanabara.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioGuanabara.Repositories
{
    public static class UserRepository
    {
        public static User Get(string usuario, string senha)
        {
            List<User> usuarios = new List<User>();

            usuarios.Add(new User { Id = 1, Username="marcio", Password="desafio", Role="admin" });
            usuarios.Add(new User { Id = 2, Username="kadu", Password="kadu", Role="user" });

            return usuarios.Where(x => x.Username.ToLower() == usuario.ToLower() && x.Password == senha).FirstOrDefault();
        }
    }
}
