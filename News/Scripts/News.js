$(".updateNews").on("click", function () {
    var $newsContainer = $(this).parents('.event_holder').first();
    $newsContainer.find('.event_wrapper').eq(0).hide();
    $('.update', $newsContainer).show();
})

$(".update-cancel").on("click", function() {
    var $newsContainer = $(this).parents('.event_holder').first();
    $newsContainer.find('.event_wrapper').eq(0).show();
    $('.update', $newsContainer).hide();
})

var createButton = $(".create-button");
var createPopup = document.getElementById('admin-create');

$(".create-button").on("click", function () {
    createPopup.style.display = "block";
    createButton.hide();
});

$(".decline-create").on("click", function () {
    createPopup.style.display = "none";
    createButton.show();
});

$('.button-collapse').sideNav({
    menuWidth: 300, // Default is 240
    edge: 'right', // Choose the horizontal origin
    closeOnClick: true, // Closes side-nav on <a> clicks, useful for Angular/Meteor
    draggable: true // Choose whether you can drag to open on touch screens
}
  );

//phonecatApp.controller('PhoneListController', function PhoneListController($scope) {
//    $scope.comments = [
//      {
//          name: 'Nexus S',
//          snippet: 'Fast just got faster with Nexus S.'
//      }, {
//          name: 'Motorola XOOM™ with Wi-Fi',
//          snippet: 'The Next, Next Generation tablet.'
//      }, {
//          name: 'MOTOROLA XOOM™',
//          snippet: 'The Next, Next Generation tablet.'
//      }
//    ];
//});

//angular.
//  module('phonecatApp').
//  component('phoneList', {
//      template:
//          '<ul>' +
//            '<li ng-repeat="phone in $ctrl.phones">' +
//              '<span>{{phone.name}}</span>' +
//              '<p>{{phone.snippet}}</p>' +
//            '</li>' +
//          '</ul>',
//      controller: function PhoneListController() {
//          this.phones = [
//            {
//                name: 'Nexus S',
//                snippet: 'Fast just got faster with Nexus S.'
//            }, {
//                name: 'Motorola XOOM™ with Wi-Fi',
//                snippet: 'The Next, Next Generation tablet.'
//            }, {
//                name: 'MOTOROLA XOOM™',
//                snippet: 'The Next, Next Generation tablet.'
//            }
//          ];
//      }
//  });

//angular.module('myApp', []).controller('namesCtrl', function ($scope) {
//    $scope.names = [
//        'Jani',
//        'Carl',
//        'Margareth',
//        'Hege',
//        'Joe',
//        'Gustav',
//        'Birgit',
//        'Mary',
//        'Kai'
//    ];
//});
     