using Ijtima.models;

public interface IRegistrationRepository
{
    Task<Registration> Add(Registration registration);
    Task<Registration?> UpdateRegistration(Registration registration);
    Task<Registration?> DeleteRegistration(int id);
    Task<Registration?> GetRegistration(int id);
    Task<IEnumerable<Registration>> GetRegistrations();
}
