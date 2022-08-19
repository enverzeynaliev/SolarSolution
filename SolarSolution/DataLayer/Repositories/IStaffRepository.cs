using SolarSolution.Models;

namespace SolarSolution.DataLayer.Repositories;

public interface IStaffRepository
{
    IEnumerable<Staff> GetRecentBirthdays();
    IEnumerable<Staff> GetAllStaff();
}

