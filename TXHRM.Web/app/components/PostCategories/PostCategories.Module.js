(function () {
    angular.module('TXHRM.PostCategories', ['TXHRM.Common']).config(config);
    config.$inject = ['$stateProvider', '$urlRouterProvider'];
    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('PostCategories', {
            url: "/PostCategories",
            templateUrl: "/app/components/PostCategories/PostCategoryListView.html",
            controller: "PostCategoryListController"
        });
        $stateProvider.state('PostCategoryAdd', {
            url: "/PostCategoryAdd",
            templateUrl: "/app/components/PostCategories/PostCategoryAddView.html",
            controller: "PostCategoryAddController"
        });
        $stateProvider.state('PostCategoryEdit', {
            url: "/PostCategoryEdit/:id",
            templateUrl: "/app/components/PostCategories/postCategoryEditView.html",
            controller: "postCategoryEditController"
        });
    }
})();