namespace DemoFunctionsIsolated.Library;

public interface IStudentsData
{
    Task<IEnumerable<Student>> GetStudents();
}
