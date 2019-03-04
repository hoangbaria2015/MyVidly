using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CustomerController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ActionResult New()
        {
            var membershipType = _context.MembershipTypes.ToList();
            var viewModel = new CustomerNameViewModel()
            {
                Customer = new Customer(),
                MembershipTypes = membershipType
            };
            ViewBag.Title = "New Customer";
            return View("CustomerForm", viewModel);
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Detail(int id)
        {
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(x => x.Id == id);
            if (customer == null) return HttpNotFound();
            return View(customer);
        }
        [HttpPost]
        public ActionResult Save(Customer customer)
        {
            if(!ModelState.IsValid)
            {
                var viewModel = new CustomerNameViewModel()
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };
                return View("CustomerForm", viewModel);
            }
            if(customer.Id==0)
                _context.Customers.Add(customer);
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
                customerInDb.Name = customer.Name;
                customerInDb.Birthdate = customer.Birthdate;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Customer");
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();
            var viewModel = new CustomerNameViewModel()
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };
            ViewBag.Title = "Edit Customer";
            return View("CustomerForm",viewModel);
        }
    }
}