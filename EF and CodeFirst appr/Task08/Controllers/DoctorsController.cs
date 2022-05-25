using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task08.Models;
using Task08.Models.DTOs;
using Task08.Models.Services;
using WebApplication4.Services;

namespace Task08.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private DatabaseInterface _dbService;

        public DoctorsController(DatabaseInterface database)
        {
            _dbService = database;
        }

        [Route("GetDoctorData/{idDoctor}")]
        [HttpGet]
        public IActionResult GetDoctorData(int idDoctor)
        {
            var _getDoctors = _dbService.GetDoctorData(idDoctor);

            return Ok(_getDoctors);
        }

        [Route("DeleteDoctor/{idDoctor}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteDoctor(int idDoctor)
        {
            await _dbService.DeleteDoctor(idDoctor);


            return Ok("Doctor removed");
        }

        [Route("AddDoctor")]
        [HttpPost]
        public async Task<IActionResult> AddDoctor(AddDoctorToDatabaseRequestDto doctor)
        {
            await _dbService.AddDoctor(doctor);

            return Ok("Doctor added");
        }

        [Route("ModifyDoctor/{idDoctor}")]
        [HttpPost]
        public async Task<IActionResult> ModifyDoctor(int idDoctor, AddDoctorToDatabaseRequestDto doctor)
        {
            await _dbService.ModifyDoctor(idDoctor, doctor);
            return Ok("Doctor modified");
        }


        [Route("GetPrescription/{idPrescription}")]
        [HttpGet]
        public async Task<IActionResult> GetPrescription(int idPrescription)
        {

            return Ok(await _dbService.GetPrescription(idPrescription));
        }

    }
}
