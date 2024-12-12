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


    }
}
