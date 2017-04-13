function whenLoaded() {
//	alert("page has been loaded!");
	document.getElementById("onloadAlert").style.display = "inline";
}

function findEvens() {
	var startNum = Number(document.getElementById("startNum").value);
	var endNum = Number(document.getElementById("endNum").value);
	var stepNum = Number(document.getElementById("stepNum").value);
	var evensArray = new Array();
	
	console.info(startNum, endNum, stepNum);
	
	if (startNum == "" || isNaN(startNum)) {
		alert("enter start number");
		document.getElementById("startNum").class = "has-error";
		document.getElementById("startNum").value = "";
		document.getElementById("startNum").focus();
		return false;
	}
	
	if (endNum == "" || isNaN(endNum)) {
		alert("enter ending number");
		document.getElementById("endNum").value = "";
		document.getElementById("endNum").focus();
		return false;
	}
	
	if (endNum <= startNum) {
		alert("enter endnum greater than startnum");
		document.getElementById("endNum").value = "";
		document.getElementById("endNum").focus();
		return false;
	}
	
	if (stepNum == "" || stepNum <=0 || isNaN(stepNum)) {
		alert("endter stepnum that is positive");
		document.getElementById("stepNum").value = "";
		document.getElementById("stepNum").focus();
		return false;
	}
	
	for (var i = startNum; i <= endNum; i += stepNum) {
		if (i % 2 === 0) {
			evensArray.push(i);
			evensArray.push("<br\>");
		}
	}
	
	document.getElementById("firstNum").innerHTML = startNum;
	document.getElementById("secondNum").innerHTML = endNum;
	document.getElementById("step").innerHTML = stepNum;
	document.getElementById("showEvens").innerHTML = evensArray.join("");
	document.getElementById("showResults").style.display = "block";
	
	return false;
}
