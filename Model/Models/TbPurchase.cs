using System;
using System.Collections.Generic;

namespace Dependency;

public partial class TbPurchase
{
    public DateTime? DateTime { get; set; }

    public int? BookId { get; set; }

    public int? UserId { get; set; }

    public int PurchaseId { get; set; }

    public virtual TbBook? Book { get; set; }

    public virtual TbUser? User { get; set; }
}
