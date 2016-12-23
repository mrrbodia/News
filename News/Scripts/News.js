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

var createButton = document.getElementsByClassName('create-button');
var createPopup = document.getElementById('admin-create');
createButton.onclick = function () {
    debugger;
    createPopup.style.display = "block";
    createButton.style.display = "none";
}
var declineButton = document.getElementsByClassName('decline-create');
declineButton.onclick = function () {
    debugger;
    createPopup.style.display = "none";
    createButton.style.display = "block"
}

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

angular.module('myApp', []).controller('namesCtrl', function ($scope) {
    $scope.names = [
        'Jani',
        'Carl',
        'Margareth',
        'Hege',
        'Joe',
        'Gustav',
        'Birgit',
        'Mary',
        'Kai'
    ];
});
     