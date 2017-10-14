(function (app) {
    app.controller('PostCategoryListController', PostCategoryListController);

    PostCategoryListController.$inject = ['$scope', 'ApiService', 'NotificationService', '$ngBootbox','$filter'];
    function PostCategoryListController($scope, ApiService, NotificationService, $ngBootbox, $filter) {
        $scope.postCategories = [];
        $scope.page = 0;
        $scope.pagesCount = 0;
        $scope.keyWord = '';
        $scope.getPostCagories = getPostCagories;
        $scope.search = search;
        $scope.deletePostCategory = deletePostCategory;
        $scope.selectAll = selectAll;
        $scope.isAll = false;
        $scope.deleteMultiple = deleteMultiple;

        function deleteMultiple() {
            var idArr = [];
            $scope.selected.forEach(function (item) {
                idArr.push(item.ID);
            });
            var jsonString = JSON.stringify(idArr);
            var config = { params: { jsonListID: jsonString } };
            ApiService.del('api/postCategory/deletemulti', config, function (res) {
                NotificationService.displaySuccess('Xóa thành công ' + res.data.length + ' bản ghi');
                search();
            }, function () {
                NotificationService.displayError('Xóa thất bại!!!');
            });
        }

        function selectAll() {
            if ($scope.isAll===false) {
                angular.forEach($scope.postCategories, function (item) {
                    item.checked = true;
                });
                $scope.isAll = true;
            } else {
                angular.forEach($scope.postCategories, function (item) {
                    item.checked = false;
                });
                $scope.isAll = false;
            }
        }
        //Hàm kiểm tra danh sách có bản ghi nào đc chọn không?
        $scope.$watch('postCategories', function (newValue, oldValue) {
            //Lọc những phần tử checked
            var checkedArr = $filter('filter')(newValue, { checked: true });
            if (checkedArr.length) { //Nếu có ít nhất 1 phần tử checked
                $scope.selected = checkedArr;  //gán vào scope
                $('#btnDelete').removeAttr('disabled'); //enable nút xóa nhiều bản ghi
            } else {
                $('#btnDelete').attr('disabled', 'disabled'); //disabled nút xóa nhiều bản ghi
            }
        }, true);

        function deletePostCategory(id) {
            $ngBootbox.confirm('Bạn chắc chắn xóa danh mục này?').then(function () {
                var config = { params: { id: id } };
                ApiService.del('api/postCategory/delete', config, function (result) {
                    NotificationService.displaySuccess('Xóa danh mục '+result.data.Name+' thành công!!!');
                    search();
                }, function () {
                    NotificationService.displayError('Xóa danh mục thất bại!!!');
                });
            });
        }
        function search() {
            getPostCagories();
        }

        function getPostCagories(page) {
            page = page || 0;
            var config = {
                params: {
                    page: page,
                    pageSize: 2,
                    keyWord: $scope.keyWord
                }
            };
            ApiService.get('api/postCategory/getall', config, function (result) {
                $scope.postCategories = result.data.Items;
                $scope.page = result.data.Page;
                $scope.pagesCount = result.data.TotalPages;
                $scope.totalCount = result.data.TotalCount;
                $scope.pageRowCount = result.data.Count;
            }, function () {
                NotificationService.displayError('Load productcategory failed.');
            });
        }

        $scope.getPostCagories();
    }
})(angular.module('TXHRM.PostCategories'));