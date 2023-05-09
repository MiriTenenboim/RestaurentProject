//הוספת קטגורית אוכל
function AddFoodCategory(path) {
    var newFoodCategory = [
        document.getElementById("CategoryName").value,
    ]
    axios.post(path, newFoodCategory).then(
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