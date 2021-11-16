$(document).ready(function () {
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
        td.appendChild(edit_button);

        
        let delete_button = document.createElement("button");
        delete_button.className = "btn btn-danger";
        delete_button.innerHTML = "Delete";

        delete_button.onclick = function () {

            

            const response = await fetch(_baseAddress + 'Student/Delete/' + student.id , {
                method: 'DELETE', // *GET, POST, PUT, DELETE, etc.
                // mode: 'cors', // no-cors, *cors, same-origin
                
                
            });
            
        }

        td.appendChild(delete_button);

        tr.appendChild(td);

        t_body.appendChild(tr);
    }
    
}

function createStudent() {


}