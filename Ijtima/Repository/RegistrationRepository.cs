using Ijtima.models;
using Microsoft.EntityFrameworkCore;

namespace WebApplicationApi.Repository
{
    public class RegistrationRepository : IRegistrationRepository
    {
        private readonly ApplicationDbContext _context;

        public RegistrationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Registration> Add(Registration registration)
        {
            var result = await _context.Registrations.AddAsync(registration);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Registration?> DeleteRegistration(int id)
        {
            var registration = await _context.Registrations.FindAsync(id);
            if (registration != null)
            {
                _context.Registrations.Remove(registration);
                await _context.SaveChangesAsync();
            }
            return registration;
        }

        public async Task<IEnumerable<Registration>> GetRegistrations()
        {
            return await _context.Registrations.ToListAsync();
        }

        public async Task<Registration?> GetRegistration(int id)
        {
            return await _context.Registrations.FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<Registration?> UpdateRegistration(Registration registration)
        {
            var result = await _context.Registrations.FirstOrDefaultAsync(r => r.Id == registration.Id);
            if (result != null)
            {
                result.FirstName = registration.FirstName;
                result.NameUrdu = registration.NameUrdu;
                result.FatherName = registration.FatherName;
                result.FatherNameUrdu = registration.FatherNameUrdu;
                result.PhoneNumber = registration.PhoneNumber;
                result.Cnic = registration.Cnic;
                result.Status = registration.Status;
                result.Verified = registration.Verified;
                result.Department = registration.Department;
                result.ThumbScan = registration.ThumbScan;
                result.FormNumber= registration.FormNumber;

                await _context.SaveChangesAsync();
                return result;
            }
            return null;
        }
    }
}
