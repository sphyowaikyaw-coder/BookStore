using Service.Business_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service
{
    public interface BookService
    {
        public Task<List<BM_TbBook>> GetAllBooks();

        public Task<bool> CreateBook(BM_TbBook bmBook);

        public Task<bool> UpdateBook(BM_TbBook bmBook);

        public Task<bool> DeleteBook(int id);

        public Task<List<BM_TbBook>> SearchBooks(string keyword);
    }
}
