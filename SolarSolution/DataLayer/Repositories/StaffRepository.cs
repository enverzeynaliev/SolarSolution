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
            x.Birthday.DayOfYear >= DateTime.Now.DayOfYear &&
            x.Birthday.DayOfYear < DateTime.Now.DayOfYear + 7).ToList();
    }

    public IEnumerable<Staff> GetAllStaff()
    {
        //Тут стоит добавить условие для пагинации, но пока сделана выборка по всем записям
        return _context.Staff.ToList();
    }

    public Staff GetStaffById(int id)
    {
        return _context.Staff.FirstOrDefault(x => x.Id == id) ?? throw new KeyNotFoundException();
    }

    public void AddStaff(Staff staffPerson)
    {
        _context.Staff.Add(staffPerson);
        _context.SaveChanges();
    }

    public void EditBirthday(Staff staffPerson)
    {
        if (_context.Staff.FirstOrDefault(x => x.Id == staffPerson.Id) == null) return;
        _context.Staff.Update(staffPerson);
        _context.SaveChanges();
    }

    public void DeletePerson(int id)
    {
        _context.Staff.Remove(GetStaffById(id));
        _context.SaveChanges();
    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }
}