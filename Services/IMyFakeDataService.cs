using DyITELEC1C.Models;
namespace DyITELEC1C.Services
{
    public interface IMyFakeDataService
    {
        List<Student> StudentList { get; }
        List<Instructor> InstructorList { get; }
    }
}