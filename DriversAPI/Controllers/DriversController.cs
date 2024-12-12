using DriversAPI.Dtos;
using DriversAPI.Models;
using DriversAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace DriversAPI.Controllers
{
    [ApiController]
    [Route("Api/[controller]")]
    public class DriversController : ControllerBase
    {


        private readonly DriverService _driverService;

        public DriversController( DriverService driverService)
        {

            this._driverService = driverService;
            
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDrivers()
        {

            var drivers = await _driverService.GetAllAsync();

            return Ok(drivers);

        }

        [HttpGet("{name}")]
        public async Task<IActionResult> GetOneDriver(string name)
        {

            var driver = await _driverService.GetDriverByName(name);


            if(driver == null)
            {

                return NotFound();

            }

            return Ok(driver);

        }

        [HttpPost]
        public async Task<IActionResult> AddNewDriver([FromBody] DriverAdd driver)
        {

            var d = await _driverService.AddNewDriver(driver);

            return CreatedAtAction("GetOneDriver", new { name = d.Name }, d);

            

        }


    }
}
