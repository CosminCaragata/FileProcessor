using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace _2FAProject
{
    public class DomainMock
    {
        public List<User> Users = new List<User> {
            new User
            {
                Username = "cosmin0103@yahoo.com",
                Password = "mypass"
            },
            new User
            {
                Username = "andreea.bagacean@btrl.ro",
                Password = "mypass"
            },
           new User
            {
                Username = "andreea.bagacean@btrl.ro",
                Password = "mypass"
            },
           new User
            {
                Username = "Dragos.Camara@btrl.ro",
                Password = "mypass"
            },
           new User
            {
                Username = "mirela.baidoc@btrl.ro",
                Password = "mypass"
            },
           new User
           {
               Username = "sebastian.draghici@btrl.ro",
               Password = "mypass"
           }
        };

        public List<AuthenticationToken> Tokens = new List<AuthenticationToken>();

        public List<User> GetUsers()
        {
            return Users;
        }

        public bool UserExists(string user)
        {
            return Users.Any(x => x.Username == user);
        }

        public string AddTokenToUser(string userName)
        {
            var rand = new Random();
            //remove previous tokens
            Tokens.RemoveAll(x => x.username == userName);
            string token = rand.Next(10000).ToString();
            Tokens.Add(new AuthenticationToken()
            {
                username = userName,
                CreatedOn = DateTime.Now,
                PinToken = token
            });
            return token;
        }

        public bool LoginUser(string username, string password, string token)
        {
            //var md5 = new MD5CryptoServiceProvider();
            //var hashedPassword = md5.ComputeHash(password);
            return Tokens.Any(x => x.username == username &&                                 
                                  x.PinToken == token &&
                                  (DateTime.Now - x.CreatedOn).Minutes < 5) &&//a token is valid for 5 minutes
                  Users.Any(x=>x.Username == username);
            
                            //password should be verified, and be kept hashed in the database.
        }

    }


}
