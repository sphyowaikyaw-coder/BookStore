using Service.Business_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service
{
    public interface PurchaseService
    {
        public Task<List<BM_TbPurchase>> GetAllPurchases();
        public Task<bool> CreatePurchase(List<BM_Save_Purchase> purchaseList);
            public Task<bool> UpdatePurchase(BM_TbPurchase purchase);
            public Task<bool> DeletePurchase(int id);
            public Task<List<BM_TbPurchase>> SearchPurchases(string keyword);
    }
}
