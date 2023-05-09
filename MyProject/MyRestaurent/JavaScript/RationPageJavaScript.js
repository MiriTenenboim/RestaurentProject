var Path = 'https://localhost:44387/api/';

function GetOptionsRations(path) {
    axios.get(path).then(
        (response) => {
            console.log(response)
            var result = response.data;
            AddTheRations(result);
            console.log(result);
        },
        (error) => {
            console.log(error);
            alert('error');
        }
    );
}

function AddTheRations(object) {
    var answerSelect = document.getElementById("RationName2");
    var countOptions = object.length;
    var newOptions = document.createElement("option");
    newOptions.textContent = "בחר";
    newOptions.value = "Ration0";
    answerSelect.appendChild(newOptions);
    for (var i = 0; i < countOptions; i++) {
        newOptions = document.createElement("option");
        newOptions.value = object[i];
        newOptions.textContent = object[i];
        answerSelect.appendChild(newOptions);
    }
    answerSelect.style.display = "block";
}

function GetOptionsCategories(path) {
    axios.get(path).then(
        (response) => {
            console.log(response)
            var result = response.data;
            AddTheCategories(result);
            console.log(result);
        },
        (error) => {
            console.log(error);
            alert('error');
        }
    );
}

function AddTheCategories(object) {
    var answerSelect = document.getElementsByClassName("categories");
    for (var j = 0; j < answerSelect.length; j++) {
        var countOptions = object.length;
        var newOptions = document.createElement("option");
        newOptions.textContent = "בחר";
        newOptions.value = "Category" + j;
        answerSelect[j].appendChild(newOptions);
        for (var i = 0; i < countOptions; i++) {
            newOptions = document.createElement("option");
            newOptions.value = object[i];
            newOptions.textContent = object[i];
            answerSelect[j].appendChild(newOptions);
        }
        answerSelect[j].style.display = "block";
    }
}

function FillDetails() {
    var choose = document.getElementById("RationName2").value;
    var path = Path + 'Rations/GetRationsByNameRations/' + choose;
    axios.get(path).then(
        (response) => {
            console.log(response)
            var result = response.data;
            document.getElementById("RationName2").value = result[0].NameRation;
            document.getElementById("PriceRation2").value = result[0].PriceRation;
            document.getElementById("ContainRation2").value = result[0].ContainRation;
            document.getElementById("ScoreOfRation2").value = result[0].ScoreOfRation;
            document.getElementById("PictureRation2").value = result[0].PictureRation;
            document.getElementById("AmountRation2").value = result[0].AmountRation;
            var dairyOrNot = result[0].DairyOrNot;
            if (dairyOrNot == false)
                document.getElementById("DairyOrNot2")[2].selected = "selected";
            else {
                document.getElementById("DairyOrNot2")[1].selected = "selected";
            }
            var codeCategory = result[0].CodeCategory;
            document.getElementById("CategoryName2")[codeCategory].selected = "selected"
            //path = Path + 'FoodCategory/GetFoodCategoryByCode/' + codeCategory;
            //axios.get(path).then(
            //    (response) => {
            //        var result = response.data;
            //        document.getElementById("CategoryName2").selected = "selected"
            //    },
            //    (error) => {
            //        console.log(error);
            //        alert('error');
            //    }
            //)
        },
        (error) => {
            console.log(error);
            alert('error');
        }
    );
}