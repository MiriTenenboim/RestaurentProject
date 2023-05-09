var Path = 'https://localhost:44387/api/';

//שליפת כל המנות שהלקוח הזמין מטבלת מנות בהזמנה
function GetAllRationsInInvitation() {
    var code = window.localStorage.getItem('codeInvitation');
        var path = Path + 'RationInInvitation/GetAllRationInInvation/' + code
        axios.get(path).then(
            (response) => {
                console.log(response);
                var result = response.data;
                InitRationsInInvitation(result);
            },
            (error) => {
                console.log(error);
                alert('error');
            }
        );
    }
//}

//הכנסת המנות שהלקוח הזמין 
function InitRationsInInvitation(object) {
    //כמות המנות באוסף
    var countRations = object.length;
    if (countRations == 0) {
        var errorDiv = document.getElementById("Error");
        errorDiv.style.display = "block";
        errorDiv.innerHTML = "אין מנות להצגה";
    }
    else {
        var answerDiv = document.getElementById("AllRations");
        document.getElementById("filtering").style.display = "block";
        answerDiv.setHTML('');
        var answerTable = document.createElement("table");
        answerTable.id = "MenuTable";
        answerTable.className = "table table-hover";
        var image;
        var TableTr;
        var TableTd;
        var thead = document.createElement("thead");
        var tbody = document.createElement("tbody");
        var amount = [];
        var sum = 0;
        for (var i = 0; i < countRations; i++) {
            var path = Path + 'RationInInvitation/GetAmountRation/' + object[i].NameRation;
            axios.get(path).then(
                (response) => {
                    console.log(response);
                    amount.push(response.data)
                    //alert('ok');
                },
                (error) => {
                    console.log(error);
                    alert('error');
                }
            );
        }
        //כותרות לטבלה
        setTimeout(function () {
            TableTr = document.createElement("tr");
            TableTh = document.createElement("th");
            TableTr.appendChild(TableTh);
            TableTh = document.createElement("th");
            TableTh.className = "MenuTh";
            TableTh.innerHTML = "תמונת המנה";
            TableTr.appendChild(TableTh);
            TableTh = document.createElement("th");
            TableTh.className = "MenuTh";
            TableTh.innerHTML = "שם המנה";
            TableTr.appendChild(TableTh);
            TableTh = document.createElement("th");
            TableTh.className = "MenuTh";
            TableTh.innerHTML = "תכולת המנה";
            TableTr.appendChild(TableTh);
            TableTh = document.createElement("th");
            TableTh.className = "MenuTh";
            TableTh.innerHTML = "מחיר המנה";
            TableTr.appendChild(TableTh);
            TableTh = document.createElement("th");
            TableTh.className = "MenuTh";
            TableTh.innerHTML = "כמות מוזמנת מהמנה";
            TableTr.appendChild(TableTh);
            TableTh = document.createElement("th");
            TableTh.className = "MenuTh";
            TableTh.innerHTML = "מחיר לתשלום מהמנה";
            TableTr.appendChild(TableTh);
            thead.appendChild(TableTr);
            answerTable.appendChild(thead);
            //הכנסת הנתונים לטבלה
            for (var i = 0; i < countRations; i++) {
                //שורה ראשונה
                TableTr = document.createElement("tr");
                TableTr.id = "line" + i;
                TableTh = document.createElement("th");
                TableTh.innerHTML = i + 1;
                TableTr.appendChild(TableTh);
                TableTd = document.createElement("td");
                //TableTd.className = "MenuTh";
                image = document.createElement("img");
                image.style.width = "100px";
                image.src = object[i].PictureRation;
                image.className = "RestaurentImg"
                TableTd.appendChild(image);
                TableTr.appendChild(TableTd);
                TableTd = document.createElement("td");
                //TableTd.className = "MenuTh";
                TableTd.innerHTML = object[i].NameRation;
                //TableTd.id = object[i].CodeRation;
                TableTr.appendChild(TableTd);
                TableTd = document.createElement("td");
                TableTd.className = "MenuTd";
                TableTd.innerHTML = object[i].ContainRation;
                TableTr.appendChild(TableTd);
                TableTd = document.createElement("td");
                //TableTd.className = "MenuTh";
                TableTd.innerHTML = object[i].PriceRation;
                TableTr.appendChild(TableTd);
                TableTd = document.createElement("td");
                TableTd.className = "MenuTd";
                TableTd.innerHTML = amount[i];
                TableTr.appendChild(TableTd);
                TableTd = document.createElement("td");
                TableTd.className = "MenuTd";
                TableTd.innerHTML = (object[i].PriceRation) * amount[i];
                sum += (object[i].PriceRation) * amount[i];
                TableTr.appendChild(TableTd);
                tbody.appendChild(TableTr);
            }
            TableTr = document.createElement("tr");
            TableTr.id = "line";
            TableTh = document.createElement("th");
            TableTh.className = "MenuTh";
            TableTr.appendChild(TableTh);
            TableTh = document.createElement("th");
            TableTh.className = "MenuTh";
            TableTr.appendChild(TableTh);
            TableTh = document.createElement("th");
            TableTh.className = "MenuTh";
            TableTr.appendChild(TableTh);
            TableTh = document.createElement("th");
            TableTh.className = "MenuTh";
            TableTr.appendChild(TableTh);
            TableTh = document.createElement("th");
            TableTh.className = "MenuTh";
            TableTr.appendChild(TableTh);
            TableTh = document.createElement("th");
            TableTh.className = "MenuTh";
            TableTh.innerHTML = "סך הכל לתשלום";
            TableTr.appendChild(TableTh);
            TableTh = document.createElement("th");
            TableTh.className = "MenuTh";
            TableTh.innerHTML = sum;
            TableTr.appendChild(TableTh);
            tbody.appendChild(TableTr);
            answerTable.appendChild(tbody);
            answerDiv.appendChild(answerTable);
        }, 10000)
    }
}