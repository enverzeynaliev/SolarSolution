namespace SolarSolution.Models;

public class AddStaffPerson
{
    // Уникальный номер сотрудника
    public int Id { get; set; }

    // Фамилия сотрудника
    public string Surname { get; set; }

    // Имя  сотрудника
    public string FirstName { get; set; }

    // Отчество сотрудника
    public string LastName { get; set; }

    // Должность
    public string Position { get; set; }

    // Краткое описание
    public string Description { get; set; }

    // Дата рождения
    public DateTime Birthday { get; set; }

    //Урл на фото сотрудника
    public IFormFile? Picture { get; set; }
}