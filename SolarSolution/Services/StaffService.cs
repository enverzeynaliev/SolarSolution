using SolarSolution.DataLayer.Repositories;
using SolarSolution.Models;

namespace SolarSolution.Services;

public class StaffService
{
    private readonly IStaffRepository _staffRepository;
    private readonly IWebHostEnvironment _environment;

    public StaffService(IStaffRepository personRepository, IWebHostEnvironment environment)
    {
        _staffRepository = personRepository;
        _environment = environment;
    }

    public async Task AddStaff(AddStaffPerson addStaffPerson)
    {
        if (addStaffPerson.Picture != null)
        {
            // путь к папке Files
            string path = "/imgs/" + addStaffPerson.Picture.FileName;
            // сохраняем файл в папку Files в каталоге wwwroot
            using (var fileStream = new FileStream(_environment.WebRootPath + path, FileMode.Create))
            {
                await addStaffPerson.Picture.CopyToAsync(fileStream);
            }
        }

        _staffRepository.AddStaff(new Staff
        {
            Surname = addStaffPerson.Surname,
            FirstName = addStaffPerson.FirstName,
            LastName = addStaffPerson.LastName,
            Position = addStaffPerson.Position,
            Picture = addStaffPerson.Picture?.FileName ?? "default.jpg",
            Birthday = addStaffPerson.Birthday
        });
    }

    public void DeletePerson(int id)
    {
        _staffRepository.DeletePerson(id);
    }

    public async Task EditStaff(EditStaffPerson editStaffPerson)
    {
        if (editStaffPerson.Picture != null)
        {
            // путь к папке Files
            string path = "/imgs/" + editStaffPerson.Picture.FileName;
            // сохраняем файл в папку Files в каталоге wwwroot
            using (var fileStream = new FileStream(_environment.WebRootPath + path, FileMode.Create))
            {
                await editStaffPerson.Picture.CopyToAsync(fileStream);
            }
        }

        var staff = _staffRepository.GetStaffById(editStaffPerson.Id);
        if (staff == null) return;

        staff.Picture = editStaffPerson.Picture?.FileName ?? "default.jpg";        
        staff.Surname = editStaffPerson.Surname;
        staff.FirstName = editStaffPerson.FirstName;
        staff.LastName = editStaffPerson.LastName;
        staff.Position = editStaffPerson.Position;
        staff.Birthday = editStaffPerson.Birthday;

        _staffRepository.SaveChanges();
    }
}