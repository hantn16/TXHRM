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
using TXHRM.Web.Infrastructure.Extensions;
using TXHRM.Web.Models;

namespace TXHRM.Web.Api
{
    [RoutePrefix("Api/PostCategory")]
    public class PostCategoryController : BaseApiController
    {
        IPostCategoryService _postCategoryService;
        IErrorService _errorService;
        public PostCategoryController(IErrorService errorService,IPostCategoryService postCategoryService) : base(errorService)
        {
            this._postCategoryService = postCategoryService;
            this._errorService = errorService;
        }
        [Route("GetAll")]
        public HttpResponseMessage Get(HttpRequestMessage requestMessage)
        {
            return CreateHttpResponse(requestMessage, () => 
            {
                var listCategory = _postCategoryService.GetAll();
                var listPostCategoryVm = Mapper.Map<List<PostCategoryViewModel>>(listCategory);
                HttpResponseMessage responseMessage = requestMessage.CreateResponse(HttpStatusCode.OK, listPostCategoryVm);
                return responseMessage;
                
            });
        }

        // GET api/<controller>/5
        public String Get(int id)
        {
            return "value";
        }

        [Route("Create")]
        public HttpResponseMessage Post(HttpRequestMessage requestMessage,[FromBody]PostCategoryViewModel postCategoryViewModel)
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

        [Route("Update")]
        public HttpResponseMessage Put(HttpRequestMessage requestMessage, [FromBody]PostCategoryViewModel postCategoryViewModel)
        {
            return CreateHttpResponse(requestMessage, () => {
                HttpResponseMessage responseMessage = null;
                if (ModelState.IsValid)
                {
                    PostCategory postCategory = new PostCategory();
                    postCategory.UpdateFromViewModel<PostCategory, PostCategoryViewModel>(postCategoryViewModel);
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

        [Route("Delete")]
        public HttpResponseMessage Delete(HttpRequestMessage requestMessage,int id)
        {
            return CreateHttpResponse(requestMessage, () => {
                HttpResponseMessage responseMessage = null;
                if (ModelState.IsValid)
                {
                    _postCategoryService.Delete(id);
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
    }
}