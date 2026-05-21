using Dependency;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.DAO.DAOImpl
{
    public class UserDAOImpl(BookDBContext bookDBContext) : UserDAO
    {
        public async Task<bool> CreateUser(string username, string email, string password)
        {
            try
            {
                await bookDBContext.TbUsers.AddAsync(new TbUser
                {
                    UserName = username,
                    Email = email,
                    Password = password
                });
                await bookDBContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public async Task<bool> CheckUser(string email, string password)
        {
            try
            {
                TbUser? user = await bookDBContext.TbUsers.FirstOrDefaultAsync(u => u.Email == email && u.Password == password);
                return user != null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

    }
}
