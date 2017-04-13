function showEvens() {
	var startNum = Number(document.getElementById("startNum").value);
	var endNum = Number(document.getElementById("endNum").value);
	var stepNum = Number(document.getElementById("stepNum").value);
	console.log(startNum, endNum, stepNum);
	console.log(typeof startNum, typeof endNum, typeof stepNum);
	
	if(isNaN(startNum) || startNum == "") {
		alert("Please enter a number as the Starting Number");
		document.getElementById("startNum").value = "";
		document.getElementById("startNum").focus();
		return false;
	}
	
	if(isNaN(endNum) || endNum == "") {
		alert("Please enter a number as the End Number");
		document.getElementById("endNum").value = "";
		document.getElementById("endNum").focus();
		return false;
	}
	
	if(endNum <= startNum) {
		alert("Please enter an Ending Number that is greater than the Starting Number");
		document.getElementById("endNum").value = "";
		document.getElementById("endNum").focus();
		return false;
	}

	if(isNaN(stepNum) || stepNum == "" || stepNum <= 0) {
		alert("Please enter a positive number as the Step");
		document.getElementById("stepNum").value = "";
		document.getElementById("stepNum").focus();
		return false;
	}
	
	document.getElementById("firstNum").innerHTML = startNum;
	document.getElementById("secondNum").innerHTML = endNum;
	document.getElementById("byStep").innerHTML = stepNum;

	var numArray = new Array();
	for (var i = startNum; i <= endNum; i = i+stepNum) {
		if (i % 2 === 0) {
//			console.log("i is: " + i);
			numArray.push(i);
			numArray.push("<br\>");
//			document.getElementById("numList").innerHTML += i + "<br/>";
		}
	}
//	console.log(numArray);
	document.getElementById("numList").innerHTML = numArray.join("");
	document.getElementById("showResults").style.display = "block";
	return false;
	
}