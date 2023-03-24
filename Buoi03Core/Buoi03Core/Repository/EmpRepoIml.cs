using Buoi03Core.Models;
using Buoi03Core.Respository;

namespace Buoi03Core.Repository
{
    public class EmpRepoIml : IEmployeeRepository
    {
        private DatabaseConText _dbContext;
        public EmpRepoIml(DatabaseConText dbContext)
        {
            _dbContext = dbContext;
        }
        public void AddEmp(Employee employee)
        {
            _dbContext.Employees.Add(employee);
            _dbContext.SaveChanges();
        }

        public void DeleteEmp(int id)
        {
            //cach 1
            //Employee emp = (from em in _dbContext.Employees where em.Id == id select em).SingleOrDefault();
            //cach 2
            var emp = _dbContext.Employees.SingleOrDefault(e=>e.Id.Equals(id));
            if (emp != null)
            {
                _dbContext.Employees.Remove(emp);
                _dbContext.SaveChanges();
            }
        }

        public List<Employee> GetAllEmp()
        {
            return _dbContext.Employees.ToList();
        }

        public Employee GetEmp(int id)
        {
            Employee emp = (from em in _dbContext.Employees where em.Id == id select em).SingleOrDefault();
            return emp;
        }

        public void UpdateEmp(Employee UpdEmployee)
        {
            var emp = _dbContext.Employees.SingleOrDefault(e => e.Id.Equals(UpdEmployee.Id));
            if (emp != null)
            {
                emp.EmployeeName = UpdEmployee.EmployeeName;
                emp.Phone = UpdEmployee.Phone;
                emp.Skill = UpdEmployee.Skill;
                emp.Experiences = UpdEmployee.Experiences;
                _dbContext.SaveChanges();
            }
        }
    }
}
