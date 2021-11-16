$(document).ready(function () {
    var id = 0;
    fetch(_baseAddress + 'Student/getAll')
        .then(response => response.json())
        .then(data => printStudents(data));
});
function printStudents(students) {
    let t_body = document.getElementById("app_tbody");
    for (student of students) {
        let tr = document.createElement("tr");
        let td = document.createElement("td");

        td.innerHTML = student.idCard;
        tr.appendChild(td);

        td = document.createElement("td");
        td.innerHTML = student.name;
        tr.appendChild(td);

        td = document.createElement("td");
        td.innerHTML = student.lastName;
        tr.appendChild(td);

        td = document.createElement("td");
        td.innerHTML = student.email;
        tr.appendChild(td);

        td = document.createElement("td");
        td.innerHTML = student.phone;
        tr.appendChild(td);

        td = document.createElement("td");
        td.innerHTML = student.address;
        tr.appendChild(td);

        td = document.createElement("td");
        let view_button = document.createElement("button");
        view_button.className = "btn btn-primary";
        view_button.innerHTML = "View";
        //view_button.onclick("")
        td.appendChild(view_button);

        
        let edit_button = document.createElement("button");
        edit_button.className = "btn btn-success";
        edit_button.innerHTML = "Edit";
        edit_button.id = student.id;
        edit_button.onclick = function () {

            editStudent(this.id);
        };
        td.appendChild(edit_button);

        
        let delete_button = document.createElement("button");
        delete_button.className = "btn btn-danger";
        delete_button.innerHTML = "Delete";
        delete_button.id = student.id;
        //delete_button.addEventListener('click', deleteStudent);

        delete_button.onclick = function () {

            deleteStudent(this.id);
        }
            
        
        //    const response = await fetch(_baseAddress + 'Student/Delete/' + student.id , {
        //        method: 'DELETE', // *GET, POST, PUT, DELETE, etc.
        //        // mode: 'cors', // no-cors, *cors, same-origin
                
                
        //    });
            
        //}


        td.appendChild(delete_button);

        tr.appendChild(td);

        t_body.appendChild(tr);
    }
    
}

async function deleteStudent(idStudent) {

    console.log(idStudent);
    const response = await fetch(_baseAddress + 'Student/Delete?pId=' + idStudent, {
               method: 'DELETE', // *GET, POST, PUT, DELETE, etc.
               
    });
    if (response.status === 200) {
        location.reload();
    }
    console.log(response);
}

async function editStudent(idStudent) {

    const response = await fetch(_baseAddress + 'Student/GetById?pId=' + idStudent, {
        method: 'GET', // *GET, POST, PUT, DELETE, etc.

    }).then(response => response.json())
        .then(data => setEdit(data));
    //console.log(response);
}

function setEdit(student) {

    if (student != undefined) {

        id = student.id;
        fetch(_baseAddress + 'Course/getAll')
            .then(response => response.json())
            .then(data => printCourse(data));

        $('#table_students').hide();
        $('#create_student').hide();

        $('#idCard').val(student.idCard);
        $('#name').val(student.name);
        $('#last_name').val(student.lastName);
        $('#age').val(student.age);
        $('#phone').val(student.phone);
        $('#email').val(student.email);
        $('#address').val(student.address);

        $('#Entertainment').attr('checked', student.profileInterests.Entertainment);
        $('#Gastronomy').attr('checked', student.profileInterests.Gastronomy);
        $('#Fashion').attr('checked',student.profileInterests.Fashion);
        $('#Travels').attr('checked',student.profileInterests.Travels);
        $('#Home').attr('checked',student.profileInterests.Home);
        $('#Technology').attr('checked',student.profileInterests.Technology);
        $('#sports').attr('checked',student.profileInterests.sports);
        $('#Music').attr('checked',student.profileInterests.Music);
        $('#HealthAndBeauty').attr('checked',student.profileInterests.HealthAndBeauty);
        $('#Vehicles').attr('checked',student.profileInterests.Vehicles);
        $('#Pets').attr('checked',student.profileInterests.Pets);
        $('#ArtAndCulture').attr('checked',student.profileInterests.ArtAndCulture);
        $('#Mechanics').attr('checked',student.profileInterests.Mechanics);
        $('#Books').attr('checked',student.profileInterests.Books);
        $('#photography').attr('checked',student.profileInterests.photography);

        $('#Email').attr('checked', student.userNotifications.Email);
        $('#Sms').attr('checked', student.userNotifications.Sms);
        $('#PhoneCall').attr('checked', student.userNotifications.PhoneCall);
        $('#DirectMail').attr('checked', student.userNotifications.DirectMail);
        $('#edit_student').show();
        
    }
}




