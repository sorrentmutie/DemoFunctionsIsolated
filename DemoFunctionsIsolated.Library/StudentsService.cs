
namespace DemoFunctionsIsolated.Library;

public class StudentsService : IStudentsData
{
    public async Task<IEnumerable<Student>> GetStudents()
    {
        await Task.Delay(3000);
        return new List<Student>
        {
            new Student { Id = 1, Name = "John Doe", Email = "doe@gmail.com", Matricola = "123" },
            new Student { Id = 2, Name = "Jane Doe", Email = "jdoe@gmail.com", Matricola = "456" },
        };
    }
}
