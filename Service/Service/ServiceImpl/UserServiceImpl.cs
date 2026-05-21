using DAO.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service.ServiceImpl
{
    public class UserServiceImpl(UserDAO userDAO) : UserService
    {
        public async Task<bool> CreateUser(string username, string email, string password)
        {
            try
            {
                return await userDAO.CreateUser(username, email, password);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating user: {ex.Message}");
                return false;
            }
        }
        public async Task<bool> CheckUser(string email, string password)
        {
            try
            {
                return await userDAO.CheckUser(email, password);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error checking user: {ex.Message}");
                return false;
            }
        }
    }
}
