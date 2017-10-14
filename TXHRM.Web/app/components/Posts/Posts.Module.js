
(function () {
    angular.module('TXHRM.Posts', ['TXHRM.Common']).config(config);
    config.$inject = ['$stateProvider', '$urlRouterProvider'];
    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('Posts', {
            url: "/Posts",
            templateUrl: "/app/components/Posts/PostListView.html",
            controller: "PostListController"
        });
        $stateProvider.state('PostAdd', {
            url: "/PostAdd",
            templateUrl: "/app/components/Posts/PostAddView.html",
            controller: "PostAddController"
        });
    }
})();