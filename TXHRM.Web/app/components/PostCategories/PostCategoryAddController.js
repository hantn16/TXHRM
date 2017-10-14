(function (app) {
    app.controller('PostCategoryAddController', PostCategoryAddController);
    PostCategoryAddController.$inject = ['$scope', 'ApiService', 'NotificationService', '$state','commonService'];
    function PostCategoryAddController($scope, ApiService, NotificationService, $state, commonService) {
        $scope.postCategory = {
            CreatedDate: new Date(),
            Status: true
        };
        $scope.AddPostCategory = AddPostCategory;
        $scope.GetSeoTitle = GetSeoTitle;

        function GetSeoTitle() {
            $scope.postCategory.Alias = commonService.getSeoTitle($scope.postCategory.Name);
        };

        function AddPostCategory() {
            ApiService.post('api/postCategory/create', $scope.postCategory, function (result) {
                NotificationService.displaySuccess('Danh mục ' + result.data.Name + 'đã được thêm mới thành công');
                $state.go('PostCategories');
            }, function (error) {
                NotificationService.displayError('Thêm mới không thành công');
            });
        }
        //khởi tạo giá trị của ListParentCategories
        //$scope.ListParentCategories = [];
        //Khai báo hàm get list parentCategories
        function GetParentCategories() {
            ApiService.get('api/postCategory/getall', null, function (result) {
                $scope.ListParentCategories = result.data.Items; //Gán giá trị cho ListParentCategories
            }, function (error) {
                console.log("Can not get list of parent categories");
            });
        }
        //Thực thi hàm
        GetParentCategories();
    }
})(angular.module('TXHRM.PostCategories'));