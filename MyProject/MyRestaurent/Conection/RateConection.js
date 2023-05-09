//הכנסת כל המנות לדף התפריט
function makePostRequestRate(path) {
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