using Dependency;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.DAO.DAOImpl
{
    public class BookDAOImpl(BookDBContext bookDBContext) : BookDAO
    {
        public async Task<List<TbBook>> GetAllBooks()
        {
            try
            {
                return await bookDBContext.TbBooks.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> CreateBook(TbBook book)
        {
            try
            {
                await bookDBContext.TbBooks.AddAsync(book);
                await bookDBContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> UpdateBook(TbBook book)
        {
            try
            {
                bookDBContext.TbBooks.Update(book);
                await bookDBContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteBook(int id)
        {
            try
            {
                var book = await bookDBContext.TbBooks.FindAsync(id);
                if (book == null)
                {
                    return false;
                }
                bookDBContext.TbBooks.Remove(book);
                await bookDBContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<TbBook>> SearchBooks(string keyword)
        {
            try
            {
                return await bookDBContext.TbBooks
                    .Where(b => b.BookName.Contains(keyword) || b.BookAuthur.Contains(keyword))
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
