using AutoMapper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using TXHRM.Common.Exceptions;
using TXHRM.Model.Models;
using TXHRM.Service;
using TXHRM.WebAPI.Infrastructure.Core;
using TXHRM.WebAPI.Infrastructure.Extensions;
using TXHRM.WebAPI.Models;
using TXHRM.WebAPI.Providers;

namespace TXHRM.WebAPI.Controllers
{
    [Authorize]
    [RoutePrefix("api/appuser")]
    public class AppUserController : ApiControllerBase
    {
        public AppUserController(IErrorService errorService)
            : base(errorService)
        {
        }

        [Route("getlistpaging")]
        [HttpGet]
        [Permission(Action = "Read", Function = "USER")]
        public HttpResponseMessage GetListPaging(HttpRequestMessage request, int page, int pageSize, string filter = null)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                int totalRow = 0;
                var model = AppUserManager.Users;
                if (!string.IsNullOrWhiteSpace(filter))
                    model = model.Where(x => x.UserName.Contains(filter) || x.FullName.Contains(filter));

                totalRow = model.Count();

                var data = model.OrderBy(x => x.FullName).Skip((page - 1) * pageSize).Take(pageSize);
                IEnumerable<AppUserViewModel> modelVm = Mapper.Map<IEnumerable<AppUser>, IEnumerable<AppUserViewModel>>(data);

                PaginationSet<AppUserViewModel> pagedSet = new PaginationSet<AppUserViewModel>()
                {
                    PageIndex = page,
                    PageSize = pageSize,
                    TotalRows = totalRow,
                    Items = modelVm,
                };

                response = request.CreateResponse(HttpStatusCode.OK, pagedSet);

                return response;
            });
        }

        [Route("detail/{id}")]
        [HttpGet]
        [Permission(Action = "Read", Function = "USER")]
        //[Authorize(Roles = "ViewUser")]
        public async Task<HttpResponseMessage> Details(HttpRequestMessage request, string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return request.CreateErrorResponse(HttpStatusCode.BadRequest, nameof(id) + " không có giá trị.");
            }
            var user = await AppUserManager.FindByIdAsync(id);
            if (user == null)
            {
                return request.CreateErrorResponse(HttpStatusCode.NoContent, "Không có dữ liệu");
            }
            else
            {
                var roles = await AppUserManager.GetRolesAsync(user.Id);
                var appUserViewModel = Mapper.Map<AppUser, AppUserViewModel>(user);
                appUserViewModel.Roles = roles;
                return request.CreateResponse(HttpStatusCode.OK, appUserViewModel);
            }
        }

        [HttpPost]
        [Route("add")]
        //[Authorize(Roles = "AddUser")]
        [Permission(Action = "Create", Function = "USER")]
        public async Task<HttpResponseMessage> Create(HttpRequestMessage request, AppUserViewModel appUserViewModel)
        {
            if (ModelState.IsValid)
            {
                var newAppUser = new AppUser();
                newAppUser.UpdateUser(appUserViewModel);
                try
                {
                    newAppUser.Id = Guid.NewGuid().ToString();
                    var result = await AppUserManager.CreateAsync(newAppUser, appUserViewModel.Password);
                    if (result.Succeeded)
                    {
                        if (appUserViewModel.Roles!=null && appUserViewModel.Roles.Count > 0)
                        {
                            var roles = appUserViewModel.Roles.ToArray();
                            await AppUserManager.AddToRolesAsync(newAppUser.Id, roles);
                        }                   
                        return request.CreateResponse(HttpStatusCode.OK, appUserViewModel);
                    }
                    else
                    {
                        string errMsg = string.Join(",", result.Errors);
                        return request.CreateErrorResponse(HttpStatusCode.BadRequest, errMsg);
                    }

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
        //[Authorize(Roles = "UpdateUser")]
        [Permission(Action = "Update", Function = "USER")]
        public async Task<HttpResponseMessage> Update(HttpRequestMessage request, AppUserViewModel appUserViewModel)
        {
            if (ModelState.IsValid)
            {
                var appUser = await AppUserManager.FindByIdAsync(appUserViewModel.Id);
                try
                {
                    appUser.UpdateUser(appUserViewModel);
                    var result = await AppUserManager.UpdateAsync(appUser);
                    if (result.Succeeded)
                    {
                        var userRoles = await AppUserManager.GetRolesAsync(appUser.Id);
                        var selectedRole = appUserViewModel.Roles.ToArray();

                        selectedRole = selectedRole ?? new string[] { };

                        await AppUserManager.AddToRolesAsync(appUser.Id, selectedRole.Except(userRoles).ToArray());
                        return request.CreateResponse(HttpStatusCode.OK, appUserViewModel);
                    }
                    else
                        return request.CreateErrorResponse(HttpStatusCode.BadRequest, string.Join(",", result.Errors));
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
        [Permission(Action = "Delete", Function = "USER")]
        //[Authorize(Roles ="DeleteUser")]
        public async Task<HttpResponseMessage> Delete(HttpRequestMessage request, string id)
        {
            var appUser = await AppUserManager.FindByIdAsync(id);
            var result = await AppUserManager.DeleteAsync(appUser);
            if (result.Succeeded)
                return request.CreateResponse(HttpStatusCode.OK, id);
            else
                return request.CreateErrorResponse(HttpStatusCode.OK, string.Join(",", result.Errors));
        }
    }
}