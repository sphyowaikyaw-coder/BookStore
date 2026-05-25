using Dependency;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.DAO.DAOImpl
{
    public class PurchaseDAOImpl(BookDBContext bookDBContext) : PurchaseDAO
    {
        public async Task<bool> CreatePurchase(TbPurchase purchase)
        {
            try
            {
                await bookDBContext.TbPurchases.AddAsync(purchase);
                await bookDBContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in CreatePurchase: {ex.Message}");
                throw;

            }
        }
        public Task<bool> DeletePurchase(int id)
        {
            throw new NotImplementedException();
        }
        public async Task<List<TbPurchase>> GetAllPurchases()
        {
            try
            {
                return await bookDBContext.TbPurchases.Include(p => p.Book).Include(p => p.User).ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetAllPurchases: {ex.Message}");
                throw;
            }
            
        }
        public Task<List<TbPurchase>> SearchPurchases(string keyword)
        {
            throw new NotImplementedException();
        }
        public Task<bool> UpdatePurchase(TbPurchase purchase)
        {
            throw new NotImplementedException();
        }

    }
}
