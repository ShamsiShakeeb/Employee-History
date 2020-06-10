
$(document).ready(function () {
    $("form").submit(function (event) {
        event.preventDefault();
        var value = {
            eid: $("#EID").val(),
            first_Name: $("#First_Name").val(),
            last_Name: $("#Last_Name").val(),
            designation: $("#Designation").val(),
            join_Date: $("#Join_Date").val(),
            current_Salary: $("#Current_Salary").val(),
            department: $("#Department").val(),
            next_Review_Date: $("#Next_Review_Date").val(),
            date_Of_Birth: $("#Date_Of_Birth").val(),
            gender: $("#Gender").val(),
        };
        
        $.ajax({
            url: '/api/UpdateEmployee/'+value.eid,
            headers: { 'ApiKey': 'PiTech_JWT_TOKEN' },
            type: 'PUT',
            dataType: 'json',
            data: value,
            success: function (data, textStatus, xhr) {
                swal({
                    icon: 'success',
                    title: 'Enployee Updated',
                    text: '',
                });
                EmployeeTable.ajax.reload();
            },
            error: function (xhr, textStatus, errorThrown) {

                swal({
                    icon: 'error',
                    title: 'Oopss',
                    text: 'Please Fill Up Every Filed With Proper Information',
                });

            }
        });
    });
});
