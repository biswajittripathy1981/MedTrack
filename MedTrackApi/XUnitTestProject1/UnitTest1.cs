using Medtrack.DAL;
using MedTrack.BL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Xunit;

namespace MedTrack.Test
{
    public class UnitTest1
    {
        private MedService service;
        public UnitTest1()
        {
            service = GetMedService();
        }
        [Fact]
        public void AddMedicine()
        {
            //MedService service = GetMedService();
            var medicine = new Medicine()
            {
                Name = "Test",
                Brand = "Brand1",
                Price = 30,
                Quantity = 30,
                ExpiryDate = new DateTime(2020, 09, 20),
                Notes = "category1"
            };
            service.Add(medicine);
            Assert.Equal(6,service.GetAll().Count());
        }

        private static MedService GetMedService()
        {
            var options = new DbContextOptionsBuilder<MedDbContext>()
                            .UseInMemoryDatabase(databaseName: "MedDB")
                            .Options;
            var context = new MedDbContext(options);
            var repo = new MedicineRepository(context);
            var service = new MedService(repo);
            return service;
        }

        [Fact]
        public void UpdateMedicine()
        {
            //MedService service = GetMedService();
            //AddMedicine();
            var medicine = new Medicine()
            {
                Id = 5,
                Name = "Test211",
                Brand = "Brand211",
                Price = 30,
                Quantity = 30,
                ExpiryDate = new DateTime(2020, 09, 20),
                Notes = "category211"
            };
            service.Update(medicine);
            Assert.True(service.Get(5).Name == "Test2");
        }
    }
}
