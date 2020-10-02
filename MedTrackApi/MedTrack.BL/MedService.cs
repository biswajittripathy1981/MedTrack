using Medtrack.DAL;
using System;
using System.Collections.Generic;

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

        public IEnumerable<Medicine> GetAll()
        {
            return _repository.GetAll();
        }

        public void Update(Medicine medicine)
        {
            _repository.Update(medicine);
            _repository.Save();
        }
    }
}
