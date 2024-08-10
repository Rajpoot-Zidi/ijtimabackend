using Ijtima.models;
using Microsoft.AspNetCore.Mvc;

namespace WebApplicationApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private readonly IRegistrationRepository _registrationRepository;

        public RegistrationController(IRegistrationRepository registrationRepository)
        {
            _registrationRepository = registrationRepository;
        }

        [HttpPost]
        public async Task<ActionResult<Registration>> AddRegistration(Registration registration)
        {
            var createdRegistration = await _registrationRepository.Add(registration);
            return CreatedAtAction(nameof(GetRegistration), new { id = createdRegistration.Id }, createdRegistration);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateRegistration(Registration registration)
        {
            var existingRegistration = await _registrationRepository.GetRegistration(registration.Id);
            if (existingRegistration != null)
            {
                existingRegistration.FirstName = registration.FirstName;
                existingRegistration.NameUrdu = registration.NameUrdu;
                existingRegistration.FatherName = registration.FatherName;
                existingRegistration.FatherNameUrdu = registration.FatherNameUrdu;
                existingRegistration.PhoneNumber = registration.PhoneNumber;
                existingRegistration.Cnic = registration.Cnic;
                existingRegistration.Status = registration.Status;
                existingRegistration.Verified = registration.Verified;
                existingRegistration.Department = registration.Department;
                existingRegistration.ThumbScan = registration.ThumbScan;

                var updatedRegistration = await _registrationRepository.UpdateRegistration(existingRegistration);
                return Ok("Updated Successfully");
            }
            else
            {
                return BadRequest("Registration not found");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteRegistration(int id)
        {
            var registration = await _registrationRepository.DeleteRegistration(id);
            if (registration != null)
            {
                return Ok("Deleted Successfully");
            }
            else
            {
                return BadRequest("Registration not found");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetRegistration(int id)
        {
            var registration = await _registrationRepository.GetRegistration(id);
            if (registration != null)
            {
                return Ok(registration);
            }
            else
            {
                return BadRequest("Registration not found");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetRegistrations()
        {
            var registrationsList = await _registrationRepository.GetRegistrations();
            return Ok(registrationsList);
        }


    }
}
