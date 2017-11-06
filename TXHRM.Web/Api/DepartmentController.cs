using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TXHRM.Model.Models;
using TXHRM.Service;
using TXHRM.Web.Infrastructure.Core;
using TXHRM.Web.Models;
using System.Web.Script.Serialization;
using TXHRM.Web.Infrastructure.Extensions;

namespace TXHRM.Web.Api
{
    public class DepartmentController : BaseApiController
    {
        #region Initial
        IDepartmentService _departmentService;
        IErrorService _errorService;
        public DepartmentController(IDepartmentService departmentService, IErrorService errorService) : base(errorService)
        {
            this._departmentService = departmentService;
            this._errorService = errorService;
        }
        #endregion
        #region GetMethod
        [Route("getall")]
        [HttpGet]
        public HttpResponseMessage GetAll(HttpRequestMessage requestMessage)
        {
            return CreateHttpResponse(requestMessage, () => {

                List<Department> listDepartment = _departmentService.GetAll().ToList();
                int totalRow = listDepartment.Count();
                List<DepartmentViewModel> listDepartmentVm = Mapper.Map<List<Department>, List<DepartmentViewModel>>(listDepartment);
                PaginationSet<DepartmentViewModel> paginationSet = new PaginationSet<DepartmentViewModel>()
                {
                    Items = listDepartmentVm,
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

                List<Department> listDepartment = _departmentService.GetAll().ToList();
                if (!String.IsNullOrEmpty(keyWord))
                {
                    listDepartment = _departmentService.GetAll(keyWord).ToList();
                }
                int totalRow = listDepartment.Count();
                List<Department> listDepartmentPaged = listDepartment.OrderByDescending(c => c.CreatedDate).Skip(page * pageSize).Take(pageSize).ToList();
                List<DepartmentViewModel> listDepartmentVm = Mapper.Map<List<Department>, List<DepartmentViewModel>>(listDepartmentPaged);
                PaginationSet<DepartmentViewModel> paginationSet = new PaginationSet<DepartmentViewModel>()
                {
                    Items = listDepartmentVm,
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
                var department = _departmentService.GetById(id);
                var departmentVm = Mapper.Map<DepartmentViewModel>(department);
                HttpResponseMessage responseMessage = requestMessage.CreateResponse(HttpStatusCode.OK, departmentVm);
                return responseMessage;
            });
        }
        #endregion
        #region DepartmentMethod
        public HttpResponseMessage Create(HttpRequestMessage requestMessage, DepartmentViewModel departmentViewModel)
        {
            return CreateHttpResponse(requestMessage, () => {
                HttpResponseMessage responseMessage = null;
                if (ModelState.IsValid)
                {
                    Department department = new Department();
                    department.UpdateFromViewModel<Department, DepartmentViewModel>(departmentViewModel);
                    Department newDepartment = _departmentService.Add(department);
                    _departmentService.SaveChanges();
                    responseMessage = requestMessage.CreateResponse(HttpStatusCode.Created, newDepartment);
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
        public HttpResponseMessage Put(HttpRequestMessage requestMessage, [FromBody]DepartmentViewModel departmentViewModel)
        {
            return CreateHttpResponse(requestMessage, () => {
                HttpResponseMessage responseMessage = null;
                if (ModelState.IsValid)
                {
                    Department department = _departmentService.GetById((int)departmentViewModel.ID);
                    department.UpdateFromViewModel<Department, DepartmentViewModel>(departmentViewModel);
                    department.ModifiedDate = DateTime.Now;
                    _departmentService.Update(department);
                    _departmentService.SaveChanges();
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
                    var oldDepartment = _departmentService.Delete(id);
                    _departmentService.SaveChanges();
                    var responseData = Mapper.Map<Department, DepartmentViewModel>(oldDepartment);
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
                    List<Department> listDeletingDepartment = new List<Department>();

                    foreach (var id in listID)
                    {
                        listDeletingDepartment.Add(_departmentService.Delete(id));
                    }
                    _departmentService.SaveChanges();
                    List<Department> listDeletedDepartment = listDeletingDepartment;
                    var responseData = Mapper.Map<List<Department>, List<DepartmentViewModel>>(listDeletedDepartment);
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