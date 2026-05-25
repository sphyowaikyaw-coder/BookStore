using Dependency;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Business_Model
{
    public class BM_TbPurchase
    {
        public int PurchaseId { get; set; }

        public DateTime? PurchaseDate { get; set; }

        public virtual BM_TbBook? Book { get; set; }

        public virtual BM_TbUser? User { get; set; }
    }
}
