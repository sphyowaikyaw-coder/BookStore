using DAO.DAO;
using Dependency;
using Service.Business_Model;
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

        public async Task<BM_TbUser> GetUserByEmail(string email)
        {
            try
            {
                TbUser tbUser = await userDAO.GetUserByEmail(email);
                return new BM_TbUser
                {
                    UserId = tbUser.UserId,
                    UserName = tbUser.UserName,
                    Email = tbUser.Email,
                    Password = tbUser.Password,
                    IsActive = tbUser.IsActive,
                    IsBlock = tbUser.IsBlock,
                    IsDelete = tbUser.IsDelete
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting user by email: {ex.Message}");
                return null;
            }
        }
    }
}
