using Core_API.Models;
using System.Collections.Generic;
using System.Linq;

namespace Core_API.Services
{
    public class EmployeeDbService : IDbService<Employee, int>
    {
        private readonly CompanyContext context;
        public EmployeeDbService(CompanyContext ctx)
        {
            context = ctx;
        }

        public Employee Create(Employee entity)
        {
            context.Employees.Add(entity);
            context.SaveChanges();
            return entity;
        }

        public Employee Delete(int id)
        {
            var empToDelete = context.Employees.Find(id);
            if (empToDelete == null) return null;

            context.Employees.Remove(empToDelete);
            context.SaveChanges();
            return empToDelete;
        }

        public IEnumerable<Employee> Get()
        {
            return context.Employees.ToList();
        }

        public Employee Get(int id)
        {
            var empToFind = context.Employees.Find(id);
            return empToFind;
        }

        public Employee Update(int id, Employee entity)
        {
            var empToUpdate = context.Employees.Find(id);
            if (empToUpdate == null) return null;

            empToUpdate.EmpNo = entity.EmpNo;
            empToUpdate.EmpName = entity.EmpName;
            empToUpdate.Designation = entity.Designation;
            empToUpdate.Salary = entity.Salary;
            empToUpdate.DeptNo = entity.DeptNo;

            context.SaveChanges();
            return empToUpdate;
        }
    }
}
