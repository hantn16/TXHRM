(function (app) {
    app.controller('postAddController', postAddController);
    postAddController.$inject = ['$scope', 'ApiService', 'NotificationService', '$state', 'commonService'];
    function postAddController($scope, ApiService, NotificationService, $state, commonService) {
        $scope.post = {
            CreatedDate: new Date(),
            Status: true
        };
        $scope.addPost = addPost;
        $scope.GetSeoTitle = GetSeoTitle;
        $scope.getListPostCategory = getListPostCategory;
        $scope.ckeditorOptions = {
            language: "vi",
            height: "200px"
        };
        $scope.ChooseImage = ChooseImage;

        function ChooseImage() {
            var finder = new CKFinder();
            finder.selectActionFunction = function (fileUrl) {
                $scope.post.Image = fileUrl;
            };
            finder.popup();
        }

        function GetSeoTitle() {
            $scope.post.Alias = commonService.getSeoTitle($scope.post.Name);
        };

        function addPost(post) {
            ApiService.post('api/post/create', $scope.post, function (res) {
                NotificationService.displaySuccess('Thêm mới bài viết thành công');
                $state.go('posts');
            }, function (err) {
                NotificationService.displayError('Thêm mới bài viết thất bại');
            });
        }

        function getListPostCategory() {
            ApiService.get('api/postCategory/getall', null, function (result) {
                $scope.ListPostCategory = result.data.Items; //Gán giá trị cho ListPostCategory
            }, function (error) {
                NotificationService.displayError("Can not get list of post categories");
            });
        }
        $scope.getListPostCategory();
    }
})(angular.module('TXHRM.Posts'));