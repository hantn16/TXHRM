using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TXHRM.Data.Infrastructure;
using TXHRM.Data.Repositories;
using TXHRM.Model.Models;

namespace TXHRM.Service
{
    public interface IEmployeeService
    {
        Employee Add(Employee employee);
        void Update(Employee employee);
        Employee Delete(int id);
        IEnumerable<Employee> GetAll();
        IEnumerable<Employee> GetAll(string keyWord);
        IEnumerable<Employee> GetAllPaging(int page, int pageSize, out int totalRow);
        Employee GetById(int id);
        IEnumerable<Employee> GetAllByTagPaging(string tag, int page, int pageSize, out int totalRow);
        void SaveChanges();
    }
    public class EmployeeService : IEmployeeService
    {
        IEmployeeRepository _employeeRepository;
        IUnitOfWork _unitOfWork;
        public EmployeeService(IEmployeeRepository employeeRepository,IUnitOfWork unitOfWork)
        {
            this._employeeRepository = employeeRepository;
            this._unitOfWork = unitOfWork;
        }

        public Employee Add(Employee employee)
        {
            return _employeeRepository.Add(employee);
        }

        public Employee Delete(int id)
        {
            return _employeeRepository.Delete(id);
        }

        public IEnumerable<Employee> GetAll()
        {
            return _employeeRepository.GetAll();
        }

        public IEnumerable<Employee> GetAll(string keyWord)
        {
            return _employeeRepository.GetMulti(c => c.GetType().GetProperties().ToList().Any(d => d.GetValue(c).ToString().Contains(keyWord)));
        }

        public IEnumerable<Employee> GetAllByTagPaging(string keyWord, int page, int pageSize, out int totalRow)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Employee> GetAllPaging(int page, int pageSize, out int totalRow)
        {
            throw new NotImplementedException();
        }

        public Employee GetById(int id)
        {
            return _employeeRepository.GetSingleById(id);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(Employee employee)
        {
            throw new NotImplementedException();
        }
    }
}
