var Path = 'https://localhost:44387/api/';


//הוספת שולחן
function AddTable(path, num) {
    var newTable = [
        0,
        document.getElementById("NumDiners" + num).value,
        document.getElementById("TableLocation" + num).value,
    ]
    axios.post(path, newTable).then(
        (response) => {
            var result = response.data;
            if (result == true) {
                alert("OK");
                //מעבר לדף הבית של המנהל 
                window.location.href = "../Pages/HomePageManager.html";
            }
        },
        (error) => {
            console.log(error);
        }
    )
}

function GetOptionsTables(path) {
    axios.get(path).then(
        (response) => {
            console.log(response)
            var result = response.data;
            AddTheTables(result);
            console.log(result);
        },
        (error) => {
            console.log(error);
            alert('error');
        }
    );
}

function AddTheTables(object) {
    var answerSelect = document.getElementById("TableLocation2");
    var countOptions = object.length;
    var newOptions = document.createElement("option");
    newOptions.textContent = "בחר";
    newOptions.value = "Table";
    answerSelect.appendChild(newOptions);
    for (var i = 0; i < countOptions; i++) {
        newOptions = document.createElement("option");
        newOptions.value = object[i].TableLocation;
        newOptions.textContent = object[i].TableLocation;
        answerSelect.appendChild(newOptions);
    }
    answerSelect.style.display = "block";
}

function FillDetails() {
    var choose = document.getElementById("TableLocation2").value;
    var path = Path + 'Tables/GetTableByLocation/' + choose;
    axios.get(path).then(
        (response) => {
            console.log(response)
            var result = response.data;
            document.getElementById("NumDiners2").value = result[0].NumberOfDiners;
        },
        (error) => {
            console.log(error);
            alert('error');
        }
    );
}