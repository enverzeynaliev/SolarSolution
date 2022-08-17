namespace SolarLabSolutionDomain.Templates;

public class Staff
{
    public int Id { get; set; } // Уникальный номер сотрудника
    
    public string Surname { get; set; } // Фамилия сотрудника
    
    public string FirstName { get; set; } // Имя  сотрудника
    
    public string LastName { get; set; } // Отчество сотрудника
    
    public string Position { get; set; } // Должность
    
    public string Description { get; set; } // Краткое описание
    
    public DateOnly Birthday { get; set; } // Дата рождения
    
    public string Picture { get; set; }//Урл на фото сотрудника (Временно)
}
