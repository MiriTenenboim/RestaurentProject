var Path = 'https://localhost:44387/api/';

function UpdateTables() {
    var path = Path + 'InvitationInTable/GetAllInvitationInTables';
    axios.get(path).then(
        (Response) => {
            var result = Response.data;
            for (var i = 0; i < result.length; i++) {
                // השעה השמורה בטבלה
                var date = new Date(result[i].OrderHour);
                var diff = 60 * 60 * 1000;
                // השעה השמורה בטבלה אחרי הוספת שעה
                var newDate = new Date(date.getTime() + diff);
                // אם השעה הנוכחית גדולה בשעה מהשעה שבא נתפס השולחן
                if (newDate < (new Date())) {
                    path = Path + 'InvitationInTable/UpdateTableToEmpty/' + result[i].TableLocation;
                    axios.put(path).then(
                        (Response) => {
                            alert("ok");
                        },
                        (Error) => {
                            alert("error")
                        }
                    )
                }
            }
        },
        (Error) => {
            alert("error");
        }
    )
}

//פונקצית אתחול הדף
function InitT() {
    makeGetRequestTables(Path + 'Tables/GetFreeTables');
}

//הכנסת כל השולחנות לדף שולחן
function InitTables(object) {
    var countTables = object.length;
    if (countTables == 0) {
        var answerSelect = document.getElementById("MainFilter");
        answerSelect.style.display = "none";
    }
    var Div = document.getElementById("AllTables");
    Div.setHTML('');
    var Table = document.createElement("table");
    Table.id = "TablesTable";
    //כותרות לטבלה
    if (countTables != 0) {
        Tr = document.createElement("tr");
        Tr.className = "Tr";
        var TableTh = document.createElement("th");
        Tr.appendChild(TableTh);
        TableTh = document.createElement("th");
        TableTh.className = "TableTh";
        TableTh.innerHTML = "מספר הסועדים בשולחן";
        Tr.appendChild(TableTh);
        TableTh = document.createElement("th");
        TableTh.className = "TableTh";
        TableTh.innerHTML = "מיקום השולחן";
        Tr.appendChild(TableTh);
        Table.appendChild(Tr);
    }
    //הכנסת הנתונים לטבלה
    for (var i = 0; i < countTables; i++) {
        Tr = document.createElement("tr");
        Tr.className = "Tr";
        Tr.id = i + 1;
        TableTh = document.createElement("th")
        TableTh.innerHTML = i + 1;
        Tr.appendChild(TableTh);
        var Td = document.createElement("td");
        Td.className = "TableTd";
        Td.innerHTML = object[i].NumberOfDiners;
        Tr.appendChild(Td);
        Td = document.createElement("td");
        Td.className = "TableTd";
        Td.innerHTML = object[i].TableLocation;
        Tr.appendChild(Td);
        Td = document.createElement("td");
        Td.className = "TableTd";
        Button = document.createElement('button');
        Button.textContent = 'לבחירת השולחן';
        Button.className = "orderButton";
        Button.addEventListener('click', (event) => {
            Id = event.target.parentElement.parentElement.id;
            Tr = document.getElementById(Id);
            var tableLocation = Tr.cells['2'].innerHTML;
            var codeInvitation = window.localStorage.getItem('codeInvitation');
            AddInvitationInTable(Path + 'InvitationInTable/AddInvationInTable/' + codeInvitation + '/' + tableLocation);
        });
        Td.appendChild(Button);
        Tr.appendChild(Td);
        Table.appendChild(Tr);
    }
    Div.appendChild(Table);
}

//הכנסת הנתונים לסינון המשני לפי הסינון הראשי
function Filtering() {
    //SELECTהכנסת אפשרויות הסינון המשני לפי הבחירה בסינון הראשי לתיבת ה 
    var answerSelect = document.getElementById("filter");
    var choose = document.getElementById("MainFilter").value;
    var answerDiv = document.getElementById("Range");
    answerDiv.setHTML('');
    answerSelect.setHTML('');
    switch (choose) {
        case '0':
            answerSelect.style.display = "none";
            InitT();
            break;
        case '1':
            var input = document.createElement("input");
            input.placeholder = "הכנס מספר נקודות מינימלי";
            input.id = "Start";
            input.type = "Number";
            answerDiv.appendChild(input);
            input = document.createElement("input");
            input.placeholder = "הכנס מספר נקודות מקסימלי";
            input.id = "Finish";
            input.type = "Number";
            answerDiv.appendChild(input);
            var button = document.createElement("button");
            button.textContent = "לסינון";
            button.addEventListener('click', (event) => { GetTablesAfterFiltering() })
            answerDiv.appendChild(button);
            break;
        case '2':
            GetOptionsTables(Path + 'Tables/GetFreeLocation');
            break;
    }
}

//שליפת הנתונים לטבלה לפי הסינון המשני
function GetTablesAfterFiltering() {
    var mainChoose = document.getElementById("MainFilter").value;
    switch (mainChoose) {
        case '0':
            makeGetRequestTables(Path + 'Tables/GetFreeTables');
            break;
        case '1':
            var start = document.getElementById("Start").value;
            var finish = document.getElementById("Finish").value;
            GetOptionsTableByFiltering(Path + 'Tables/GetTablesByNumDiners/' + start + ' / ' + finish);
            break;
        case '2':
            var choose = document.getElementById("filter").value;
            GetOptionsTableByFiltering(Path + 'Tables/GetTableByLocation/' + choose);
            break;
    }
}