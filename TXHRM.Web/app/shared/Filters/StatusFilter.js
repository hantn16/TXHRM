(function (app) {
    app.filter('StatusFilter', function () {
        return function (input) {
            if (input) {
                return 'Kích hoạt';
            } else {
                return 'Khóa';
            }
        };
    });
})(angular.module('TXHRM.Common'));