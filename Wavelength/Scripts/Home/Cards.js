var app = angular.module('Wavelength', []).controller('ViewCards', ['$scope', function ($scope) {
    var Controller = application.controllers.Cards
    /*** Constructors ********************************************************************************/
    var Card = function (Left, Right, Advanced) {
        var t = this;
        t.Left = Left;
        t.Right = Right;
        t.Advanced = Advanced;
    }
    /******************************************************************************** Constructors ***/
    /*** Declarations ********************************************************************************/
    $scope.data = {
        Cards: [],
        CreateModel: {
            Left: '',
            Right: '',
            Advanced: false
        }
    };
    /******************************************************************************** Declarations ***/
    /*** Initializations *****************************************************************************/
    $scope.data.Cards = Model;
    /***************************************************************************** Initializations ***/

    $scope.Create = function () {
        $.ajax({
            type: 'POST',
            url: Controller.Create,
            data: JSON.stringify({
                Model: $scope.data.CreateModel
            }),
            contentType: 'application/json; carset=utf-8',
            datatype: 'json',
            cache: false,
            success: function (result) {
                if (result.success) {
                    $scope.data.Cards.push(new Card(
                        result.data.Left, result.data.Right, result.data.Advanced
                    ));
                    $scope.data.CreateModel.Left = '';
                    $scope.data.CreateModel.Right = '';
                    $scope.data.CreateModel.Advanced = false;

                    $('#focus').focus();
                    $scope.$apply();
                    toastr.success(result.message);
                } else {
                    toastr.error('Error: (500) Internal Server Error<br/>' + result.message);
                }
            }
        })
    }

}])