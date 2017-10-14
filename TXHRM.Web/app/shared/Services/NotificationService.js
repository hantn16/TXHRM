(function (app) {
    app.factory('NotificationService', NotificationService);

    function NotificationService() {
        toastr.options = {
            "debug": false,
            "positionClass": "toast-top-right",
            "onClick": null,
            "fadeIn": 300,
            "fadeOut": 1000,
            "timeOut": 3000,
            "extendedTimeOut": 1000
        };

        function displaySuccess(message) {
            toastr.success(message);
        }
        function displayError(error) {
            if (Array.isArray(error)) {
                error.forEach(function (err) {
                    toastr.error(err);
                });
            } else {
                toastr.error(error);
            }
        }
        function displayWarning(message) {
            toastr.warning(message);
        }
        function displayInfo(message) {
            toastr.info(message);
        }
        return {
            displaySuccess: displaySuccess,
            displayInfo: displayInfo,
            displayWarning: displayWarning,
            displayError: displayError
        };
    }
})(angular.module('TXHRM.Common'));