using LoanmSystem.DTO;
using LoanmSystem.Model;
using Microsoft.EntityFrameworkCore;

namespace LoanmSystem.Repository
{
    public class LoanRepository : ILoanRepository
    {
        private readonly DBContext _db;

        public LoanRepository(DBContext db)
        {
            _db = db;

        }

        public List<Loan> GetAllLoans()
        {
            var loans = _db.loan.ToList();
            return loans;
        }

        public Loan GetLoanById(int id)
        {
            var loan = _db.loan.Find(id);
            return loan;

        }
        public Loan AddLoan(LoanDTO loan)
        {
            var newLoan = new Model.Loan()
            {
                fname = loan.fname,
                lname = loan.lname,
                lnum = loan.lnum,
                paddress = loan.paddress,
                lamount = loan.lamount,
                ltype = loan.ltype,
                lterm = loan.lterm,
            };
            _db.loan.Add(newLoan);
            _db.SaveChanges();
            return newLoan;

        }


        public Loan UpdateLoanInfo(int id, LoanDTO loan)
        {
            /* var existingLoan = _db.loan.Find(id);

             if (existingLoan == null)
             {
                 return null;
             }
             _db.loan.Update(existingLoan);*/


            var updateLoan = new Model.Loan()
            {
                id = id,
                fname = loan.fname,
                lname = loan.lname,
                lnum = loan.lnum,
                paddress = loan.paddress,
                lamount = loan.lamount,
                ltype = loan.ltype,
                lterm = loan.lterm
            };
            /* return updateLoan;*/
            _db.Entry(updateLoan).State = EntityState.Modified;

            _db.SaveChanges();
            return _db.loan.Find(id);
        }

        public Loan DeleteLoan(int id)
        {
            var loan = _db.loan.Find(id);
            if (loan == null)
            {
                return null;
            }
            _db.loan.Remove(loan);
            _db.SaveChanges();
            return loan;
        }
    }
}
