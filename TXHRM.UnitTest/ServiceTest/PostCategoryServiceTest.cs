using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TXHRM.Data.Infrastructure;
using TXHRM.Data.Repositories;
using TXHRM.Model.Models;
using TXHRM.Service;

namespace TXHRM.UnitTest.ServiceTest
{
    [TestClass]
    public class PostCategoryServiceTest
    {
        private Mock<IPostCategoryRepository> _mockRepository;
        private Mock<IUnitOfWork> _mockUnitOfWork;
        private IPostCategoryService _mockService;
        private List<PostCategory> _listCategory;

        [TestInitialize]
        public void Initialize()
        {
            this._mockRepository = new Mock<IPostCategoryRepository>();
            this._mockUnitOfWork = new Mock<IUnitOfWork>();
            this._mockService = new PostCategoryService(_mockRepository.Object, _mockUnitOfWork.Object);
            this._listCategory = new List<PostCategory>() {
                new PostCategory(){ID = 1,Name = "DM1",Status = true},
                new PostCategory(){ID = 2,Name = "DM2",Status = true},
                new PostCategory(){ID = 3,Name = "DM3",Status = true}
            };
        }

        [TestMethod]
        public void PostCategory_Service_GetAll()
        {
            //Setup Method
            _mockRepository.Setup(m => m.GetAll(null)).Returns(_listCategory);

            //Call action
            var result = _mockService.GetAll() as List<PostCategory>;

            //Compare
            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Count);
        }

        [TestMethod]
        public void PostCategory_Service_Add()
        {
            PostCategory postCategory = new PostCategory() { Name = "Test", Alias = "test", Status = true };
            _mockRepository.Setup(m => m.Add(postCategory)).Returns((PostCategory p) => { p.ID = 1; return p; });
            var result = _mockService.Add(postCategory);
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.ID);
        }
    }
}
