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
    public interface IDepartmentService
    {
        Department Add(Department department);
        void Update(Department department);
        Department Delete(int id);
        IEnumerable<Department> GetAll();
        IEnumerable<Department> GetAll(string keyWord);
        IEnumerable<Department> GetAllPaging(int page, int pageSize, out int totalRow);
        Department GetById(int id);
        IEnumerable<Department> GetAllByTagPaging(string tag, int page, int pageSize, out int totalRow);
        void SaveChanges();
    }
    public class DepartmentService : IDepartmentService
    {
        IDepartmentRepository _departmentRepository;
        IUnitOfWork _unitOfWork;
        public DepartmentService(IDepartmentRepository departmentRepository, IUnitOfWork unitOfWork)
        {
            this._departmentRepository = departmentRepository;
            this._unitOfWork = unitOfWork;
        }

        public Department Add(Department department)
        {
            return _departmentRepository.Add(department);
        }

        public Department Delete(int id)
        {
            return _departmentRepository.Delete(id);
        }

        public IEnumerable<Department> GetAll()
        {
            return _departmentRepository.GetAll();
        }

        public IEnumerable<Department> GetAll(string keyWord)
        {
            return _departmentRepository.GetMulti(c => c.GetType().GetProperties().ToList().Any(d => d.GetValue(c).ToString().Contains(keyWord)));
        }

        public IEnumerable<Department> GetAllByTagPaging(string keyWord, int page, int pageSize, out int totalRow)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Department> GetAllPaging(int page, int pageSize, out int totalRow)
        {
            throw new NotImplementedException();
        }

        public Department GetById(int id)
        {
            return _departmentRepository.GetSingleById(id);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(Department department)
        {
            throw new NotImplementedException();
        }
    }
}
