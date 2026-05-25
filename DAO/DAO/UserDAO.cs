using Dependency;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.DAO
{
    public interface UserDAO
    {
        public Task<TbUser> GetUserByEmail(string email);
        public Task<bool> CreateUser(string username, string email,string password);

        public Task<bool> CheckUser(string email, string password);
    }
}
