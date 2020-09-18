app.controller("employeeController", function ($scope, $http, $log) {

    /*$scope.firstName = null;
    $scope.lastName = null;
    $scope.dob = new Date();
    $scope.doj = new Date();
    $scope.gender = new Boolean();
    $scope.qualificationId = 0;
    $scope.departmentId = 0;
    $scope.departmentName = 0;
    $scope.managerId = 0;
    $scope.mFirstName = null;
    $scope.mLastName = null;
*/

    $scope.getEmployees = function () {

        $http.get("https://localhost:44321/api/employees")
            .then(function (response) {
                $scope.employees = response.data.result;
                $log.info;
            }, function (response) {
                $scope.error = response.data;
                $log.info;
            }
            );
    }

    $scope.getQualifications = function () {
        $http.get("https://localhost:44321/api/qualifications")
            .then(function (response) {
                $scope.qualifications = response.data.result;
                $log.info;
            }, function (response) {
                $scope.error = response.data;
                $log.info;
            }
            );
    }

    $scope.getDepartments = function () {
        $http.get("https://localhost:44321/api/departments")
            .then(function (response) {
                $scope.departments = response.data.result;
                $log.info;
            }, function (response) {
                $scope.error = response.data;
                $log.info;
            }
            );
    }

    $scope.getDesignations = function () {
        $http.get("https://localhost:44321/api/designations")
            .then(function (response) {
                $scope.designations = response.data.result;
                $log.info;
            }, function (response) {
                $scope.error = response.data;
                $log.info;
            }
            );
    }

    /*$scope.createEmployee = function () {
        var emp = $scope.newEmployee;
        emp.ManagerId = emp.manager.

        $http({
            method: "POST",
            url: "https://localhost:44321/api/employees",
            data: emp
        }).success(function (response) {
            $scope.getEmployee();
            $log.info;
        }).error(function (response) {
            $scope.error = response.data;
            $log.info;
        })

    };*/

    $scope.deleteEmployee = function (id) {
        $http.delete("https://localhost:44321/api/employees/" + id)
            .success(function (response) {
                $scope.getEmployee();
                $log.info;
            }).error(function (response) {
                $log.info;
            })
    };

    $scope.getEmployees();
    $scope.getQualifications();
    $scope.getDepartments();
    $scope.getDesignations();
});