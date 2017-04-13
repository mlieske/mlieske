function getSum() {
	var startNum = Number(document.getElementById("startNum").value);
	var endNum = Number(document.getElementById("endNum").value);
	var count = 0;
	var getSum = 0;
	
	if (startNum <= 0 || isNaN(startNum)) {
		alert("Please enter a positive starting number");
		document.getElementById("startNum").value = "";
		document.getElementById("startNum").focus();
		return false;
	}
	
	if (endNum <= 0 || isNaN(endNum)) {
		alert("Please enter a positive ending number");
		document.getElementById("endNum").value = "";
		document.getElementById("endNum").focus();
		return false;
	}
	
	if (startNum > endNum) {
		alert("Please enter a positive starting number");
		document.getElementById("startNum").value = "";
		document.getElementById("startNum").focus();
		return false;
	}
	
	for (var i = startNum; i <= endNum; i++) {
		count++;
		getSum += i;
	}
	
	document.getElementById("numCount").innerHTML = count;
	document.getElementById("firstNum").innerHTML = startNum;
	document.getElementById("secondNum").innerHTML = endNum;
	document.getElementById("numberSum").innerHTML = getSum;
	document.getElementById("showResults").style.display = "block";
	
	return false;
}