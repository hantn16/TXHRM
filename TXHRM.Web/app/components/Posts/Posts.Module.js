
(function () {
    angular.module('TXHRM.Posts', ['TXHRM.Common']).config(config);
    config.$inject = ['$stateProvider', '$urlRouterProvider'];
    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('posts', {
            url: "/posts",
            parent: 'base',
            templateUrl: "/app/components/Posts/PostListView.html",
            controller: "postListController"
        });
        $stateProvider.state('post_add', {
            url: "/post_add",
            parent: 'base',
            templateUrl: "/app/components/Posts/postAddView.html",
            controller: "postAddController"
        });
        $stateProvider.state('post_edit', {
            url: "/post_edit/:id",
            parent: 'base',
            templateUrl: "/app/components/Posts/postEditView.html",
            controller: "postEditController"
        });
    }
})();