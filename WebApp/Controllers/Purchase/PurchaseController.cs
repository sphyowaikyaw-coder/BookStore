using Microsoft.AspNetCore.Mvc;
using Service.Business_Model;
using Service.Service;
using System.Text.Json;
using WebApp.View_Model;

namespace WebApp.Controllers.Purchase
{
    public class PurchaseController(PurchaseService purchaseService) : Controller
    {
        public async Task<IActionResult> PurchaseList()
        {
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
                Book = null,
                Purchase = vmPurchases
            };
            return View("Views/Book/BootStoreWeb.cshtml", vM_Book_Purchase);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePurchase(List<VM_Save_Purchase> vM_Save_Purchases)
        {
            
            Console.WriteLine("vm save purchse" + JsonSerializer.Serialize(vM_Save_Purchases));
            bool isCreated = await purchaseService.CreatePurchase(vM_Save_Purchases.Select(x => new BM_Save_Purchase
            {
                BookId = x.BookId,
                Email = x.Email
            }).ToList());

            if (isCreated)
            {
                return RedirectToAction("BookList", "Book");
            }
            else
            {
                ViewBag.ErrorMessage = "Failed to create purchase. Please try again.";
                return RedirectToAction("BookList", "Book");
            }
        }
    }
}
