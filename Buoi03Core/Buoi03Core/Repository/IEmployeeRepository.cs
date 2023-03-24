using Buoi03Core.Models;

namespace Buoi03Core.Respository
{
    public interface IEmployeeRepository
    {
        List<Employee> GetAllEmp();
        Employee GetEmp(int id);
        void AddEmp(Employee employee);
        void UpdateEmp(Employee employee);
        void DeleteEmp(int id);
    }
}
