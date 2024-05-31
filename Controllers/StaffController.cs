using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Staff_API.Model;
using Staff_API.Services;

namespace Staff_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        private readonly IStaffService _staffService;

        public StaffController(IStaffService staffService)
        {
            _staffService = staffService;
        }

        // StaffService.cs

        [HttpGet]
        public IActionResult Get([FromQuery] bool? isActive = null)
        {
            return Ok(_staffService.GetAllStaffs(isActive));
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            var staff = _staffService.GetStaffByID(id);
            if (staff == null)
            {
                return NotFound();
            }
            return Ok(staff);
        }

        [HttpPost]
        public IActionResult Post(AddUpdateStaff staffObject)
        {
            var staff = _staffService.AddStaff(staffObject);

            if (staff == null)
            {
                return BadRequest();
            }

            return Ok(new
            {
                message = "Staff Created Successfully!!!",
                id = staff!.UserId
            });
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Put([FromRoute] int id, [FromBody] AddUpdateStaff staffObject)
        {
            var staff = _staffService.UpdateStaff(id, staffObject);
            if (staff == null)
            {
                return NotFound();
            }

            return Ok(new
            {
                message = "Staff Updated Successfully!!!",
                id = staff!.UserId
            });
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            if (!_staffService.DeleteStaffByID(id))
            {
                return NotFound();
            }

            return Ok(new
            {
                message = "Staff Deleted Successfully!!!",
                id = id
            });
        }
    }
}
