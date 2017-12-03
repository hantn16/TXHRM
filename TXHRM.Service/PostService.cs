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
    public interface IPostService
    {
        Post Add(Post post);
        void Update(Post post);
        Post Delete(int id);
        IEnumerable<Post> GetAll();
        IEnumerable<Post> GetAll(string keyWord);
        IEnumerable<Post> GetAllPaging(int page, int pageSize, out int totalRow);
        Post GetById(int id);
        IEnumerable<Post> GetAllByTagPaging(string tag,int page, int pageSize, out int totalRow);
        void SaveChanges();
    }
    public class PostService : IPostService
    {
        IPostRepository _postRepository;
        IUnitOfWork _unitOfWork;
        ITagRepository _tagRepository;
        IPostTagRepository _postTagRepository;
        public PostService(IPostRepository postRepository,IUnitOfWork unitOfWork,ITagRepository tagRepository,IPostTagRepository postTagRepository)
        {
            this._postRepository = postRepository;
            this._unitOfWork = unitOfWork;
            this._tagRepository = tagRepository;
            this._postTagRepository = postTagRepository;
        }
        public Post Add(Post post)
        {
            var addedPost = _postRepository.Add(post);
            _unitOfWork.Commit();
            if (!String.IsNullOrEmpty(post.Tags))
            {
                var listTag = new TagService(_tagRepository,_unitOfWork).Add(post.Tags);
                foreach (Tag tag in listTag)
                {
                    var postTag = new PostTag() {
                        TagId = tag.Id,
                        PostId = addedPost.Id
                    };
                    _postTagRepository.Add(postTag);
                }
                _unitOfWork.Commit();
            }
            return addedPost;
        }

        public Post Delete(int id)
        {
            return _postRepository.Delete(id);
        }

        public IEnumerable<Post> GetAll()
        {
            return _postRepository.GetAll(new string[] { "PostCategory" });
        }

        public IEnumerable<Post> GetAll(string keyWord)
        {
            return _postRepository.GetMulti(c=>c.Name.Contains(keyWord)||c.Alias.Contains(keyWord), new string[] { "PostCategory" });
        }

        public IEnumerable<Post> GetAllByTagPaging(string tag, int page, int pageSize, out int totalRow)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Post> GetAllPaging(int page, int pageSize, out int totalRow)
        {
            throw new NotImplementedException();
        }

        public Post GetById(int id)
        {
            return _postRepository.GetSingleById(id);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(Post post)
        {
            _postRepository.Update(post);
            _postTagRepository.DeleteMulti(c => c.PostId == post.Id);
            if (!String.IsNullOrEmpty(post.Tags))
            {
                var listTag = new TagService(_tagRepository, _unitOfWork).Add(post.Tags);               
                foreach (Tag tag in listTag)
                {
                    var postTag = new PostTag()
                    {
                        TagId = tag.Id,
                        PostId = post.Id
                    };
                    _postTagRepository.Add(postTag);
                }
            }
            _unitOfWork.Commit();
        }
    }
}
