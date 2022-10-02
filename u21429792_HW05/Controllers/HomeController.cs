using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using u21429792_HW05.Models;

namespace u21429792_HW05.Controllers
{
    public class HomeController : Controller
    {

        private DataService DataService = new DataService();

        public ActionResult Index()
        {
            BookRecordsVM vm = new BookRecordsVM();
            // using the methods from data service to get the data for the models
            vm.Authors = DataService.GetAllAuthorsDetails();
            vm.Types = DataService.GetAllTypesDetails();
            // using the model tables and the methods from data service to get the data for the models
            vm.Books = new List<BookTable>();
            List<Books> temp = DataService.GetAllBooksDetails();
            // using the model tables and the methods from data service to get the data for the models
            vm.Borrows = new List<Borrows>();
            List<Borrows> temp2 = DataService.GetAllBorrowDetails();
            
            foreach (var b in temp)
            {
                // looping through the book table to populate the rows with the linked data 
                BookTable t = new BookTable();

                t.BID = b.BID;
                t.Title = b.BTitle;
                t.Author = vm.Authors.Where(auth => auth.AID == b.AID).Select(a => a.ASurname).FirstOrDefault();
                t.Type = vm.Types.Where(type => type.TID == b.TID).Select(ty => ty.TName).FirstOrDefault();
                t.PageCount = b.BPageCount;
                t.Points = b.BPoint;
                t.Status = (vm.Borrows.Where(borrow => borrow.BID == b.BID).OrderBy(borrow => borrow.ReturnDate).Select(bo => bo.ReturnDate).LastOrDefault() == null) ? "Out" : "Available";
                
               vm.Books.Add(t);
            }

            // displaying the viewmodel variable 
            return View(vm);
        }

        // the method used when the search is submitted 
        [HttpPost]
        public ActionResult Index(string BTitle, int type, int author)
        {
            BookRecordsVM vm = new BookRecordsVM();
            vm.Books = new List<BookTable>();
            List<Books> temp = DataService.GetAllBooksDetails();
            vm.Authors = DataService.GetAllAuthorsDetails();
            vm.Types = DataService.GetAllTypesDetails();
            List<Types> temp3 = vm.Types.Where(ty => ty.TID == type);
            vm.Borrows = new List<Borrows>();
            List<Borrows> temp2 = DataService.GetAllBorrowDetails();

            foreach (var b in temp)
            {
                // looping through the book table to populate the rows with the linked data 
                BookTable t = new BookTable();

                t.BID = b.BID;
                t.Title = b.BTitle;
                t.Author = vm.Authors.Where(auth => auth.AID == b.AID).Select(a => a.AName).FirstOrDefault();
                t.Type = vm.Types.Where(type1 => type1.TID == b.TID).Select(ty => ty.TName).FirstOrDefault();
                t.PageCount = b.BPageCount;
                t.Points = b.BPoint;
                t.Status = (vm.Borrows.Where(borrow => borrow.BID == b.BID).OrderBy(borrow => borrow.ReturnDate).Select(bo => bo.ReturnDate).LastOrDefault() == null) ? "Out" : "Available";

                vm.Books.Add(t);
            }


            if(BTitle.Length != 0)
            {
              vm.Books = vm.Books.Where(b => b.Title == BTitle).ToList();
            }

            if(type.Length != 0)
            {
                vm.Books = vm.Books.Where(temp == type).ToList();
            }
            
            if(author.Length != 0)
            {
                vm.Books = vm.Books.Where(a => a.Author == author).ToList();
            }

            return View(vm);
        }

        public ActionResult BookDetails(int bookID)
        {
            OneBookVM vm = new OneBookVM();

            vm.BookDetailTables = new List<BookDetailTable>();
            // using the methods from data service to get the data for the models
            vm.Students = DataService.GetAllStudentsDetails();
            vm.Books = DataService.GetAllBooksDetails();
            vm.Borrows = DataService.GetAllBorrowDetails();
            // using the model tables and the methods from data service to get the data for the models
            List<Borrows> temp = DataService.GetAllBorrowDetails().Where(bo => bo.BID == bookID).ToList();
            // using the model tables and the methods from data service to get the data for the models

            foreach (var bo in temp)
            {
                // looping through the book table to populate the rows with the linked data 
                BookDetailTable t = new BookDetailTable();

                t.BOID = bo.BOID;
                t.TakenDate = bo.TakenDate;
                t.ReturnDate = bo.ReturnDate;
                t.Student = vm.Students.Where(stu => stu.SID == bo.SID).Select(s => s.SName).FirstOrDefault();
                t.Title = vm.Books.Where(book => book.BID == bo.BID).Select(b => b.BTitle).FirstOrDefault();
                t.Status = (vm.Borrows.Where(borrow => borrow.BID == bo.BID).OrderBy(borrow => borrow.ReturnDate).Select(bo1 => bo1.ReturnDate).LastOrDefault() == null) ? "Out" : "Available";
                t.bookID = bookID;

                vm.BookDetailTables.Add(t);
            }

            // displaying the viewmodel variable 
            return View(vm);
        }

        public ActionResult Students()
        {
            StudentsVM vm = new StudentsVM();
            vm.Students = DataService.GetAllStudentsDetails();
            List<Students> temp = DataService.GetAllStudentsDetails();

            foreach (var st in temp)
            {
                // looping through the book table to populate the rows with the linked data 
                Students s = new Students();

                s.SID = s.SID;
                s.SName = s.SName;
                s.SSurname = s.SSurname;
                s.SClass = s.SClass;
                s.SPoint = s.SPoint;

                vm.Students.Add(s);
            }

            return View(vm);
        }

        [HttpPost]
        public ActionResult Students(string SName, string class1)
        {
            StudentsVM vm = new StudentsVM();
            vm.Students = DataService.GetAllStudentsDetails();
            List<Students> temp = DataService.GetAllStudentsDetails();

            foreach (var st in temp)
            {
                // looping through the book table to populate the rows with the linked data 
                Students s = new Students();

                s.SID = s.SID;
                s.SName = s.SName;
                s.SSurname = s.SSurname;
                s.SClass = s.SClass;
                s.SPoint = s.SPoint;

                vm.Students.Add(s);
            }

            if (SName.Length != 0)
            {
                vm.Students.Where(s => s.SName.Contains(SName));
            }
            
            if (class1.Length != 0)
            {
                vm.Students.Where(c => c.SClass == class1);
            }

            return View(SName, class1);
        }

        [HttpPost]
        public ActionResult Students(int borrowID)
        {
            StudentsVM vm = new StudentsVM();
            vm.Students = DataService.GetAllStudentsDetails();
            List<Students> temp = DataService.GetAllStudentsDetails();
            vm.Borrows = DataService.GetAllBorrowDetails().Where(bo => bo.BOID == borrowID).ToList();

            foreach (var st in temp)
            {
                // looping through the book table to populate the rows with the linked data 
                Students s = new Students();

                s.SID = s.SID;
                s.SName = s.SName;
                s.SSurname = s.SSurname;
                s.SClass = s.SClass;
                s.SPoint = s.SPoint;
                s.BOID = s.BOID;

                vm.Students.Add(s);
            }

            // if (vm.Borrows.Where(bo => bo.BOID == borrowID).Select(b => b.ReturnDate).LastOrDefault() == null) "borrow" : "return";

            return View(vm);
        }
    }
}