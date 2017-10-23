using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TXHRM.Data.Infrastructure;
using TXHRM.Data.Repositories;
using TXHRM.Model.Models;
using TXHRM.Common;

namespace TXHRM.Service
{
    public interface ITagService
    {
        Tag Add(Tag tag);
        List<Tag> Add(string tagString);
        void Update(Tag tag);
        Tag Delete(string id);
        IEnumerable<Tag> GetAll();
        IEnumerable<Tag> GetAll(string keyWord);
        IEnumerable<Tag> GetAllPaging(int page, int pageSize, out int totalRow);
        Tag GetById(string id);
        IEnumerable<Tag> GetAllByTagPaging(string tag, int page, int pageSize, out int totalRow);
        void SaveChanges();
    }
    public class TagService : ITagService
    {
        ITagRepository _tagRepository;
        IUnitOfWork _unitOfWork;
        public TagService(ITagRepository tagRepository, IUnitOfWork unitOfWork)
        {
            this._tagRepository = tagRepository;
            this._unitOfWork = unitOfWork;
        }
        public Tag Add(Tag tag)
        {
            return _tagRepository.Add(tag);;
        }

        public List<Tag> Add(string tagString)
        {
            tagString = tagString.ToLower().Replace(", ", ",").Replace(" ,",",");
            string[] tagArr = tagString.Split(new char[] { ',',';' },StringSplitOptions.RemoveEmptyEntries);
            List<Tag> listAddedTag = new List<Tag>();
            foreach (string item in tagArr)
            {
                string tagID = StringHelper.ToUnsignString(item);
                Tag myTag = new Tag()
                {
                    ID = tagID,Name = item,Type = CommonConstants.PostTagType
                };
                Tag tag = _tagRepository.GetSingleById(tagID);
                if (tag==null)
                {
                    listAddedTag.Add(_tagRepository.Add(myTag));
                }
                else
                {
                    if (!tag.Type.Contains(myTag.Type))
                    {
                        tag.Type += (";" + myTag.Type);
                        _unitOfWork.Commit();
                    }
                    listAddedTag.Add(tag);
                }
            }
            return listAddedTag;
        }

        public Tag Delete(string id)
        {
            return _tagRepository.Delete(id);
        }

        public IEnumerable<Tag> GetAll()
        {
            return _tagRepository.GetAll(new string[] { "TagCategory" });
        }

        public IEnumerable<Tag> GetAll(string keyWord)
        {
            return _tagRepository.GetMulti(c => c.Name.Contains(keyWord) || c.ID.Contains(keyWord), new string[] { "TagCategory" });
        }

        public IEnumerable<Tag> GetAllByTagPaging(string tag, int page, int pageSize, out int totalRow)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Tag> GetAllPaging(int page, int pageSize, out int totalRow)
        {
            throw new NotImplementedException();
        }

        public Tag GetById(string id)
        {
            return _tagRepository.GetSingleById(id);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(Tag tag)
        {
            _tagRepository.Update(tag);
        }

    }
}
