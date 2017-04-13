function getEvens() {
	var startNum = Number(document.forms["getNums"]["startNum"].value); //works for both id and name = "startNum"
	var endNum = Number(document.getElementById("endNum").value);
	var stepNum = Number(document.getElementById("stepNum").value);
	var evensArray = new Array();
	
	if (startNum == "" || isNaN(startNum)) {
		alert("Enter a number in Starting Number");
		document.getElementById("startNum").value = ""
		document.getElementById("startNum").focus();
		return false;
	}
	
	if (endNum == "" || isNaN(endNum)) {
		alert("Enter a number in Ending Number");
		document.getElementById("endNum").value = ""
		document.getElementById("endNum").focus();
		return false;
	}
	
	if (startNum >= endNum) {
		alert("Enter an Ending Number that is greater than the Starting Number");
		document.getElementById("endNum").value = ""
		document.getElementById("endNum").focus();
		return false;
	}
	
	if (stepNum == "" || isNaN(stepNum) || stepNum < 0) {
		alert("Enter a positive number as a step");
		document.getElementById("stepNum").value = ""
		document.getElementById("stepNum").focus();
		return false;
	}
	
	for (var i = startNum; i <= endNum; i+=stepNum) {
		if (i % 2 === 0) {
			evensArray.push(i);
			evensArray.push("<br\>");
		}
	}
	
	document.getElementById("firstNum").innerHTML = startNum;
	document.getElementById("secondNum").innerHTML = endNum;
	document.getElementById("stepped").innerHTML = stepNum;
	document.getElementById("evenResults").innerHTML = evensArray.join("");
	document.getElementById("showResults").style.display = "block";
	
	return false;
}