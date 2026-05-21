using Dependency;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.DAO
{
    public interface BookDAO
    {
        public Task<List<TbBook>> GetAllBooks();

        public Task<bool> CreateBook(TbBook book);

        public Task<bool> UpdateBook(TbBook book);

        public Task<bool> DeleteBook(int id);

        public Task<List<TbBook>> SearchBooks(string keyword);
    }
}
