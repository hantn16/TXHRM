﻿(function (app) {
    app.controller('postListController', postListController);
    postListController.$inject = ['$scope', 'ApiService', 'NotificationService', '$ngBootbox', '$filter'];
    function postListController($scope, ApiService, NotificationService, $ngBootbox, $filter) {
        $scope.posts = [];
        $scope.page = 0;
        $scope.pagesCount = 0;
        $scope.keyWord = '';
        $scope.getPosts = getPosts;
        $scope.search = search;
        $scope.deletePost = deletePost;
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
            ApiService.del('api/post/deletemulti', config, function (res) {
                NotificationService.displaySuccess('Xóa thành công ' + res.data.length + ' bản ghi');
                search();
            }, function () {
                NotificationService.displayError('Xóa thất bại!!!');
            });
        }

        function selectAll() {
            if ($scope.isAll === false) {
                angular.forEach($scope.posts, function (item) {
                    item.checked = true;
                });
                $scope.isAll = true;
            } else {
                angular.forEach($scope.posts, function (item) {
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

        function deletePost(id) {
            $ngBootbox.confirm('Bạn chắc chắn xóa bài viết này?').then(function () {
                var config = { params: { id: id } };
                ApiService.del('api/post/delete', config, function (result) {
                    NotificationService.displaySuccess('Xóa bài viết thành công!!!');
                    search();
                }, function () {
                    NotificationService.displayError('Xóa bài viết thất bại!!!');
                });
            });
        }
        function search() {
            getPosts();
        }

        function getPosts(page) {
            page = page || 0;
            var config = {
                params: {
                    page: page,
                    pageSize: 5,
                    keyWord: $scope.keyWord
                }
            };
            ApiService.get('api/post/getallpaged', config, function (result) {
                $scope.posts = result.data.Items;
                $scope.page = result.data.Page;
                $scope.pagesCount = result.data.TotalPages;
                $scope.totalCount = result.data.TotalCount;
                $scope.pageRowCount = result.data.Count;
            }, function () {
                NotificationService.displayError('Load posts failed.');
            });
        }

        $scope.getPosts();
    }
})(angular.module('TXHRM.Posts'));