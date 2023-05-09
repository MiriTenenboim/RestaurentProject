var Path = 'https://localhost:44387/api/';
var flag = 1;
var name, family, tel, email;


//הוספת לקוח חדש
function AddNewClient(path) {
    var newClient = [
        name,
        family,
        tel,
        email,
    ]
    axios.post(path, newClient).then(
        (response) => {
            var result = response.data;
            //LOCAL STORAGEשמירת נתוני הלקוח ב
            window.localStorage.setItem('userName', name);
            window.localStorage.setItem('userTel', tel);
            //מעבר לדף הבית
            window.location.href = "../Pages/HomePage.html";
        },
        (error) => {
            console.log(error);
        }
    );
}

// בדיקה אם המנהל קיים
function CheckExist(path) {
    axios.get(path).then(
        (response) => {
            console.log(response)
            var result = response.data;
            if (result != null) {
                //מעבר לדף הבית
                window.location.href = "../Pages/HomePageManager.html";
            }
            else {
                alert("User does not have access permission");
            }
        },
        (error) => {
            console.log(error);
        }
    );

}


//פונקציה לבדיקת תקינות הנתונים שהמשתמש הכניס
function CheckDetails(num) {
    window.localStorage.setItem('codeInvitation', 0);
    name = document.getElementById("Name" + num).value;
    family = document.getElementById("FamilyName" + num).value;
    tel = document.getElementById("numberPhone" + num).value;
    email = document.getElementById("emailAddress" + num).value;
    //בדיקות תקינות על השם משתמש
    if (name.length == 0) {
        alert('Please provide a valid name');
        name.focus;
        flag = 0;
    }
    else {
        for (var i = 0; i < name.length; i++) {
            if (name[i] >= 0 && name[i] <= 9) {
                alert('Please provide a valid name');
                flag = 0;
                break;
            }
        }
    }
    //בדיקות תקינות על השם משפחה
    if (family.length == 0) {
        alert('Please provide a valid family name');
        family.focus;
        flag = 0;
    }
    else {
        for (var i = 0; i < family.length; i++) {
            if (family[i] >= 0 && family[i] <= 9) {
                alert('Please provide a valid family name');
                flag = 0;
                break;
            }
        }
    }

    //בדיקות תקינות על מספר הפלאפון
    if (tel.length == 10 && tel[1] == 5) {
        var filter = /05?[0-9]-?[0-9]{7}/;
        if (!filter.test(tel)) {
            alert('Please provide a valid number phone');
            tel.focus;
            flag = 0;
        }
    }
    //בדיקות תקינות על מספר הטלפון
    else {
        var filter = /^0?(([23489]{1}\d{7})|[5]{1}\d{8})$/;
        if (!filter.test(tel)) {
            alert('Please provide a valid number phone');
            tel.focus;
            flag = 0;
        }
    }
    //בדיקות תקינות על כתובת המייל
    if (email.length != 0) {
        var filter = /^([a-zA-Z0-9_.-])+@(([a-zA-Z0-9-])+.)+([a-zA-Z0-9]{2,4})+$/;
        if (!filter.test(email)) {
            alert('Please provide a valid email address');
            email.focus;
            flag = 0;
        }
    }


    //אם כל הנתונים שהוכנסו נכונים
    if (flag == 1) {
        if (num == 1) {
            //שמירת נתוני המשתמש בטבלת לקוחות
            AddNewClient(Path + 'Clients/AddClient');
        }
        else
            CheckExist(Path + 'Clients/GetClientByNamePhone/' + name + '/' + tel)
    }
}

// ( עדכון הכמות הקיימת מהמנה ( בתחילת היום 
function UpdateAmount() {
    var path = Path + 'Rations/GetAllRations';
    axios.get(path).then(
        (response) => {
            var result = response.data;
            if (new Date(result[0].DateUpdateAmount).getDate() != new Date().getDate()) {
                for (var i = 0; i < result.length; i++) {
                    path = Path + 'Rations/UpdateAmount/' + result[i].NameRation;
                    axios.put(path).then(
                        (response) => {
                        },
                        (Error) => {
                            console.log(Error);
                        }
                    )
                }
            }
        },
        (error) => {
            console.log(error);
        }
    )
}


