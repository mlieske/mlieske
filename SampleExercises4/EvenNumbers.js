function EvenNumbers() {
	var startNum = Number(document.getElementById("startNum").value);
	var endNum = Number(document.getElementById("endNum").value);
	var stepNum = Number(document.getElementById("stepNum").value);
	var evensArray = new Array();
	
	console.log(startNum,endNum,stepNum);
	
	if (startNum == "" || isNaN(startNum)) {
		alert("enter a starting number");
		document.getElementById("startNum").value = "";
		document.getElementById("startNum").focus();
		return false;
	}
	
	if (endNum == "" || isNaN(endNum)) {
		alert("enter an ending number");
		document.getElementById("endNum").value = "";
		document.getElementById("endNum").focus();
		return false;
	}

	if (startNum >= endNum) {
		alert("enter an ending number that is greater than the start number");
		document.getElementById("endNum").value = "";
		document.getElementById("endNum").focus();
		return false;
	}

	if (stepNum == "" || isNaN(stepNum) || stepNum < 0) {
		alert("enter a positive step number");
		document.getElementById("stepNum").value = "";
		document.getElementById("stepNum").focus();
		return false;
	}
	for (i = startNum; i <= endNum; i += stepNum) {
		if (i % 2 == 0) {
			evensArray.push(i);
			evensArray.push("<br/>");
		}
	}
	
	document.getElementById("firstNum").innerHTML = startNum;
	document.getElementById("secondNum").innerHTML = endNum;
	document.getElementById("stepped").innerHTML = stepNum;
	document.getElementById("showEvens").innerHTML = evensArray.join("");
	document.getElementById("showResults").style.display = "block";

	return false;
}