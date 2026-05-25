using Microsoft.AspNetCore.Mvc;
using Service.Business_Model;
using Service.Service;
using WebApp.View_Model;

namespace WebApp.Controllers.Book
{
    public class BookController(BookService bookService, FileService fileService, PurchaseService purchaseService) : Controller
    {
        public async Task<IActionResult> BookList()
        {
            
            List<BM_TbBook> books = await bookService.GetAllBooks();
            List<VM_TbBook> vmBooks = books.Select(book => new VM_TbBook
            {
                BookId = book.BookId,
                BookName = book.BookName,
                BookAuthur = book.BookAuthur,
                Price = book.Price,
                ReleaveDate = book.ReleaveDate,
                Description = book.Description,
                BookCover = book.BookCover
            }).ToList();
            

            List<BM_TbPurchase> purchase = await purchaseService.GetAllPurchases();
            List<VM_TbPurchase> vmPurchases = purchase.Select(p => new VM_TbPurchase
            {
                PurchaseId = p.PurchaseId,
                PurchaseDate = p.PurchaseDate,
                Book = p.Book != null ? new VM_TbBook
                {
                    BookId = p.Book.BookId,
                    BookName = p.Book.BookName,
                    BookAuthur = p.Book.BookAuthur,
                    Price = p.Book.Price
                } : null,
                User = p.User != null ? new VM_TbUser
                {
                    UserId = p.User.UserId,
                    UserName = p.User.UserName,
                    Email = p.User.Email
                } : null
            }).ToList();
            VM_Book_Purchase vM_Book_Purchase = new VM_Book_Purchase
            {
                Book = vmBooks,
                Purchase = vmPurchases
            };
            return View("Views/Book/BootStoreWeb.cshtml", vM_Book_Purchase);
        }
        public async Task<IActionResult> BookLists()
        {
            List<BM_TbBook> books = await bookService.GetAllBooks();
            List<VM_TbBook> vmBooks = books.Select(book => new VM_TbBook
            {
                BookId = book.BookId,
                BookName = book.BookName,
                BookAuthur = book.BookAuthur,
                Price = book.Price,
                ReleaveDate = book.ReleaveDate,
                Description = book.Description,
                BookCover = book.BookCover
            }).ToList();
            return View("Views/Book/BookList.cshtml", vmBooks);
        }

        public IActionResult BookCreateView()
        {
            return View("Views/Book/BookCreate.cshtml");
        }

        [HttpPost]

        public async Task<IActionResult> BookCreate(VM_TbBook vmBook)
        {
            string fileUrl = await fileService.SaveFile(vmBook.BookCoverFile);

            BM_TbBook bmBook = new BM_TbBook
            {
                BookName = vmBook.BookName,
                BookAuthur = vmBook.BookAuthur,
                Price = vmBook.Price,
                ReleaveDate = vmBook.ReleaveDate,
                Description = vmBook.Description,
                BookCover = fileUrl
            };
            bool isSaveSuccess = await bookService.CreateBook(bmBook);

            return RedirectToAction("BookLists");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteBook(int id)
        {
            bool isDelete = await bookService.DeleteBook(id);
            if (isDelete)
            {
                return RedirectToAction("BookLists");
            }
            return BadRequest();
        }



        public async Task<IActionResult> BookEditView(int id)
        {
            List<BM_TbBook> books = await bookService.GetAllBooks();
            BM_TbBook bmBook = books.FirstOrDefault(book => book.BookId == id);
            if (bmBook == null)
            {
                return NotFound();
            }
            VM_TbBook vmBook = new VM_TbBook
            {
                BookId = bmBook.BookId,
                BookName = bmBook.BookName,
                BookAuthur = bmBook.BookAuthur,
                Price = bmBook.Price,
                ReleaveDate = bmBook.ReleaveDate,
                Description = bmBook.Description,
                BookCover = bmBook.BookCover
            };
            return View("Views/Book/BookEdit.cshtml", vmBook);
        }

        [HttpPost]
        public async Task<IActionResult> BookEdit(VM_TbBook vmBook)
        {
            string fileUrl = vmBook.BookCoverFile != null ? await fileService.SaveFile(vmBook.BookCoverFile) : vmBook.BookCover;
            BM_TbBook bmBook = new BM_TbBook
            {
                BookId = vmBook.BookId,
                BookName = vmBook.BookName,
                BookAuthur = vmBook.BookAuthur,
                Price = vmBook.Price,
                ReleaveDate = vmBook.ReleaveDate,
                Description = vmBook.Description,
                BookCover = fileUrl
            };
            bool isUpdateSuccess = await bookService.UpdateBook(bmBook);
            return RedirectToAction("BookLists");

        }

        [HttpGet]
        public async Task<IActionResult> SearchBooks(string keyword)
        {
            List<BM_TbBook> books = await bookService.SearchBooks(keyword);
            List<VM_TbBook> vmBooks = books.Select(book => new VM_TbBook
            {
                BookId = book.BookId,
                BookName = book.BookName,
                BookAuthur = book.BookAuthur,
                Price = book.Price,
                ReleaveDate = book.ReleaveDate,
                Description = book.Description,
                BookCover = book.BookCover
            }).ToList();
            return View("Views/Book/BookList.cshtml", vmBooks);
        }
    }
}
