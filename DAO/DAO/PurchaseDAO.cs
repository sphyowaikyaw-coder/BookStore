using Dependency;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.DAO
{
    public interface PurchaseDAO
    {
        public Task<List<TbPurchase>> GetAllPurchases();
        public Task<bool> CreatePurchase(TbPurchase purchase);
        public Task<bool> UpdatePurchase(TbPurchase purchase);
        public Task<bool> DeletePurchase(int id);
        public Task<List<TbPurchase>> SearchPurchases(string keyword);
    }
}
