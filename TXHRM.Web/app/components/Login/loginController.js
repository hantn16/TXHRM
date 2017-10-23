(function (app) {
    app.controller('loginController', loginController);
    loginController.$inject = ['$scope','$injector','loginService','NotificationService'];

    function loginController($scope, $injector, loginService, NotificationService) {
        $scope.loginData = {
            userName : "",
            password : ""
        };
        $scope.loginSubmit = loginSubmit;

        function loginSubmit() {
            loginService.login($scope.loginData.userName, $scope.loginData.password).then(function (res) {
                if (res !== null && res.data.error !== undefined) {
                    if (res.data.error === "invalid_grant") {
                        NotificationService.displayError("Tài khoản hoặc mật khẩu không đúng!!!");
                    } else if (res.data.error === "server_error") {
                        NotificationService.displayError("Lỗi đăng nhập hệ thống!!!");
                    } else {
                        NotificationService.displayError(res.data.error);
                    }
                } else {
                    var stateService = $injector.get('$state');
                    stateService.go('Home');
                }
            });
        }
    }
})(angular.module('TXHRM'));