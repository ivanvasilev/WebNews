angular
    .module('CrowdSourcedNews', ['ngRoute'])
    .config(function ($routeProvider) {
        $routeProvider
            .when('/', {
                templateUrl: '/app/Templates/HomeTemplate.html',
            })
            .when('/Home', {
                templateUrl: '/app/Templates/HomeTemplate.html'
            })
            .when('/Login', {
                templateUrl: '/app/Templates/LoginTemplate.html',
                controller: 'LoginController'
            })
            .when('/Register', {
                templateUrl: '/app/Templates/RegisterTemplate.html',
                controller: 'RegisterController'
            })
            .when('/AddNewsArticles', {
                templateUrl: '/app/Templates/AddNewsArticleTemplate.html',
                controller: 'AddNewsArticleController'
            })
            .when('/NewsArticles', {
                templateUrl: '/app/Templates/NewsArticleTemplate.html',
                controller: 'NewsArticlesController'
            })
            .when('/Logged', {
                templateUrl: '/app/Templates/LoggedTemplate.html',
                controller: 'LoggedController'
            })
            .when('/Contacts', {
                templateUrl: '/app/Templates/ContactsTemplate.html',
            })
            .when('/NewsArticles/details/:id', {
                templateUrl: '/app/Templates/ArticleDetailsTemplate.html',
                controller: 'ArticleDetailsController'
            })
            .when('/LiveChat', {
                templateUrl: '/app/Templates/ChatTemplate.html',
                controller: 'ChatController'
            })
    })

