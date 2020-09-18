app.controller("employeeController", function ($scope, $http, $log) {
    $scope.newEmployee = null;

    $scope.resetForm = function () {
        $scope.newEmployee = null;
    }

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

    $scope.createEmployee = function () {
        $http({
            method: "POST",
            url: "https://localhost:44321/api/employees",
            data: $scope.newEmployee
        }).then(function (response) {
            $scope.getEmployees();
            $log.info;
        }).then(function (response) {
            $scope.error = response.data;
            $log.info;
        })

    };

    $scope.updateEmployee = function () {
        $http({
            method: "PUT",
            url: "https://localhost:44321/api/employees",
            data: $scope.newEmployee
        }).then(function (response) {
            $scope.getEmployees();
            $log.info;
        }).then(function (response) {
            $scope.error = response.data;
            $log.info;
        })

    };

    $scope.deleteEmployee = function (id) {
        $http.delete("https://localhost:44321/api/employees/" + id)
            .then(function (response) {
                $scope.getEmployees();
                $log.info;
            }).then(function (response) {
                $log.info;
            })
    };

    $scope.getEmployees();
    $scope.getQualifications();
    $scope.getDepartments();
    $scope.getDesignations();
});