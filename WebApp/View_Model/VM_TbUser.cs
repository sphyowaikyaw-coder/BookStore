namespace WebApp.View_Model
{
    public class VM_TbUser
    {
        public int UserId { get; set; }

        public string? UserName { get; set; }

        public string? Email { get; set; }

        public string? Password { get; set; }

        public bool? IsActive { get; set; }

        public bool? IsBlock { get; set; }

        public bool? IsDelete { get; set; }
    }
}
