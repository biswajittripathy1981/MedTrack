using Medtrack.DAL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MedTrack.BL
{
    public class MedService : IMedService
    {
        private IMedicineRepository _repository;
        public MedService(IMedicineRepository repo)
        {
            _repository = repo;
        }
        public void Add(Medicine medicine)
        {
            _repository.Add(medicine);
            _repository.Save();
        }

        public Medicine Get(int id)
        {
            return _repository.Get(id);
        }

        public IEnumerable<MedicineVM> GetAll()
        {
            return _repository.GetAll().Select(item => new MedicineVM
            {
                Id = item.Id,
                Brand = item.Brand,
                Name = item.Name,
                Notes = item.Notes,
                Price = item.Price,
                ExpiryDate = item.ExpiryDate,
                Quantity = item.Quantity,
                Code = GetColorCode(item)
            })
            .ToArray();
        }

        public void Update(Medicine medicine)
        {
            _repository.Update(medicine);
            _repository.Save();
        }
        private ColorCode GetColorCode(Medicine med)
        {
            if ((med.ExpiryDate - DateTime.Today).TotalDays < 30)
            {
                return ColorCode.Red;
            }
            if (med.Quantity < 10)
            {
                return ColorCode.Yellow;
            }
            return ColorCode.Default;
        }
    }
}
