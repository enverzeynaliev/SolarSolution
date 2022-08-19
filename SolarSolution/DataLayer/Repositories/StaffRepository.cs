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
        return _context.Staff.Where(x =>
            x.Birthday.DayOfYear >= DateTime.Now.DayOfYear  &&
            x.Birthday.DayOfYear < DateTime.Now.DayOfYear + 7);
   
    }

    public IEnumerable<Staff> GetAllStaff()
    {
        //Тут стоит добавить условие для пагинации, но пока сделана выборка по всем записям
        return _context.Staff.Where(x => x.Id > 0);
    }
}