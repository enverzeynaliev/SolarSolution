using SolarSolution.Models;

namespace SolarSolution.DataLayer.Repositories;

public interface IStaffRepository
{
    IEnumerable<Staff> GetRecentBirthdays();
    IEnumerable<Staff> GetAllStaff();
    
    Staff GetStaffById(int id);

    void AddStaff(Staff staffPerson);

    void EditBirthday(Staff staffPerson);

    void DeletePerson(int id);

    void SaveChanges();
}

