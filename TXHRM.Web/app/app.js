
(function () {
    angular.module('TXHRM', ['TXHRM.Posts','TXHRM.PostCategories','TXHRM.Common']).config(config);
    config.$inject = ['$stateProvider', '$urlRouterProvider'];
    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('Home', {
            url: '/admin',
            templateUrl: '/app/components/Home/HomeView.html',
            controller: 'HomeController'
        });
        $urlRouterProvider.otherwise('/admin');
    }
})();