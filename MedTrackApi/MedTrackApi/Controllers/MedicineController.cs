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
            return Ok(true);
        }

        [HttpPut]
        public IActionResult Put(Medicine medicine)
        {
            _medService.Update(medicine);
            return Ok(true);
        }
        [HttpGet]
        [Route("/medicine/{id}")]
        public Medicine GetById(int id)
        {
            return _medService.Get(id);
        }
        [HttpGet]
        public IEnumerable<MedicineVM> GetAll()
        {
            return _medService.GetAll();
        }
        
    }
}
