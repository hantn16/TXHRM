using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Script.Serialization;
using TXHRM.Model.Models;
using TXHRM.Service;
using TXHRM.Web2.Infrastructure.Core;
using TXHRM.Web2.Infrastructure.Extensions;
using TXHRM.Web2.Models;

namespace TXHRM.Web2.Api
{
    [RoutePrefix("api/postCategory")]
    [AllowAnonymous]
    public class PostCategoryController : BaseApiController
    {
        #region Initialize
        IPostCategoryService _postCategoryService;
        IErrorService _errorService;
        public PostCategoryController(IErrorService errorService, IPostCategoryService postCategoryService) : base(errorService)
        {
            this._postCategoryService = postCategoryService;
            this._errorService = errorService;
        }
        #endregion

        #region GetMethod
        [Route("GetAll")]
        [HttpGet]
        public HttpResponseMessage Get(HttpRequestMessage requestMessage)
        {
            return CreateHttpResponse(requestMessage, () =>
            {
                int totalRow = 0;
                IEnumerable<PostCategory> listCategory = _postCategoryService.GetAll();

                totalRow = listCategory.Count();

                var responseData = Mapper.Map<IEnumerable<PostCategory>, IEnumerable<PostCategoryViewModel>>(listCategory);
                PaginationSet<PostCategoryViewModel> paginationSet = new PaginationSet<PostCategoryViewModel>()
                {
                    Items = responseData,
                    Page = 0,
                    TotalCount = totalRow,
                    TotalPages = 1
                };
                HttpResponseMessage responseMessage = requestMessage.CreateResponse(HttpStatusCode.OK, paginationSet);
                return responseMessage;

            });
        }
        [Route("getall")]
        [HttpGet]
        public HttpResponseMessage Get(HttpRequestMessage requestMessage, int page, int pageSize, string keyWord = null)
        {
            return CreateHttpResponse(requestMessage, () =>
            {
                int totalRow = 0;
                IEnumerable<PostCategory> listCategory = _postCategoryService.GetAll();
                if (!string.IsNullOrEmpty(keyWord))
                {
                    listCategory = _postCategoryService.GetAll(keyWord);
                }

                totalRow = listCategory.Count();
                var query = listCategory.OrderByDescending(c => c.CreatedDate).Skip(page * pageSize).Take(pageSize);
                var abc = Math.Ceiling(1.5);
                var responseData = Mapper.Map<IEnumerable<PostCategory>, IEnumerable<PostCategoryViewModel>>(query);
                PaginationSet<PostCategoryViewModel> paginationSet = new PaginationSet<PostCategoryViewModel>()
                {
                    Items = responseData,
                    Page = page,
                    TotalCount = totalRow,
                    TotalPages = (int)Math.Ceiling((decimal)totalRow / pageSize)
                };
                HttpResponseMessage responseMessage = requestMessage.CreateResponse(HttpStatusCode.OK, paginationSet);
                return responseMessage;

            });
        }
        [Route("getdetail")]
        [HttpGet]
        public HttpResponseMessage Get(HttpRequestMessage requestMessage, int id)
        {
            return CreateHttpResponse(requestMessage, () =>
            {
                var category = _postCategoryService.GetById(id);
                var categoryVm = Mapper.Map<PostCategoryViewModel>(category);
                HttpResponseMessage responseMessage = requestMessage.CreateResponse(HttpStatusCode.OK, categoryVm);
                return responseMessage;
            });
        }
        [Route("checknameunique")]
        [HttpGet]
        public HttpResponseMessage CheckNameUnique(HttpRequestMessage requestMessage, string checkValue)
        {
            return CreateHttpResponse(requestMessage, () =>
            {
                HttpResponseMessage responseMessage = null;
                var listCategory = _postCategoryService.GetAll();
                var category = listCategory.FirstOrDefault(c => c.Name == checkValue);
                responseMessage = requestMessage.CreateResponse(HttpStatusCode.OK, (category == null ? new { Status = true } : new { Status = false }));
                return responseMessage;
            });
        }
        #endregion
        #region PostMethod
        [Route("create")]
        [HttpPost]
        public HttpResponseMessage Post(HttpRequestMessage requestMessage, [FromBody]PostCategoryViewModel postCategoryViewModel)
        {
            return CreateHttpResponse(requestMessage, () => {
                HttpResponseMessage responseMessage = null;
                if (ModelState.IsValid)
                {
                    PostCategory postCategory = new PostCategory();
                    postCategory.UpdateFromViewModel<PostCategory, PostCategoryViewModel>(postCategoryViewModel);
                    PostCategory newPostCategory = _postCategoryService.Add(postCategory);
                    _postCategoryService.SaveChanges();
                    responseMessage = requestMessage.CreateResponse(HttpStatusCode.Created, newPostCategory);
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
        [Route("update")]
        [HttpPut]
        public HttpResponseMessage Put(HttpRequestMessage requestMessage, [FromBody]PostCategoryViewModel postCategoryViewModel)
        {
            return CreateHttpResponse(requestMessage, () => {
                HttpResponseMessage responseMessage = null;
                if (ModelState.IsValid)
                {
                    PostCategory postCategory = _postCategoryService.GetById(postCategoryViewModel.ID);
                    postCategory.UpdateFromViewModel<PostCategory, PostCategoryViewModel>(postCategoryViewModel);
                    postCategory.ModifiedDate = DateTime.Now;
                    _postCategoryService.Update(postCategory);
                    _postCategoryService.SaveChanges();
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
                    var oldPostCategory = _postCategoryService.Delete(id);
                    _postCategoryService.SaveChanges();
                    var responseData = Mapper.Map<PostCategory, PostCategoryViewModel>(oldPostCategory);
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
                    List<PostCategory> listDeletingPostCategory = new List<PostCategory>();

                    foreach (var id in listID)
                    {
                        listDeletingPostCategory.Add(_postCategoryService.Delete(id));
                    }
                    _postCategoryService.SaveChanges();
                    List<PostCategory> listDeletedPostCategory = listDeletingPostCategory;
                    var responseData = Mapper.Map<List<PostCategory>, List<PostCategoryViewModel>>(listDeletedPostCategory);
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
