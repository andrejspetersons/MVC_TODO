function toggleTodo(itemId) {
    var checkbox = document.getElementById("checkbox_" + itemId);
    var completedInput = document.getElementById("completed_" + itemId);

    completedInput.value = checkbox.checked;

    var formData = new FormData();
    formData.append("id", itemId);
    formData.append("completed", checkbox.checked);

    var xhr = new XMLHttpRequest();
    xhr.open("POST", "/ToDoItem/ToggleTodo", true);
    xhr.onload = function () {
        if (xhr.status === 200) {
            console.log("Toggle request successful");
        } else {
            console.error("Toggle request failed");
        }
    };
    xhr.onerror = function () {
        console.error("Toggle request failed");
    };
    xhr.send(formData);
}

