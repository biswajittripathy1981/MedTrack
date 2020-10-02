using Microsoft.EntityFrameworkCore;
using System;

namespace Medtrack.DAL
{
    public class MedDbContext:DbContext
    {
        public DbSet<Medicine> Medicines { get; set; }
        public MedDbContext(DbContextOptions<MedDbContext> options) : base(options)
        {
            InitializeDB();
            this.SaveChanges();
        }

        private void InitializeDB()
        {
            Medicines.Add(new Medicine() { Name = "Paracetamol500", Brand = "Cipla", Price = 10, Quantity = 100, ExpiryDate = new DateTime(2021, 09, 15), Notes = "Covid category" });
            Medicines.Add(new Medicine() { Name = "Calpol650", Brand = "Cipla", Price = 30, Quantity = 100, ExpiryDate = new DateTime(2021, 10, 10), Notes = "Covid category High" });
            Medicines.Add(new Medicine() { Name = "Azythromycin", Brand = "GKLAB", Price = 30, Quantity = 80, ExpiryDate = new DateTime(2021, 07, 26), Notes = "Covid category Anti Biotic" });
            Medicines.Add(new Medicine() { Name = "Dolo650", Brand = "Lab2", Price = 40, Quantity = 70, ExpiryDate = new DateTime(2021, 04, 10), Notes = "Covid category Bodyache" });
            Medicines.Add(new Medicine() { Name = "Zyncovit", Brand = "SKLab", Price = 40, Quantity = 80, ExpiryDate = new DateTime(2021, 01, 10), Notes = "Covid category Vitamin Supplement" });
        }
    }
}
