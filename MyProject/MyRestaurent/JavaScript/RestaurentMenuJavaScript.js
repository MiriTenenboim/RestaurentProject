var flag = 1;
var ifChange = 0;
var Path = 'https://localhost:44387/api/';
var onFirstClick = 0;
var rationId;
var rationTr;
var nameRation;
var amountRation;
var pricePerServing;
var codeInvitation;

//פונקצית אתחול ראשי
function Init() {
    makeGetRequestRations(Path + 'Rations/GetAllRations');
}

//פונקצית אתחול המנות
function InitRations(object) {
    //הכנסת נתוני המנות לדף ללא סינון
    var answerDiv = document.getElementById("RestaurentMenu");
    answerDiv.setHTML('');
    var answerTable = document.createElement("table");
    answerTable.id = "MenuTable";
    answerTable.className = "table";
    var image;
    var TableTr;
    var TableTd;
    var countRations = object.length;
    var thead = document.createElement("thead");
    var tbody = document.createElement("tbody");
    //כותרות לטבלה
    TableTr = document.createElement("tr");
    TableTh = document.createElement("th");
    TableTr.appendChild(TableTh);
    TableTh = document.createElement("th");
    TableTh.innerHTML = "תמונת המנה";
    TableTr.appendChild(TableTh);
    TableTh = document.createElement("th");
    TableTh.innerHTML = "שם המנה";
    TableTr.appendChild(TableTh);
    TableTh = document.createElement("th");
    TableTh.innerHTML = "תכולת המנה";
    TableTr.appendChild(TableTh);
    TableTh = document.createElement("th");
    TableTh.innerHTML = "מחיר המנה";
    TableTr.appendChild(TableTh);
    TableTh = document.createElement("th");
    TableTh.innerHTML = "מספר נקודות הדרוג";
    TableTr.appendChild(TableTh);
    TableTh = document.createElement("th");
    TableTh.innerHTML = "כמות להזמנה מהמנה";
    TableTr.appendChild(TableTh);
    TableTh = document.createElement("th");
    TableTh.innerHTML = "להזמנת המנה";
    TableTr.appendChild(TableTh);
    thead.appendChild(TableTr);
    answerTable.appendChild(thead);
    //הכנסת הנתונים לטבלה
    for (var i = 0; i < countRations; i++) {
        //שורה ראשונה
        TableTr = document.createElement("tr");
        TableTr.id = "line" + i;
        TableTd = document.createElement("td");
        TableTd.innerHTML = i + 1;
        TableTr.appendChild(TableTd);
        TableTd = document.createElement("td");
        image = document.createElement("img");
        image.style.width = "100px";
        image.src = object[i].PictureRation;
        image.className = "RestaurentImg"
        TableTd.appendChild(image);
        TableTr.appendChild(TableTd);
        TableTd = document.createElement("td");
        TableTd.innerHTML = object[i].NameRation;
        TableTd.id = object[i].CodeRation;
        TableTr.appendChild(TableTd);
        TableTd = document.createElement("td");
        TableTd.className = "MenuTd ContainTd";
        TableTd.innerHTML = object[i].ContainRation;
        TableTr.appendChild(TableTd);
        TableTd = document.createElement("td");
        TableTd.innerHTML = object[i].PriceRation;
        TableTr.appendChild(TableTd);
        TableTd = document.createElement("td");
        TableTd.innerHTML = object[i].ScoreOfRation;
        TableTr.appendChild(TableTd);
        TableTd = document.createElement("td");
        TableTd.className = "MenuTd";
        TableTr.appendChild(TableTd);
        var input = document.createElement("input");
        input.className = "input";
        input.type = "Number";
        input.min = 0;
        input.max = object[i].AmountRation;
        input.placeholder = "כמות להזמנה";
        input.id = i + 1;
        TableTd.appendChild(input);
        TableTr.appendChild(TableTd);
        TableTd = document.createElement("td");
        TableTd.className = "MenuTd";
        //הוספת כפתור להזמנה
        var order = document.createElement("button");
        order.textContent = "להזמנת המנה";
        order.className = "orderButton";
        order.id = "button" + i;
        order.addEventListener('click', (event) => {
            rationId = event.target.parentElement.parentElement.id;
            rationTr = document.getElementById(rationId);
            nameRation = rationTr.cells['2'].innerHTML;
            amountRation = rationTr.cells['6'].children[0].value;
            if (amountRation == "") {
                amountRation = 1;
            }
            if (event.target.innerHTML == "להזמנת המנה") {
                event.target.innerHTML = "למחיקת המנה מההזמנה";
                //אם המנה היא המנה הראשונה שהלקוח מזמין
                if (onFirstClick == 0) {
                    onFirstClick = 1;
                    //הוספת הזמנה בטבלת הזמנות ללקוח זה
                    var path = Path + 'Invitations/AddInvitation';
                    QueryObj = [
                        window.localStorage.getItem('userName'),
                        window.localStorage.getItem('userTel'),
                    ]
                    axios.post(path, QueryObj).then(
                        (Response) => {
                            var result = Response.data;
                            if (result != 0) {
                                window.localStorage.setItem('codeInvitation', result);
                                onFirstClick = 1;
                                //הוספת המנה שהוזמנה לטבלת מנות בהזמנה
                                AddToRationInInvitation(Path + 'RationInInvitation/AddRationInInvation');
                            }
                        },
                        (Error) => {
                            console.log(Error);
                            alert("שגיאה")
                        }
                    );
                }
                else
                    AddToRationInInvitation(Path + 'RationInInvitation/AddRationInInvation');
            }
            else {
                //שינוי הכפתור לאפשרות של הזמנת המנה
                event.target.innerHTML = "להזמנת המנה";
                //מחיקת המנה שבוטלה מטבלת מנות בהזמנה
                DeleteFromRationInInvitation(Path + 'RationInInvitation/DeleteRationInInvitation/' + window.localStorage.getItem('codeInvitation') + '/' + nameRation);
            }
        });
        TableTd.appendChild(order);
        if (object[i].AmountRation == 0) {
            var span = document.createElement("span");
            span.innerHTML = "אין במלאי מהמנה";
            order.disabled = true;
            TableTd.appendChild(span);
        }
        TableTr.appendChild(TableTd);
        tbody.appendChild(TableTr);
    }
    answerTable.appendChild(tbody);
    answerDiv.appendChild(answerTable);
}

