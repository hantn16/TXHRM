(function () {
    angular.module('TXHRM.PostCategories', ['TXHRM.Common']).config(config);
    config.$inject = ['$stateProvider', '$urlRouterProvider'];
    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('PostCategories', {
            url: "/PostCategories",
            parent: 'base',
            templateUrl: "/app/components/PostCategories/PostCategoryListView.html",
            controller: "PostCategoryListController"
        });
        $stateProvider.state('PostCategoryAdd', {
            url: "/PostCategoryAdd",
            parent: 'base',
            templateUrl: "/app/components/PostCategories/PostCategoryAddView.html",
            controller: "PostCategoryAddController"
        });
        $stateProvider.state('PostCategoryEdit', {
            url: "/PostCategoryEdit/:id",
            parent: 'base',
            templateUrl: "/app/components/PostCategories/postCategoryEditView.html",
            controller: "postCategoryEditController"
        });
    }
})();