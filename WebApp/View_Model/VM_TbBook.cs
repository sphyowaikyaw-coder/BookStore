namespace WebApp.View_Model
{
    public class VM_TbBook
    {
        public int BookId { get; set; }
        public string? BookName { get; set; }

        public string? BookAuthur { get; set; }

        public decimal? Price { get; set; }

        public DateTime? ReleaveDate { get; set; }

        public string? Description { get; set; }

        public IFormFile? BookCoverFile { get; set; }
        public string? BookCover { get; set; }

        public bool? IsDelete { get; set; }
    }
}
