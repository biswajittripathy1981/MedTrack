using Medtrack.DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedTrack.BL
{
    public interface IMedService
    {
        void Add(Medicine medicine);
        void Update(Medicine medicine);
        IEnumerable<Medicine> GetAll();
        Medicine Get(int id);
    }
}
