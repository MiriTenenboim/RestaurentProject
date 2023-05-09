var flag = 1;
var Path = 'https://localhost:44387/api/';
var numberCreditCardSpan;
var dateCreditCardSpan;
var threeDigitsSpan;
var idNumberSpan;


//SELECTפונקציה להוספת נתונים בדף לפי מה שנבחר בתיבת ה
function PaymentMethod() {
    var choose = document.getElementById("PaymentMethod").value;
    var answer = document.getElementById("Answer");
    var newInput;
    var newButton;
    var br;
    switch (choose) {
        //אם לא נבחרה אפשרות תשלום
        case '1':
            answer.textContent = null;
            answer.style.display = "none";
            break;
        //בחירה באפשרות של תשלום באשראי
        case '2':
            //הוספת האפשרות להכנסת נתוני האשראי
            if (flag == 0) {
                answer.textContent = null;
            }
            newInput = document.createElement("input");
            newInput.placeholder = "מספר אשראי";
            newInput.id = "NumberCreditCard";
            newInput.className = "input";
            newInput.type = "Number";
            answer.appendChild(newInput);
            numberCreditCardSpan = document.createElement("span");
            numberCreditCardSpan.innerHTML = "שדה זה הוא שדה חובה";
            numberCreditCardSpan.style.display = "none";
            answer.appendChild(numberCreditCardSpan);
            br = document.createElement("br");
            answer.appendChild(br);
            newInput = document.createElement("input");
            newInput.placeholder = "תוקף אשראי";
            newInput.id = "DateCreditCard";
            newInput.className = "input";
            newInput.type = "Date";
            answer.appendChild(newInput);
            dateCreditCardSpan = document.createElement("span");
            dateCreditCardSpan.innerHTML = "שדה זה הוא שדה חובה";
            dateCreditCardSpan.style.display = "none";
            answer.appendChild(dateCreditCardSpan);
            br = document.createElement("br");
            answer.appendChild(br);
            newInput = document.createElement("input");
            newInput.placeholder = "ספרות בגב הכרטיס";
            newInput.id = "ThreeDigits";
            newInput.className = "input";
            newInput.type = "Number";
            newInput.maxLength = "3";
            answer.appendChild(newInput);
            threeDigitsSpan = document.createElement("span");
            threeDigitsSpan.innerHTML = "שדה זה הוא שדה חובה";
            threeDigitsSpan.style.display = "none";
            answer.appendChild(threeDigitsSpan);
            br = document.createElement("br");
            answer.appendChild(br);
            newInput = document.createElement("input");
            newInput.placeholder = "מספר תעודת זהות";
            newInput.id = "IdNumber";
            newInput.className = "input";
            newInput.type = "Number";
            newInput.maxLength = "9";
            answer.appendChild(newInput);
            idNumberSpan = document.createElement("span");
            idNumberSpan.innerHTML = "שדה זה הוא שדה חובה";
            idNumberSpan.style.display = "none";
            answer.appendChild(idNumberSpan);
            br = document.createElement("br");
            answer.appendChild(br);
            newButton = document.createElement("button");
            newButton.innerHTML = "אישור";
            newButton.className = "orderButton"
            newButton.addEventListener('click', (event) => {
                window.location.href = "../Pages/FinalPage.html";
            })
            answer.appendChild(newButton);
            flag = 0;
            answer.style.display = "block";
            break;
        //בחירה באפשרות של תשלום במזומן
        case '3':
            if (flag == 0) {
                answer.textContent = null;
            }
            answer.innerHTML = "פנה לדלפק לתשלום" + '<br/>' + '<br/>';
            answer.style.color = 'white';
            newButton = document.createElement("button");
            newButton.innerHTML = "אישור";
            newButton.className = "orderButton";
            newButton.addEventListener('click', (event) => {
                window.location.href = "../Pages/FinalPage.html";
            })
            answer.appendChild(newButton);
            flag = 0;
            answer.style.display = "block";
    }
}

function CheckDetailsCreditCard() {
    var isGood = true;
    var numberCreditCard = document.getElementById("NumberCreditCard").value;
    var dateCreditCard = document.getElementById("DateCreditCard").value;
    var threeDigits = document.getElementById("ThreeDigits").value;
    var idNumber = document.getElementById("IdNumber").value;
    // בדיקות תקינות על פרטי האשראי
    // בדיקת תקינות על מספר האשראי
    // אם האורך שווה ל 0 
    if (numberCreditCard.length == 0) {
        isGood = false;
        numberCreditCardSpan.style.display = "block";
    }
    if (dateCreditCard.length == 0) {
        isGood = false;
        dateCreditCardSpan.style.display = "block";
    }
    if (threeDigits.length == 0) {
        isGood = false;
        threeDigitsSpan.style.display = "block";
    }
    if (idNumber.length == 0) {
        isGood = false;
        idNumberSpan.style.display = "block";
    }
    if (isGood == true) {
        UpdateInvitationToPaid(Path + 'Invitations/UpdateInvitationToPaid/' + window.localStorage.getItem('codeInvitation'));
    }
}

function UpdateInvitationToPaid(path) {
    axios.put(path).then(
        (Response) => {
        },
        (Error) => {
            alert("error");
        }
    )

}