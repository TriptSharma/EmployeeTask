app.controller("employeeController", function ($scope, $http, $log) {

    $scope.resetForm = function () {
        $scope.newEmployee = null;
        $scope.curEmployee = null;
        $scope.createFormButton = "Create";
    }

    $scope.setDate = function (datestring) {
        return new Date(datestring.substring(0, 4), datestring.substring(5, 7), datestring.substring(8,10));
    }

    var map = function (employee) {
        $scope.newEmployee = {
            EmployeeId : employee.eId,
            FirstName : employee.eFirstName,
            LastName : employee.eLastName,
            Gender : employee.eGender,
            Dob : employee.eDob,
            Doj : employee.eDoj,
            DesignationId : employee.eDesignationId,
            QualificationId : employee.eQualificationId,
            ManagerId : employee.emId
        };
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

    $scope.getEmployee = function (id) {

        $http.get("https://localhost:44321/api/employees/" + id)
            .then(function (response) {
                $scope.curEmployee = response.data.result;
                console.log(curEmployee);
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
        }, function (response) {
            $scope.error = response.data;
            $log.info;
        });

    }

    $scope.fillForm = function (employee) {
        $scope.newEmployee = angular.copy(employee);
        $scope.newEmployee.Dob = $scope.setDate(employee.Dob);
        $scope.newEmployee.Doj = $scope.setDate(employee.Doj);

        $scope.createFormButton = "Update";
        console.log($scope.newEmployee);
    }

    $scope.updateEmployee = function () {
        $http({
            method: "PUT",
            url: "https://localhost:44321/api/employees",
            data: $scope.newEmployee
        }).then(function (response) {
            $scope.getEmployees();
            $scope.resetForm();
            $log.info;
        }, function (response) {
            $scope.error = response.data;
            $log.info;
        });

    }

    $scope.deleteEmployee = function (id) {
        $http.delete("https://localhost:44321/api/employees/" + id)
            .then(function (response) {
                $scope.getEmployees();
                $log.info;
            }, function (response) {
                $log.info;
            });
    }

    $scope.resetForm();
    $scope.getEmployees();
    $scope.getQualifications();
    $scope.getDepartments();
    $scope.getDesignations();
});