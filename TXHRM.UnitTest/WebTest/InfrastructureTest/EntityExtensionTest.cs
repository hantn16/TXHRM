using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TXHRM.Model.Models;
using TXHRM.Web.Infrastructure.Extensions;
using TXHRM.Web.Models;

namespace TXHRM.UnitTest.WebTest.InfrastructureTest
{
    [TestClass]
    public class EntityExtensionTest
    {
        [TestInitialize]
        public void Initialize()
        {
            //dbFactory = new DbFactory();
            //postCategoryRepository = new PostCategoryRepository(dbFactory);
            //unitOfWork = new UnitOfWork(dbFactory);
        }
        [TestMethod]
        public void EntityExtension_UpdateFromViewModel_Test()
        {
            PostCategory postCategory = new PostCategory();
            PostCategoryViewModel postCategoryViewModel = new PostCategoryViewModel() {
                ID = 1, Name = "Tin trong nước", Alias = "tin-trong-nuoc", Status = true, CreatedDate = DateTime.Now
            };
            postCategory.UpdateFromViewModel<PostCategory, PostCategoryViewModel>(postCategoryViewModel);

            Assert.AreEqual(postCategoryViewModel.ID, postCategory.ID);
        }
    }
}
