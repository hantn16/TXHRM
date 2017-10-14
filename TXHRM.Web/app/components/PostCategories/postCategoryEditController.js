(function (app) {
    app.controller('postCategoryEditController', postCategoryEditController);
    postCategoryEditController.$inject = ['$scope', 'ApiService', 'NotificationService', '$state', '$stateParams','commonService'];
    function postCategoryEditController($scope, ApiService, NotificationService, $state, $stateParams, commonService) {
        $scope.postCategory = {
            ModifiedDate: new Date()
        };
        var config = {
            params: { id: $stateParams.id }
        };
        $scope.UpdatePostCategory = UpdatePostCategory;
        $scope.GetSeoTitle = GetSeoTitle;
        function GetSeoTitle () {
            $scope.postCategory.Alias = commonService.getSeoTitle($scope.postCategory.Name);
        };
        //Hàm Get thông tin chi tiết của đối tượng
        function LoadPostCategoryDetail() {
            ApiService.get('api/postCategory/getdetail',config, function (result) {
                $scope.postCategory = result.data;
            }, function (error) {
                NotificationService.displayError(error.data);
            });
        }
        //Hàm cập nhật đối tượng
        function UpdatePostCategory() {
            ApiService.put('api/postCategory/update', $scope.postCategory, function (result) {
                NotificationService.displaySuccess('Cập nhật thành công');
                $state.go('PostCategories');
            }, function (error) {
                NotificationService.displayError('Cập nhật không thành công');
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
        LoadPostCategoryDetail();
    }
})(angular.module('TXHRM.PostCategories'));