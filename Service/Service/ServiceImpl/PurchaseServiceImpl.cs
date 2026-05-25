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
    public class PurchaseServiceImpl(PurchaseDAO purchaseDAO, UserService userService) : PurchaseService
    {
        public async Task<bool> CreatePurchase(List<BM_Save_Purchase> purchaseList)
        {
            try
            {
                foreach(BM_Save_Purchase purchase in purchaseList)
                {
                    BM_TbUser user = await userService.GetUserByEmail(purchase.Email);
                    TbPurchase tbPurchase = new TbPurchase
                    {
                        BookId = purchase.BookId,
                        UserId = user.UserId,
                        DateTime = DateTime.Now,

                    };
                    await purchaseDAO.CreatePurchase(tbPurchase);
                }
                return true;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public Task<bool> DeletePurchase(int id)
        {
            throw new NotImplementedException();
        }
        public async Task<List<BM_TbPurchase>> GetAllPurchases()
        {
            try
            {
                List<TbPurchase> purchases = await purchaseDAO.GetAllPurchases();
                List<BM_TbPurchase> bmPurchases = purchases.Select(purchase => new BM_TbPurchase
                {
                    PurchaseId = purchase.PurchaseId,
                    PurchaseDate = purchase.DateTime,
                    Book = purchase.Book != null ? new BM_TbBook
                    {
                        BookId = purchase.Book.BookId,
                        BookName = purchase.Book.BookName,
                        BookAuthur = purchase.Book.BookAuthur,
                        Price = purchase.Book.Price
                    } : null,
                    User = purchase.User != null ? new BM_TbUser
                    {
                        UserId = purchase.User.UserId,
                        UserName = purchase.User.UserName,
                        Email = purchase.User.Email
                    } : null,
                }).ToList();
                return bmPurchases;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public Task<List<BM_TbPurchase>> SearchPurchases(string keyword)
        {
            throw new NotImplementedException();
        }
        public Task<bool> UpdatePurchase(BM_TbPurchase purchase)
        {
            throw new NotImplementedException();
        }
    }
}