//שליפת קוד הזמנה
function makeGetRequestRations(path) {
    axios.get(path).then(
        (response) => {
            console.log(response)
            var result = response.data;
            InitRations(result);
        },
        (error) => {
            console.log(error);
            alert('error');
        }
    );
}

//הוספת המנה לטבלת מנות בהזמנה
function AddToRationInInvitation(path) {
    var newRationInInvitation = {
        CodeInvitation: window.localStorage.getItem('codeInvitation'),
        CodeRation: 0,
        AmountRation: amountRation,
        PricePerServing: 0,
        OrderTime: "00:00:00",
        IsPerformed: false,
    };
    var QueryObj = [
        newRationInInvitation,
        nameRation, //שם המנה
    ]
    var path = Path + 'RationInInvitation/AddRationInInvation';
    axios.post(path, QueryObj).then(
        (Response) => {
            if (Response != null) {
                var result = Response.data;
                pricePerServing = result.PricePerServing;
                UpdateAmountRation(Path + 'Rations/UpdateAmountRation/' + nameRation + '/' + amountRation);
            }
        },
        (Error) => {
            console.log(Error);
        }
    );
}

// מחיקה מטבלת מנות בהזמנה
function DeleteFromRationInInvitation(path) {
    axios.delete(path).then(
        (Response) => {
            console.log(Response);
            UpdateAmountRation(Path + 'Rations/UpdateAmountRation/' + nameRation + '/' + -amountRation);
        },
        (Error) => {
            console.log(Error)
        }
    );
}

// עדכון כמות מהמנה
function UpdateAmountRation(path) {
    axios.put(path).then(
        (Response) => {
            var result = Response.data;
            if (result == true) {
                var path = Path + 'Invitations/UpdatePriceToPay/' + codeInvitation + '/' + pricePerServing;
                axios.put(path).then(
                    (Response) => {

                    },
                    (Error) => {
                        console.log(Error);
                    }
                )
            }
        },
        (Error) => {
            console.log(Error);
        }
    );
}

