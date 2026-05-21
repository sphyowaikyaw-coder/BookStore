using DAO.DAO;
using Dependency;
using Service.Business_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service.ServiceImpl
{
    public class BookServiceImpl(BookDAO bookDAO) : BookService
    {
        public async Task<List<BM_TbBook>> GetAllBooks()
        {
            try
            {
                List<TbBook> books = await bookDAO.GetAllBooks();
                List<BM_TbBook> bmBooks = books.Select(book => new BM_TbBook
                {
                    BookId = book.BookId,
                    BookName = book.BookName,
                    BookAuthur = book.BookAuthur,
                    Price = book.Price,
                    ReleaveDate = book.ReleaveDate,
                    Description = book.Description,
                    BookCover = book.BookCover,
                    IsDelete = book.IsDelete
                }).ToList();
                return bmBooks;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> CreateBook(BM_TbBook bmBook)
        {
            try
            {
                TbBook book = new TbBook
                {

                    BookName = bmBook.BookName,
                    BookAuthur = bmBook.BookAuthur,
                    Price = bmBook.Price,
                    ReleaveDate = bmBook.ReleaveDate,
                    Description = bmBook.Description,
                    BookCover = bmBook.BookCover,
                    IsDelete = false
                };
                return await bookDAO.CreateBook(book);
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
                return await bookDAO.DeleteBook(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<bool> UpdateBook(BM_TbBook bmBook)
        {
            try
            {
                TbBook book = new TbBook
                {
                    BookId = bmBook.BookId,
                    BookName = bmBook.BookName,
                    BookAuthur = bmBook.BookAuthur,
                    Price = bmBook.Price,
                    ReleaveDate = bmBook.ReleaveDate,
                    Description = bmBook.Description,
                    BookCover = bmBook.BookCover,
                    IsDelete = bmBook.IsDelete
                };
                return await bookDAO.UpdateBook(book);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<BM_TbBook>> SearchBooks(string keyword)
        {
            try
            {
                List<TbBook> books = await bookDAO.SearchBooks(keyword);
                List<BM_TbBook> bmBooks = new List<BM_TbBook>();
                foreach (TbBook? book in books) {
                    if(book != null)
                    {
                        BM_TbBook bmBook = new BM_TbBook
                        {
                            BookId = book.BookId,
                            BookName = book.BookName,
                            BookAuthur = book.BookAuthur,
                            Price = book.Price,
                            ReleaveDate = book.ReleaveDate,
                            Description = book.Description,
                            BookCover = book.BookCover,
                            IsDelete = book.IsDelete
                        };
                        bmBooks.Add(bmBook);
                    }
                   
                }
                return bmBooks;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
