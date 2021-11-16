$(document).ready(function () {
    
    fetch(_baseAddress + 'Course/getAll')
        .then(response => response.json())
        .then(data => printCourse(data));
});

function printCourse(courses) {

    let selectCourses = document.getElementById("courses");

    for (course of courses) {

        let option = document.createElement("option");
        option.value = course.id;
        option.innerHTML = course.name;

        selectCourses.appendChild(option);

    }

    console.log(courses);

}

function validate() {

    if ($('#idCard').val() === ""){
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
            StudentID: 0,
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
            StudentID: 0,
            Email: $('#Email').prop('checked'),
            Sms: $('#Sms').prop('checked'),
            DirectMail: $('#DirectMail').prop('checked'),
            PhoneCall: $('#PhoneCall').prop('checked'),

        };

        let dataSet = {

            id:0,
            idCard: $('#idCard').val(),
            name: $('#name').val(),
            lastName: $('#last_name').val(),
            age: $('#age').val(),
            email: $('#email').val(),
            phone: $('#phone').val(),
            address: $('#address').val(),
            courses:$('#courses').val().toString(),
            userNotifications: dataNotifications,
            profileInterests: dataInterest

        };

        const response = await fetch(_baseAddress + 'Student/Create', {
            method: 'POST', // *GET, POST, PUT, DELETE, etc.
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
