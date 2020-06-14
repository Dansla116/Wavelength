var app = angular.module('Wavelength', []).controller('Play', ['$scope', function ($scope) {
    var Controller = application.controllers.Play;
    /*** Constructors ********************************************************************************/
    var SelectOption = function (id, Name) {
        var t = this;
        t.id = id;
        t.Name = Name;
    }
    /******************************************************************************** Constructors ***/
    /*** Declarations ********************************************************************************/
    $scope.States = [];
    $scope.Roles = [];
    /******************************************************************************** Declarations ***/
    /*** Initializations *****************************************************************************/
    $.each(Model.States, function (i, s) {
        $scope.States.push(new SelectOption(parseInt(s.Value), s.Text));
    });
    $.each(Model.Roles, function (i, r) {
        $scope.Roles.push(new SelectOption(parseInt(r.Value), r.Text));
    });

    $scope.LocalUser = {
        Role: $scope.Roles[0].id,
        Name: ''
    }
    $scope.JoinModel = {
        Code: '',
        Name: ''
    }
    /***************************************************************************** Initializations ***/
    $scope.Join = function () {
        $.ajax({
            type: 'POST',
            url: Controller.Join,
            data: JSON.stringify({
                Code: $scope.JoinModel.Code,
                Name: $scope.JoinModel.Name
            }),
            contentType: 'application/json; carset=utf-8',
            datatype: 'json',
            cache: false,
            success: function (result) {
                if (result.success) {
                    $scope.Game = result.data.Game;
                    $scope.LocalUser = result.data.LocalUser;
                    $scope.Users = result.data.Users;

                    $('#focus').focus();
                    $scope.$apply();
                    toastr.success(result.message);
                } else {
                    toastr.error('Error: (500) Internal Server Error<br/>' + result.message);
                }
            }
        });
    };

    $scope.Start = function () {
        $.ajax({
            type: 'POST',
            url: Controller.Start,
            data: JSON.stringify({
                Code: $scope.Game.Code,
                Users: $scope.Users
            }),
            contentType: 'application/json; carset=utf-8',
            datatype: 'text',
            cache: false,
            success: function (result) {
                if (result.success) {
                    // response here
                    $scope.$apply();
                    toastr.success(result.message);
                } else {
                    toastr.error('Error: (500) Internal Server Error<br/>' + result.message);
                }
            }
        });
    };

    $scope.SetupPsychic = function () {
        $.ajax({
            type: 'POST',
            url: Controller.SetupPsychic,
            data: JSON.stringify({
                Code: $scope.Game.Code,
                Psychic: $scope.LocalUser,
                Users: $scope.Users
            }),
            contentType: 'application/json; carset=utf-8',
            datatype: 'json',
            cache: false,
            success: function (result) {
                if (result.success) {
                    // response here
                    $scope.$apply();
                    toastr.success(result.message);
                } else {
                    toastr.error('Error: (500) Internal Server Error<br/>' + result.message);
                }
            }
        });
    };

    /*** SignalR */
    //$scope.Connection = new signalR.HubConnectionBuilder().withUrl("/playHub").build();
    $scope.Connection.PlayHub.client.getUsers = function (result) {
        if (result !== null) {
            $scope.Users = Users;
        }
    };


/*    $scope.Connection.UpdatesUsers("UpdateUsers", function (Users) {
        $scope.Users = Users;
    });*/
}]);