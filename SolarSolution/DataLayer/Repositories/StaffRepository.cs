using SolarSolution.Models;

namespace SolarSolution.DataLayer.Repositories;

public class StaffRepository : IStaffRepository
{
    private readonly ApplicationDbContext _context;

    public StaffRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Staff> GetRecentBirthdays()
    {
        return _context.Staff.Where(x => x.Birthday >= DateTime.Today && x.Birthday < DateTime.Today.AddDays(7));
    }
}