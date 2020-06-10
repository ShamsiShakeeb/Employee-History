var EmployeeTable;

$(document).ready(function () {
    loadEmployeeTable();
});

function loadEmployeeTable() {
    EmployeeTable = $('#List').DataTable({
        "ajax": {
            "url": "/api/EmployeeList",
            "headers": { "ApiKey": "PiTech_JWT_TOKEN" },
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "eid", "width": "5%" },
            { "data": "first_Name", "width": "10%" },
            { "data": "last_Name", "width": "10%" },
            { "data": "designation", "width": "10%" },
            { "data": "join_Date", "width": "15%" },
            { "data": "current_Salary", "width": "10%" },
            { "data": "department", "width": "10%" },
            { "data": "next_Review_Date", "width": "15%" },
            { "data": "date_Of_Birth", "width": "15%" },
            { "data": "gender", "width": "10%" },
            {
                "data": "eid",
                "render": function (data) {
                    return `<div class="text-center">
                        <button onClick="Delete(${data});" class='btn btn-success text-white' style='cursor:pointer; width:90px;'>
                            Delete
                        </button>
                        &nbsp;
                        <a href="/Employees/Update/${data}"  class='btn btn-danger text-white' style='cursor:pointer; width:90px;' onclick=Block(${data})>
                            Update
                        </a>
                        </div>`;
                }, "width": "40%"
            }
        ],
        "language": {
            "emptyTable": "no data found"
        },
        "width": "100%"
    });
  
}



function Delete(uri) {

    swal({
        title: "Are you sure?",
        text: "Want to Delete",
        icon: "warning",
        buttons: true,
        dangerMode: true
    }).then((willDelete) => {
        if (willDelete) {

           /* var value = {
                id: $("#Delete").val(),
            };*/
            //// document.writeln(value.email);
            $.ajax({
                url: '/api/DeleteEmployee/' + uri,
                headers: { 'ApiKey': 'PiTech_JWT_TOKEN' },
                type: 'DELETE',
                dataType: 'json',
                /// data: value,
                success: function (data, textStatus, xhr) {
                    swal({
                        icon: 'success',
                        title: 'Deleted',
                        text: 'The Employee Has Deleted Successfully',
                    });
                    EmployeeTable.ajax.reload();
                },
                error: function (xhr, textStatus, errorThrown) {

                    swal({
                        icon: 'error',
                        title: 'Ooopsss!',
                        text: 'Something Went Wrong',
                    });

                }
            });
        }
    });


}

$(document).ready(function () {
    $("form").submit(function (event) {
        event.preventDefault();
        var value = {
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
           
            url: '/api/PostEmployee/',
            headers: { 'ApiKey': 'PiTech_JWT_TOKEN' },
            type: 'POST',
            dataType: 'json',
            data: value,
            success: function (data, textStatus, xhr) {
                swal({
                    icon: 'success',
                    title: 'New Employee Added',
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

