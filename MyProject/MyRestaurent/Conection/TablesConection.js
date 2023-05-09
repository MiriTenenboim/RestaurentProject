//הכנסת כל השולחנות לדף שולחן
function makeGetRequestTables(path) {
    axios.get(path).then(
        (response) => {
            console.log(response)
            var result = response.data;
            InitTables(result);
            console.log(result);
        },
        (error) => {
            console.log(error);
        }
    );
}

//שליפת כל השולחנות
function GetOptionsTables(path) {
    axios.get(path).then(
        (response) => {
            console.log(response)
            var result = response.data;
            AddTheOptions(result);
            console.log(result);
        },
        (error) => {
            console.log(error);
        }
    );
}

//שליפת השולחנות לפי הסינון
function GetOptionsTableByFiltering(path) {
    axios.get(path).then(
        (response) => {
            console.log(response)
            var result = response.data;
            InitTables(result);
            console.log(result);
        },
        (error) => {
            console.log(error);
        }
    );
}

//הוספת השולחן הנבחר לטבלת שולחנות בהזמנה
function AddInvitationInTable(path) {
    axios.post(path).then(
        (response) => {
            var result = response.data;
            if (result == true) {
                window.location.href = "../Pages/PaymentPage.html";
            }
            else {
            }
        },
        (error) => {
            console.log(error);
        }
    );
}

function ChangeStatusTable() {
    var tableLocation = document.getElementById("filter").value;
    var path = 'https://localhost:44387/api/InvitationInTable/UpdateTableToEmpty/' + tableLocation;
    axios.put(path).then(
        (response) => {
            var result = response.data;
            if (result == true) {
                alert("סטטוס השולחן שונה בהצלחה!!");
            }
            else {
                alert("לא הצלחנו לשנות את סטטוס השולחן");
            }
        },
        (error) => {
            console.log(error);
        }
    );
}