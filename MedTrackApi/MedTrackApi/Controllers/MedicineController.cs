using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Medtrack.DAL;
using MedTrack.BL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MedTrackApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MedicineController : ControllerBase
    {
        private readonly ILogger<MedicineController> _logger;
        private readonly IMedService _medService;
        public MedicineController(ILogger<MedicineController> logger, IMedService medService)
        {
            _logger = logger;
            _medService = medService;
        }

        [HttpPost]
        public IActionResult Post(Medicine medicine)
        {
            _medService.Add(medicine);
            return Ok();
        }

        [HttpPut]
        public IActionResult Put(Medicine medicine)
        {
            _medService.Update(medicine);
            return Ok();
        }
        //[HttpGet]
        //public Medicine GetById(int id)
        //{
        //    return _medService.Get(id);
        //}
        [HttpGet]
        public IEnumerable<MedicineVM> GetAll()
        {
            var test =  _medService.GetAll().Select(item => new MedicineVM
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
            return test;
        }
        private ColorCode GetColorCode(Medicine med)
        {
            if((med.ExpiryDate - DateTime.Today).TotalDays < 30)
            {
                return ColorCode.Red;
            }
            if(med.Quantity < 10)
            {
                return ColorCode.Yellow;
            }
            return ColorCode.Default;
        }
    }
}