function printCourse(courses) {

    let selectCourses = document.getElementById("courses");

    for (course of courses) {

        let option = document.createElement("option");
        option.value = course.id;
        option.innerHTML = course.name;

        selectCourses.appendChild(option);

    }
}

function validate() {

    if ($('#idCard').val() === "") {
        alert('idCard Field is require');
        return false;
    }
    if ($('#name').val() === "") {
        alert('Name Field is require');
        return false;
    }
    if ($('#last_name').val() === "") {
        alert('Lastname Field is require');
        return false;
    }
    if ($('#age').val() === "") {
        alert('Age Field is require');
        return false;
    }
    if ($('#phone').val() === "") {
        alert('Phone Field is require');
        return false;
    }
    if ($('#email').val() === "") {
        alert('Email Field is require');
        return false;
    }
    if ($('#address').val() === "") {
        alert('Address Field is require');
        return false;
    }
}
async function save() {
    if (validate() != false) {
        let dataInterest =
        {
            id: 0,
            StudentID: id,
            Entertainment: $('#Gastronomy').prop('checked'),
            Gastronomy: $('#Gastronomy').prop('checked'),
            Fashion: $('#Fashion').prop('checked'),
            Travels: $('#Travels').prop('checked'),
            Home: $('#Home').prop('checked'),
            Technology: $('#Technology').prop('checked'),
            sports: $('#sports').prop('checked'),
            Music: $('#Music').prop('checked'),
            HealthAndBeauty: $('#HealthAndBeauty').prop('checked'),
            Vehicles: $('#Vehicles').prop('checked'),
            Pets: $('#Pets').prop('checked'),
            ArtAndCulture: $('#ArtAndCulture').prop('checked'),
            Mechanics: $('#Mechanics').prop('checked'),
            Books: $('#Books').prop('checked'),
            Photography: $('#Photography').prop('checked'),
        };

        let dataNotifications = {
            id: 0,
            StudentID: id,
            Email: $('#Email').prop('checked'),
            Sms: $('#Sms').prop('checked'),
            DirectMail: $('#DirectMail').prop('checked'),
            PhoneCall: $('#PhoneCall').prop('checked'),

        };

        let dataSet = {

            id: id,
            idCard: $('#idCard').val(),
            name: $('#name').val(),
            lastName: $('#last_name').val(),
            age: $('#age').val(),
            email: $('#email').val(),
            phone: $('#phone').val(),
            address: $('#address').val(),
            courses: $('#courses').val().toString(),
            userNotifications: dataNotifications,
            profileInterests: dataInterest

        };

        const response = await fetch(_baseAddress + 'Student/Update', {
            method: 'PUT', // *GET, POST, PUT, DELETE, etc.
            // mode: 'cors', // no-cors, *cors, same-origin
            cache: 'no-cache', // *default, no-cache, reload, force-cache, only-if-cached
            // credentials: 'same-origin', // include, *same-origin, omit
            headers: {
                'Content-Type': 'application/json'
                // 'Content-Type': 'application/x-www-form-urlencoded',
            },
            redirect: 'follow', // manual, *follow, error
            referrerPolicy: 'no-referrer', // no-referrer, *no-referrer-when-downgrade, origin, origin-when-cross-origin, same-origin, strict-origin, strict-origin-when-cross-origin, unsafe-url
            body: JSON.stringify(dataSet) // body data type must match "Content-Type" header
        });
        return response.json(); // parses JSON response into native JavaScript objects
    }
}
