function findEvens() {
	var startNum = document.getElementById("startNum").value;
	var endNum = document.getElementById("endNum").value;
	var stepNo = document.getElementById("step").value;
	startNum = Number(startNum);
	endNum = Number(endNum);
	stepNo = Number(stepNo);
	
	console.log(typeof startNum, typeof endNum, typeof stepNo);

	if (isNaN(startNum)|| startNum == "") {
		alert("Please enter a number as a starting number");
		document.forms["getNumbers"]["startNum"].value = "";
		document.forms["getNumbers"]["startNum"].focus();
		return false;
	}
	if (isNaN(endNum)|| endNum == "") {
		alert("Please enter a number as an ending number");
		document.forms["getNumbers"]["endNum"].value = "";
		document.forms["getNumbers"]["endNum"].focus();
		return false;
	}
	if (isNaN(stepNo)|| stepNo < 0 || stepNo == "") {
		alert("Please enter a positive number as a step");
		document.forms["getNumbers"]["step"].value = "";
		document.forms["getNumbers"]["step"].focus();
		return false;
	}
	console.log(startNum, endNum);
	if (endNum <= startNum) {
		alert("Please enter an ending number that is larger than the starting number");
		document.forms["getNumbers"]["endNum"].value = "";
		document.forms["getNumbers"]["endNum"].focus();
		return false;
	}

	
//	console.log("startNum: " + startNum + " endNum: " + endNum + " step: " + stepNo + " diff: " + diff);
	for (var i = startNum; i <= endNum; i = i + stepNo) {
		if (i % 2 == 0) {
			console.log("Even: " + i);
			document.getElementById("evenNums").innerHTML = document.getElementById("evenNums").innerHTML + i + "<br/>";
//			document.getElementById("evenNums").innerText = document.getElementById("evenNums").innerText +;
		}
	}
	
	document.getElementById("numDisplay").style.display = "block";
	document.getElementById("firstNum").innerText = startNum;
	document.getElementById("secondNum").innerText = endNum;
	document.getElementById("dispstep").innerText = stepNo;
	return false;
}