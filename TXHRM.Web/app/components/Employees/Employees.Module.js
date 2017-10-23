(function () {
    angular.module('TXHRM.Employees', ['TXHRM.Common']).config(config);
    config.$inject = ['$stateProvider', '$urlRouterProvider'];
    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('employees', {
            url: "/employees",
            parent: 'base',
            templateUrl: "/app/components/Employees/employeeListView.html",
            controller: "employeeListController"
        });
        $stateProvider.state('employee_add', {
            url: "/employee_add",
            parent: 'base',
            templateUrl: "/app/components/Employees/employeeAddView.html",
            controller: "employeeAddController"
        });
        $stateProvider.state('employee_edit', {
            url: "/employee_edit/:id",
            parent: 'base',
            templateUrl: "/app/components/Employees/employeeEditView.html",
            controller: "employeeEditController"
        });
    }
})();