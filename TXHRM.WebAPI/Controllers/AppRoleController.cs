using AutoMapper;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TXHRM.Common.Exceptions;
using TXHRM.Model.Models;
using TXHRM.Service;
using TXHRM.WebAPI.Infrastructure.Core;
using TXHRM.WebAPI.Infrastructure.Extensions;
using TXHRM.WebAPI.Models;
using TXHRM.WebAPI.Models.DataContracts;

namespace TXHRM.WebAPI.Controllers
{
    [RoutePrefix("api/approle")]
    [Authorize]
    public class AppRoleController : ApiControllerBase
    {
        private IPermissionService _permissionService;
        private IFunctionService _functionService;
        public AppRoleController(IErrorService errorService, IFunctionService functionService, IPermissionService permissionService) : base(errorService)
        {
            _functionService = functionService;
            _permissionService = permissionService;
        }

        [Route("getlistpaging")]
        [HttpGet]
        public HttpResponseMessage GetListPaging(HttpRequestMessage request, int page, int pageSize, string filter = null)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                int totalRow = 0;
                var query = AppRoleManager.Roles;
                if (!string.IsNullOrEmpty(filter))
                    query = query.Where(x => x.Description.Contains(filter)|| x.Name.Contains(filter));
                totalRow = query.Count();

                var model = query.OrderBy(x => x.Name).Skip((page - 1) * pageSize).Take(pageSize);

                IEnumerable<AppRoleViewModel> modelVm = Mapper.Map<IEnumerable<AppRole>, IEnumerable<AppRoleViewModel>>(model);

                PaginationSet<AppRoleViewModel> pagedSet = new PaginationSet<AppRoleViewModel>()
                {
                    PageIndex = page,
                    TotalRows = totalRow,
                    PageSize = pageSize,
                    Items = modelVm
                };

                response = request.CreateResponse(HttpStatusCode.OK, pagedSet);

