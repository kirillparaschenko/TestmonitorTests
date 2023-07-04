using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestmonitorTests.Models
{
    public class UserBuilder
    {
        private User user;
        public UserBuilder()
        {
            user = new User();
        }

        public UserBuilder SetUsername(string userName)
        {
            user.Username = userName;
            return this;
        }
        public UserBuilder SetPassword(string password)
        {
            user.Password = password;
            return this;
        }

        public User Build()
        {
            return user;
        }
    }
}
