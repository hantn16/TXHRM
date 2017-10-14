(function (app) {
    app.factory('ApiService', ApiService);

    ApiService.$inject = ['$http', 'NotificationService'];

    function ApiService($http, NotificationService) {
        return {
            get: get,
            post: post,
            put: put,
            del: del
        };
        function get(url, params, success, failure) {
            $http.get(url, params).then(function (result) {
                success(result);
            }, function (error) {
                if (error.status === '401') {
                    NotificationService.displayError('Authenticate is required');
                } else {
                    NotificationService.displayError(error);
                }
                failure(error);
            });
        }
        function post(url, data, success, failure) {
            $http.post(url, data).then(function (result) {
                success(result);
            }, function (error) {
                if (error.status === '401') {
                    NotificationService.displayError('Authenticate is required');
                } else if (failure != null) {
                    failure(error);
                }
            });
        }
        function put(url, data, success, failure) {
            $http.put(url, data).then(function (result) {
                success(result);
            }, function (error) {
                if (error.status === '401') {
                    NotificationService.displayError('Authenticate is required');
                } else if (failure != null) {
                    failure(error);
                }
            });
        }
        function del(url, data, success, failure) {
            $http.delete(url, data).then(function (result) {
                success(result);
            }, function (error) {
                if (error.status === '401') {
                    NotificationService.displayError('Authenticate is required');
                } else if (failure != null) {
                    failure(error);
                }
            })
        }
    }
})(angular.module('TXHRM.Common'));