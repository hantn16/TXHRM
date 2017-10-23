(function (app) {
    app.controller('postEditController', postEditController);
    postEditController.$inject = ['$scope', 'ApiService', 'NotificationService', '$state', '$stateParams', 'commonService'];
    function postEditController($scope, ApiService, NotificationService, $state, $stateParams, commonService) {
        $scope.post = {
            ModifiedDate: new Date()
        };
        var config = {
            params: { id: $stateParams.id }
        };
        $scope.UpdatePost = UpdatePost;

        $scope.ChooseImage = ChooseImage;

        function ChooseImage() {
            var finder = new CKFinder();
            finder.selectActionFunction = function (fileUrl) {
                $scope.post.Image = fileUrl;
            };
            finder.popup();
        }

        $scope.GetSeoTitle = GetSeoTitle;
        function GetSeoTitle() {
            $scope.post.Alias = commonService.getSeoTitle($scope.post.Name);
        };
        //Hàm Get thông tin chi tiết của đối tượng
        function LoadPostDetail() {
            ApiService.get('api/post/getdetail', config, function (result) {
                $scope.post = result.data;
            }, function (error) {
                NotificationService.displayError(error.data);
            });
        }
        //Hàm cập nhật đối tượng
        function UpdatePost() {
            ApiService.put('api/post/update', $scope.post, function (result) {
                NotificationService.displaySuccess('Cập nhật thành công');
                $state.go('posts');
            }, function (error) {
                NotificationService.displayError('Cập nhật không thành công');
            });
        }
        //khởi tạo giá trị của ListParentCategories
        //$scope.ListParentCategories = [];
        //Khai báo hàm get list parentCategories
        function GetCategories() {
            ApiService.get('api/postCategory/getall', null, function (result) {
                $scope.ListPostCategory = result.data.Items; //Gán giá trị cho ListParentCategories
            }, function (error) {
                NotificationService.displayError("Can not get list of categories");
            });
        }
        //Thực thi hàm
        GetCategories();
        LoadPostDetail();
    }
})(angular.module('TXHRM.Posts'));