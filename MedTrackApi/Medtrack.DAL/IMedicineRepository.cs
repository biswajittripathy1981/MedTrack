using System;
using System.Collections.Generic;
using System.Text;

namespace Medtrack.DAL
{
    public interface IMedicineRepository
    {
        void Add(Medicine medicine);
        void Update(Medicine medicine);
        IEnumerable<Medicine> GetAll();
        Medicine Get(int id);
        void Save();
    }
}
