function findEvens() {
	var startNum = Number(document.getElementById("startNum").value);
	var endNum = Number(document.getElementById("endNum").value);
	var stepNum = Number(document.getElementById("stepNum").value);
	var storeNums = new Array();
	
	if (isNaN(startNum) || startNum == "") {
		alert("Please enter a starting number");
		document.getElementById("startNum").value = "";
		document.getElementById("startNum").focus();
		return false;
	}
	
	if (isNaN(endNum) || endNum == "") {
		alert("Please enter an ending number");
		document.getElementById("endNum").value = "";
		document.getElementById("endNum").focus();
		return false;
	}
	
	if (endNum <= startNum) {
		alert("Please enter an ending number that is more than the starting number");
		document.getElementById("endNum").value = "";
		document.getElementById("endNum").focus();
		return false;
	}
	
	if (isNaN(stepNum) || stepNum == "" || stepNum < 0) {
		alert("Please enter a positive step number");
		document.getElementById("stepNum").value = "";
		document.getElementById("stepNum").focus();
		return false;
	}
	
	for (var i = startNum; i <= endNum; i = i + stepNum) {
		if (i % 2 == 0) {
			storeNums.push(i);
			storeNums.push("<br\>");
		}
	}
	console.log(storeNums);
	document.getElementById("firstNum").innerText = startNum;
	document.getElementById("secondNum").innerText = endNum;
	document.getElementById("byStep").innerText = stepNum;
	document.getElementById("evenNums").innerHTML = storeNums.join("");
	document.getElementById("showResults").style.display = "block";
	return false;
}