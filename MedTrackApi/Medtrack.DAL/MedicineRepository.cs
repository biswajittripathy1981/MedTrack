using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Medtrack.DAL
{
    public class MedicineRepository : IMedicineRepository
    {
        private MedDbContext _context;
        public MedicineRepository(MedDbContext context)
        {
            _context = context;
        }
        public void Add(Medicine medicine)
        {
            _context.Add(medicine);
        }

        public Medicine Get(int id)
        {
            return _context.Medicines.Where(x => x.Id == id).FirstOrDefault();
        }

        public IEnumerable<Medicine> GetAll()
        {
            return _context.Medicines;
        }

        public void Update(Medicine medicine)
        {
            _context.Medicines.Attach(medicine);
            _context.Entry(medicine).State = EntityState.Modified;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
