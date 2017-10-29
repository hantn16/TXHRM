using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TXHRM.Model.Models;
using TXHRM.Service;
using TXHRM.Web2.Infrastructure.Core;
using TXHRM.Web2.Infrastructure.Extensions;
using TXHRM.Web2.Models;
using System.Web.Script.Serialization;

namespace TXHRM.Web2.Api
{
    [RoutePrefix("api/employee")]
    [AllowAnonymous]
    public class EmployeeController : BaseApiController
    {
        #region Initial
        IEmployeeService _employeeService;
        IErrorService _errorService;
        public EmployeeController(IEmployeeService employeeService, IErrorService errorService) : base(errorService)
        {
            this._employeeService = employeeService;
            this._errorService = errorService;
        }
        #endregion
        #region GetMethod
        [Route("getall")]
        [HttpGet]
        public HttpResponseMessage GetAll(HttpRequestMessage requestMessage)
        {
            return CreateHttpResponse(requestMessage, () => {

                List<Employee> listEmployee = _employeeService.GetAll().ToList();
                int totalRow = listEmployee.Count();
                List<EmployeeViewModel> listEmployeeVm = Mapper.Map<List<Employee>, List<EmployeeViewModel>>(listEmployee);
                PaginationSet<EmployeeViewModel> paginationSet = new PaginationSet<EmployeeViewModel>()
                {
                    Items = listEmployeeVm,
                    Page = 0,
                    TotalCount = totalRow,
                    TotalPages = 1
                };
                var responseMessage = requestMessage.CreateResponse(HttpStatusCode.OK, paginationSet);
                return responseMessage;
            });
        }
        [Route("getallpaged")]
        [HttpGet]
        public HttpResponseMessage GetAllPaged(HttpRequestMessage requestMessage, int page, int pageSize, string keyWord = null)
        {
            return CreateHttpResponse(requestMessage, () => {

                List<Employee> listEmployee = _employeeService.GetAll().ToList();
                if (!String.IsNullOrEmpty(keyWord))
                {
                    listEmployee = _employeeService.GetAll(keyWord).ToList();
                }
                int totalRow = listEmployee.Count();
                List<Employee> listEmployeePaged = listEmployee.OrderByDescending(c => c.CreatedDate).Skip(page * pageSize).Take(pageSize).ToList();
                List<EmployeeViewModel> listEmployeeVm = Mapper.Map<List<Employee>, List<EmployeeViewModel>>(listEmployeePaged);
                PaginationSet<EmployeeViewModel> paginationSet = new PaginationSet<EmployeeViewModel>()
                {
                    Items = listEmployeeVm,
                    Page = page,
                    TotalCount = totalRow,
                    TotalPages = (int)Math.Ceiling((decimal)totalRow / pageSize)
                };
                var responseMessage = requestMessage.CreateResponse(HttpStatusCode.OK, paginationSet);
                return responseMessage;
            });
        }
        [Route("getdetail")]
        [HttpGet]
        public HttpResponseMessage Get(HttpRequestMessage requestMessage, int id)
        {
            return CreateHttpResponse(requestMessage, () =>
            {
                var employee = _employeeService.GetById(id);
                var employeeVm = Mapper.Map<EmployeeViewModel>(employee);
                HttpResponseMessage responseMessage = requestMessage.CreateResponse(HttpStatusCode.OK, employeeVm);
                return responseMessage;
            });
        }
        #endregion
        #region EmployeeMethod
        public HttpResponseMessage Create(HttpRequestMessage requestMessage, EmployeeViewModel employeeViewModel)
        {
            return CreateHttpResponse(requestMessage, () => {
                HttpResponseMessage responseMessage = null;
                if (ModelState.IsValid)
                {
                    Employee employee = new Employee();
                    employee.UpdateFromViewModel<Employee, EmployeeViewModel>(employeeViewModel);
                    Employee newEmployee = _employeeService.Add(employee);
                    _employeeService.SaveChanges();
                    responseMessage = requestMessage.CreateResponse(HttpStatusCode.Created, newEmployee);
                }
                else
                {
                    responseMessage = requestMessage.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                return responseMessage;
            });
        }
        #endregion
        #region PutMethod
        [HttpPut]
        public HttpResponseMessage Put(HttpRequestMessage requestMessage, [FromBody]EmployeeViewModel employeeViewModel)
        {
            return CreateHttpResponse(requestMessage, () => {
                HttpResponseMessage responseMessage = null;
                if (ModelState.IsValid)
                {
                    Employee employee = _employeeService.GetById((int)employeeViewModel.ID);
                    employee.UpdateFromViewModel<Employee, EmployeeViewModel>(employeeViewModel);
                    employee.ModifiedDate = DateTime.Now;
                    _employeeService.Update(employee);
                    _employeeService.SaveChanges();
                    responseMessage = requestMessage.CreateResponse(HttpStatusCode.OK);
                }
                else
                {
                    responseMessage = requestMessage.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                return responseMessage;
            });
        }
        #endregion
        #region DeleteMethod
        [Route("delete")]
        [HttpDelete]
        public HttpResponseMessage Delete(HttpRequestMessage requestMessage, int id)
        {
            return CreateHttpResponse(requestMessage, () => {
                HttpResponseMessage responseMessage = null;
                if (ModelState.IsValid)
                {
                    var oldEmployee = _employeeService.Delete(id);
                    _employeeService.SaveChanges();
                    var responseData = Mapper.Map<Employee, EmployeeViewModel>(oldEmployee);
                    responseMessage = requestMessage.CreateResponse(HttpStatusCode.OK, responseData);
                }
                else
                {
                    responseMessage = requestMessage.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                return responseMessage;
            });
        }
        [Route("deletemulti")]
        [HttpDelete]
        public HttpResponseMessage DeleteMulti(HttpRequestMessage requestMessage, string jsonListID)
        {
            return CreateHttpResponse(requestMessage, () => {
                HttpResponseMessage responseMessage = null;
                if (ModelState.IsValid)
                {
                    List<int> listID = new JavaScriptSerializer().Deserialize<List<int>>(jsonListID);
                    List<Employee> listDeletingEmployee = new List<Employee>();

                    foreach (var id in listID)
                    {
                        listDeletingEmployee.Add(_employeeService.Delete(id));
                    }
                    _employeeService.SaveChanges();
                    List<Employee> listDeletedEmployee = listDeletingEmployee;
                    var responseData = Mapper.Map<List<Employee>, List<EmployeeViewModel>>(listDeletedEmployee);
                    responseMessage = requestMessage.CreateResponse(HttpStatusCode.OK, responseData);
                }
                else
                {
                    responseMessage = requestMessage.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                return responseMessage;
            });
        }
        #endregion
    }
}
