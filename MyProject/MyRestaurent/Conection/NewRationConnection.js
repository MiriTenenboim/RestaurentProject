//הוספת מנה
function AddRation(path, num) {
    var newRation = {
        CodeRation: 0,
        NameRation: document.getElementById("RationName" + num).value,
        PriceRation: document.getElementById("PriceRation" + num).value,
        CodeCategory: 0,
        ContainRation: document.getElementById("ContainRation" + num).value,
        DairyOrNot: false,
        ScoreOfRation: document.getElementById("ScoreOfRation" + num).value,
        AmountRation: document.getElementById("AmountRation" + num).value,
        PictureRation: document.getElementById("PictureRation" + num).value,
    }
    var queryObj = [
        newRation,
        document.getElementById("CategoryName" + num).value,
        document.getElementById("DairyOrNot" + num).value,
    ]
    axios.post(path, queryObj).then(
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