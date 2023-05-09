var Path = 'https://localhost:44387/api/';

//הוספת דרוג למנה
function dynamicPostRequestRate(path) {
    var rateRations = {
        CodeClient: 0,
        CodeRation: 0,
        ScoreOfRation: document.getElementById("scoreOfRation").value,
        Comments: document.getElementById("comments").value
    }
    var queryObj = [
        rateRations,
        window.localStorage.getItem('userName'),
        document.getElementById("RationName2").value,
        window.localStorage.getItem('userTel'),
    ]
    axios.post(path, queryObj).then(
        (response) => {
            var result = response.data;
            if (result != null) {
                AddAmount(Path + 'AmountRationInInvitation/' + result.CodeRation);
                alert("OK")
            }
            else {
                alert("error");
            }
        },
        (error) => {
            console.log(error);
        }
    )
}

function AddAmount(path) {
    axios.put(path).then(
        (response) => {
            var result = response.data;
            if (result != null) {
                alert("הכמות שונתה בהצלחה")
            }
        }
    );
}

function checkDetails() {
    var chooseName = document.getElementById("RationName2").value;
    var scores = document.getElementById("scoreOfRation").value;
    if (chooseName == 'Ration0') {
        alert("Choose name of ration");
    }
    else {
        if (scores > 0) {
            dynamicPostRequestRate('https://localhost:44387/api/RateRations/AddRateRation');
        }
        else {
            alert("Enter number of scores");
        }
    }
}