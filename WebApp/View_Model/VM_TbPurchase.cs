namespace WebApp.View_Model
{
    public class VM_TbPurchase
    {
        public int PurchaseId { get; set; }
        public DateTime? PurchaseDate { get; set; }
        public virtual VM_TbBook? Book { get; set; }
        public virtual VM_TbUser? User { get; set; }
    }
}
