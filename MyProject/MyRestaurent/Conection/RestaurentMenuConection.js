var Path = 'https://localhost:44387/api/';

//שליפת כל המנות
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

//שליפת שמות המנות או שמות הקטגוריות של האוכל
function GetOptions(path) {
    axios.get(path).then(
        (response) => {
            console.log(response)
            var result = response.data;
            AddTheOptions(result);
            console.log(result);
        },
        (error) => {
            console.log(error);
            alert('error');
        }
    );
}

//שליפת שם מנה לפי קוד
function GetNameRationByCode(path) {
    axios.get(path).then(
        (response) => {
            console.log(response)
            var result = response.data;
            console.log(result);
        },
        (error) => {
            console.log(error);
            alert('error');
        }
    );
}

//שליפת שמות המנות שמספר נקודות הדרוג שלהם בין 2 המספרים שנקלטו 
function GetOptionsScore(path, low, high) {
    axios.get(path, low, high).then(
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

//שליפת שמות המנות שמחירם בין 2 המספרים שנקלטו
function GetOptionsPrice(path) {
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

//שליפת המנות לתפריט לפי סינון
function GetOptionsByFiltering(path) {
    axios.get(path).then(
        (response) => {
            console.log(response)
            var result = response.data;
            InitRations(result);
            console.log(result);
        },
        (error) => {
            console.log(error);
        }
    );
}