                return response;
            });
        }

        [Route("getlistall")]
        [HttpGet]
        public HttpResponseMessage GetAll(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                var model = AppRoleManager.Roles.ToList();
                IEnumerable<AppRoleViewModel> modelVm = Mapper.Map<IEnumerable<AppRole>, IEnumerable<AppRoleViewModel>>(model);

                response = request.CreateResponse(HttpStatusCode.OK, modelVm);

                return response;
            });
        }
        [Route("getallpermission")]
        [HttpGet]
        public HttpResponseMessage GetAllPermission(HttpRequestMessage request, string functionId)
        {
            return CreateHttpResponse(request, () =>
            {
                List<PermissionViewModel> permissions = new List<PermissionViewModel>();
                HttpResponseMessage response = null;
                var roles = AppRoleManager.Roles.Where(x => x.Name != "Admin").ToList();
                var listPermission = _permissionService.GetByFunctionId(functionId).ToList();
                if (listPermission.Count == 0)
                {
                    foreach (var item in roles)
                    {
                        permissions.Add(new PermissionViewModel()
                        {
                            RoleId = item.Id,
                            CanCreate = false,
                            CanDelete = false,
                            CanRead = false,
                            CanUpdate = false,
                            AppRole = new AppRoleViewModel()
                            {
                                Id = item.Id,
                                Description = item.Description,
                                Name = item.Name
                            }
                        });
                    }
                }
                else
                {
                    foreach (var role in roles)
                    {
                        if (!listPermission.Any(x => x.RoleId == role.Id))
                        {
                            listPermission.Add(new Permission()
                            {
                                RoleId = role.Id,
                                CanCreate = false,
                                CanDelete = false,
                                CanRead = false,
                                CanUpdate = false,
                                AppRole = new AppRole()
                                {
                                    Id = role.Id,
                                    Description = role.Description,
                                    Name = role.Name
                                }
                            });
                        }
                        permissions = Mapper.Map<List<Permission>, List<PermissionViewModel>>(listPermission);
                    }
                }
                response = request.CreateResponse(HttpStatusCode.OK, permissions);

                return response;
            });
        }

        [HttpPost]
        [Route("savepermission")]
        public HttpResponseMessage SavePermission(HttpRequestMessage request, SavePermissionRequest data)
        {
            if (ModelState.IsValid)
            {

                _permissionService.DeleteAll(data.FunctionId);
                Permission permission = null;
                foreach (var item in data.Permissions)
                {
                    permission = new Permission();
                    permission.UpdatePermission(item);
                    permission.FunctionId = data.FunctionId;
                    _permissionService.Add(permission);


                }
                var functions = _functionService.GetAllWithParentID(data.FunctionId);
                if (functions.Any())
                {
                    foreach (var item in functions)
                    {
                        _permissionService.DeleteAll(item.Id);

                        foreach (var p in data.Permissions)
                        {
                            var childPermission = new Permission();
                            childPermission.FunctionId = item.Id;
                            childPermission.RoleId = p.RoleId;
                            childPermission.CanRead = p.CanRead;
                            childPermission.CanCreate = p.CanCreate;
                            childPermission.CanDelete = p.CanDelete;
                            childPermission.CanUpdate = p.CanUpdate;
                            _permissionService.Add(childPermission);
                        }
                    }
                }
                try
                {
                    _permissionService.SaveChange();
                    return request.CreateResponse(HttpStatusCode.OK, "Lưu quyền thành cống");
                }
                catch (Exception ex)
                {
                    return request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
                }
            }
            else
            {
                return request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        [Route("detail/{id}")]
        [HttpGet]
        public HttpResponseMessage Details(HttpRequestMessage request, string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return request.CreateErrorResponse(HttpStatusCode.BadRequest, nameof(id) + " không có giá trị.");
            }
            AppRole appRole = AppRoleManager.FindById(id);
            if (appRole == null)
            {
                return request.CreateErrorResponse(HttpStatusCode.NoContent, "No group");
            }
            return request.CreateResponse(HttpStatusCode.OK, appRole);
        }

        [HttpPost]
        [Route("add")]
        public HttpResponseMessage Create(HttpRequestMessage request, AppRoleViewModel appRoleViewModel)
        {
            if (ModelState.IsValid)
            {
                var newAppRole = new AppRole();
                newAppRole = Mapper.Map<AppRoleViewModel, AppRole>(appRoleViewModel);
                if (newAppRole.Id == null) { newAppRole.Id = Guid.NewGuid().ToString(); }
                try
                {
                    AppRoleManager.Create(newAppRole);
                    return request.CreateResponse(HttpStatusCode.OK, appRoleViewModel);
                }
                catch (NameDuplicatedException dex)
                {
                    return request.CreateErrorResponse(HttpStatusCode.BadRequest, dex.Message);
                }
                catch (Exception ex)
                {
                    return request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
                }
            }
            else
            {
                return request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        [HttpPut]
        [Route("update")]
        public HttpResponseMessage Update(HttpRequestMessage request, AppRoleViewModel appRoleViewModel)
        {
            if (ModelState.IsValid)
            {
                var appRole = AppRoleManager.FindById(appRoleViewModel.Id);
                try
                {
                    appRole.UpdateFromViewModel<AppRole,AppRoleViewModel>(appRoleViewModel);
                    appRole.Description = appRoleViewModel.Description;
                    AppRoleManager.Update(appRole);
                    return request.CreateResponse(HttpStatusCode.OK, appRole);
                }
                catch (NameDuplicatedException dex)
                {
                    return request.CreateErrorResponse(HttpStatusCode.BadRequest, dex.Message);
                }
            }
            else
            {
                return request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        [HttpDelete]
        [Route("delete")]
        public HttpResponseMessage Delete(HttpRequestMessage request, string id)
        {
            var appRole = AppRoleManager.FindById(id);

            AppRoleManager.Delete(appRole);
            return request.CreateResponse(HttpStatusCode.OK, id);
        }
    }
}