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

namespace TXHRM.UnitTest.ApiTest
{
    class PostControllerTest
    {
        private Mock<IPostRepository> _mockRepository;
        private Mock<IPostTagRepository> _mockPostTagRepository;
        private Mock<ITagRepository> _mockTagRepository;
        private Mock<IUnitOfWork> _mockUnitOfWork;
        private IPostService _mockService;
        private List<Post> _listPost;
        [TestInitialize]
        public void Initialize()
        {
            this._mockRepository = new Mock<IPostRepository>();
            this._mockPostTagRepository = new Mock<IPostTagRepository>();
            this._mockUnitOfWork = new Mock<IUnitOfWork>();
            this._mockService = new PostService(_mockRepository.Object, _mockUnitOfWork.Object,_mockTagRepository.Object,_mockPostTagRepository.Object);
        }
    }
}
