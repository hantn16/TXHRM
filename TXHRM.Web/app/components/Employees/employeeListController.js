(function (app) {
    app.controller('employeeListController', employeeListController);
    employeeListController.$inject = ['$scope', 'ApiService', 'NotificationService', '$ngBootbox', '$filter'];
    function employeeListController($scope, ApiService, NotificationService, $ngBootbox, $filter) {
        $scope.employees = [];
        $scope.page = 0;
        $scope.pagesCount = 0;
        $scope.keyWord = '';
        $scope.getEmployees = getEmployees;
        $scope.search = search;
        $scope.deleteEmployee = deleteEmployee;
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
            ApiService.del('api/employee/deletemulti', config, function (res) {
                NotificationService.displaySuccess('Xóa thành công ' + res.data.length + ' bản ghi');
                search();
            }, function () {
                NotificationService.displayError('Xóa thất bại!!!');
            });
        }

        function selectAll() {
            if ($scope.isAll === false) {
                angular.forEach($scope.employees, function (item) {
                    item.checked = true;
                });
                $scope.isAll = true;
            } else {
                angular.forEach($scope.employees, function (item) {
                    item.checked = false;
                });
                $scope.isAll = false;
            }
        }
        //Hàm kiểm tra danh sách có bản ghi nào đc chọn không?
        $scope.$watch('posts', function (newValue, oldValue) {
            //Lọc những phần tử checked
            var checkedArr = [];
            checkedArr = $filter('filter')(newValue, { checked: true });
            if (checkedArr.length) { //Nếu có ít nhất 1 phần tử checked
                $scope.selected = checkedArr;  //gán vào scope
                $('#btnDelete').removeAttr('disabled'); //enable nút xóa nhiều bản ghi
            } else {
                $('#btnDelete').attr('disabled', 'disabled'); //disabled nút xóa nhiều bản ghi
            }
        }, true);

        function deleteEmployee(id) {
            $ngBootbox.confirm('Bạn chắc chắn xóa?').then(function () {
                var config = { params: { id: id } };
                ApiService.del('api/employee/delete', config, function (result) {
                    NotificationService.displaySuccess('Xóa thành công!!!');
                    search();
                }, function () {
                    NotificationService.displayError('Xóa thất bại!!!');
                });
            });
        }
        function search() {
            getEmployees();
        }

        function getEmployees(page) {
            page = page || 0;
            var config = {
                params: {
                    page: page,
                    pageSize: 5,
                    keyWord: $scope.keyWord
                }
            };
            ApiService.get('api/employee/getallpaged', config, function (result) {
                $scope.employees = result.data.Items;
                $scope.page = result.data.Page;
                $scope.pagesCount = result.data.TotalPages;
                $scope.totalCount = result.data.TotalCount;
                $scope.pageRowCount = result.data.Count;
            }, function () {
                NotificationService.displayError('Load employees failed.');
            });
        }

        $scope.getEmployees();
    }
})(angular.module('TXHRM.Employees'));