//סינון משני
function Filtering() {
    if (ifChange == 1) {
        makeGetRequestRations(Path + 'Rations/GetAllRations');
    }
    //SELECTהכנסת אפשרויות הסינון המשני לפי הבחירה בסינון הראשי לתיבת ה 
    var answerSelect = document.getElementById("filter");
    var choose = document.getElementById("MainFilter").value;
    var rangeMin = document.getElementById("RangeMin");
    var rangeMax = document.getElementById("RangeMax");
    var rangeButton = document.getElementById("RangeButton");
    rangeMin.setHTML('');
    rangeMax.setHTML('');
    rangeButton.setHTML('');
    answerSelect.setHTML('');
    answerSelect.style.display = "none";
    switch (choose) {
        case '0':
            break;
        //שליפת הקטגוריות
        case '1':
            GetOptions(Path + 'FoodCategory/GetAllCategories');
            ifChange = 1;
            break;
        //הקשת טווח נקודות - מינימום ומקסימום          
        case '2':
            var input = document.createElement("input");
            input.placeholder = "הכנס מספר נקודות מינימלי";
            input.className = "input range";
            input.id = "Min";
            input.type = "Number";
            input.min = 1;
            rangeMin.appendChild(input);
            input = document.createElement("input");
            input.placeholder = "הכנס מספר נקודות מקסימלי";
            input.className = "input range";
            input.type = "Number";
            input.id = "Max";
            input.min = 1;
            rangeMax.appendChild(input);
            var button = document.createElement("button");
            button.textContent = "לסינון";
            button.className = "orderButton";
            button.id = "toFilter";
            button.addEventListener('click', (event) => { GetRationsAfterFiltering() })
            rangeButton.appendChild(button);
            ifChange = 1;
            break;
        //חלבי או פרווה
        case '3':
            var newOption = document.createElement("option");
            newOption.textContent = "בחר";
            answerSelect.appendChild(newOption);
            newOption = document.createElement("option");
            newOption.textContent = 'פרווה';
            answerSelect.appendChild(newOption);
            newOption = document.createElement("option");
            newOption.textContent = 'חלבי';
            answerSelect.appendChild(newOption);
            answerSelect.style.display = "block";
            ifChange = 1;
            break;
        //הקשת טווח מחירים - מינימום ומקסימום  
        case '4':
            var input = document.createElement("input");
            input.placeholder = "הכנס מחיר מינימלי";
            input.className = "input range";
            input.type = "Number";
            input.id = "Start";
            input.min = 1;
            rangeMin.appendChild(input);
            input = document.createElement("input");
            input.placeholder = "הכנס מחיר מקסימלי";
            input.className = "input range";
            input.type = "Number";
            input.min = 1;
            input.id = "Finish";
            rangeMax.appendChild(input);
            var button = document.createElement("button");
            button.textContent = "לסינון";
            button.className = "orderButton";
            button.id = "toFilter";
            button.addEventListener('click', (event) => { GetRationsAfterFiltering() })
            rangeButton.appendChild(button);
            ifChange = 1;
            break;
        //שליפת שמות המנות
        case '5':
            GetOptions(Path + 'Rations/GetNameRations');
            ifChange = 1;
            break;
    }
}

//של הסינון המשני SELECTהוספת הנתונים שנשלפו ממסד הנתונים לתיבת ה 
function AddTheOptions(object) {
    var answerSelect = document.getElementById("filter");
    var countOptions = object.length;
    var newOptions = document.createElement("option");
    newOptions.textContent = "בחר";
    newOptions.value = "0";
    answerSelect.appendChild(newOptions);
    for (var i = 0; i < countOptions; i++) {
        newOptions = document.createElement("option");
        newOptions.value = object[i];
        newOptions.textContent = object[i];
        answerSelect.appendChild(newOptions);
    }
    answerSelect.style.display = "block";
}

//שליפת פרטי המנות לטבלה אחרי הסינון
function GetRationsAfterFiltering() {
    var mainChoose = document.getElementById("MainFilter").value;
    var choose = document.getElementById("filter").value;
    switch (mainChoose) {
        //שליפה בלי סינון
        case '0':
            makeGetRequestRations(Path + 'Rations/GetAllRations');
            break;
        //שליפה אחרי סינון לפי הקטגוריות
        case '1':
            GetOptionsByFiltering(Path + 'Rations/GetRationsByCategory/' + choose);
            break;
        //הקשת טווח נקודות - מינימום ומקסימום 
        case '2':
            var start = document.getElementById("Min").value;
            var finish = document.getElementById("Max").value;
            GetOptionsByFiltering(Path + 'Rations/GetAllRationsByScoreOfRationsBetween/' + start + '/' + finish);
            break;
        //חלבי או פרווה
        case '3':
            var answer = true;
            if (choose == "פרווה") {
                answer = false;
            }
            GetOptionsByFiltering(Path + 'Rations/GetRationsByDairyOrNot/' + answer);
            break;
        //הקשת טווח מחירים - מינימום ומקסימום  
        case '4':
            var start = document.getElementById("Start").value;
            var finish = document.getElementById("Finish").value;
            GetOptionsByFiltering(Path + 'Rations/GetAllRationsByPriceOfRationsBetween/' + start + '/' + finish);
            break;
        //שליפת שמות המנות
        case '5':
            GetOptionsByFiltering(Path + 'Rations/GetRationsByNameRations/' + choose);
            break;
    }
}

// סיום ההזמנה - מעבר לדף סיכום הזמנה
function ViewOrder() {
    window.location.href = "../Pages/FinalOrderPage.html";
}