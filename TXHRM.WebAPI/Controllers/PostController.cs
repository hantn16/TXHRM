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
using TXHRM.WebAPI.Infrastructure.Core;
using TXHRM.WebAPI.Infrastructure.Extensions;
using TXHRM.WebAPI.Models;

namespace TXHRM.WebAPI.Controllers
{
    [RoutePrefix("api/post")]
    public class PostController : ApiControllerBase
    {
        #region Initial
        IPostService _postService;
        IErrorService _errorService;
        public PostController(IPostService postService, IErrorService errorService) : base(errorService)
        {
            this._postService = postService;
            this._errorService = errorService;
        }
        #endregion
        #region GetMethod
        [Route("getall")]
        [HttpGet]
        public HttpResponseMessage GetAll(HttpRequestMessage requestMessage)
        {
            try
            {
                return CreateHttpResponse(requestMessage, () => {

                    List<Post> listPost = _postService.GetAll().ToList();
                    int totalRow = listPost.Count();
                    List<PostViewModel> listPostVm = Mapper.Map<List<PostViewModel>>(listPost);
                    PaginationSet<PostViewModel> paginationSet = new PaginationSet<PostViewModel>()
                    {
                        Items = listPostVm,
                        PageIndex = 0,
                        TotalRows = totalRow,
                        TotalPages = 1
                    };
                    var responseMessage = requestMessage.CreateResponse(HttpStatusCode.OK, paginationSet);
                    return responseMessage;
                });
            }
            catch (Exception)
            {              
                throw;
            }

        }
        [Route("getallpaged")]
        [HttpGet]
        public HttpResponseMessage GetAllPaged(HttpRequestMessage requestMessage, int page, int pageSize, string keyWord = null)
        {
            return CreateHttpResponse(requestMessage, () => {

                List<Post> listPost = _postService.GetAll().ToList();
                if (!String.IsNullOrEmpty(keyWord))
                {
                    listPost = _postService.GetAll(keyWord).ToList();
                }
                int totalRow = listPost.Count();
                List<Post> listPostPaged = listPost.OrderByDescending(c => c.CreatedDate).Skip(page * pageSize).Take(pageSize).ToList();
                List<PostViewModel> listPostVm = Mapper.Map<List<Post>, List<PostViewModel>>(listPostPaged);
                PaginationSet<PostViewModel> paginationSet = new PaginationSet<PostViewModel>()
                {
                    Items = listPostVm,
                    PageIndex = page,
                    TotalRows = totalRow,
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
                var post = _postService.GetById(id);
                var postVm = Mapper.Map<PostViewModel>(post);
                HttpResponseMessage responseMessage = requestMessage.CreateResponse(HttpStatusCode.OK, postVm);
                return responseMessage;
            });
        }
        #endregion
        #region PostMethod
        public HttpResponseMessage Create(HttpRequestMessage requestMessage, PostViewModel postViewModel)
        {
            return CreateHttpResponse(requestMessage, () => {
                HttpResponseMessage responseMessage = null;
                if (ModelState.IsValid)
                {
                    Post post = new Post();
                    //post.UpdateFromViewModel<Post, PostViewModel>(postViewModel);
                    post = Mapper.Map<Post>(postViewModel);
                    Post newPost = _postService.Add(post);
                    _postService.SaveChanges();
                    responseMessage = requestMessage.CreateResponse(HttpStatusCode.Created, newPost);
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
        public HttpResponseMessage Put(HttpRequestMessage requestMessage, [FromBody]PostViewModel postViewModel)
        {
            return CreateHttpResponse(requestMessage, () => {
                HttpResponseMessage responseMessage = null;
                if (ModelState.IsValid)
                {
                    Post post = _postService.GetById(postViewModel.Id);
                    post.UpdateFromViewModel<Post, PostViewModel>(postViewModel);
                    post.ModifiedDate = DateTime.Now;
                    _postService.Update(post);
                    _postService.SaveChanges();
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
                    var oldPost = _postService.Delete(id);
                    _postService.SaveChanges();
                    var responseData = Mapper.Map<Post, PostViewModel>(oldPost);
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
                    List<Post> listDeletingPost = new List<Post>();

                    foreach (var id in listID)
                    {
                        listDeletingPost.Add(_postService.Delete(id));
                    }
                    _postService.SaveChanges();
                    List<Post> listDeletedPost = listDeletingPost;
                    var responseData = Mapper.Map<List<Post>, List<PostViewModel>>(listDeletedPost);
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