function countingCharacters(stringToCount) {
	console.log("The string has " + stringToCount.length + " characters");
}
function countingCharacters2(stringToCount, charToFind) {
	var charCount = 0;
	for (var i = 0; i < stringToCount.length; i++) {
		if (stringToCount[i] == charToFind) {
			charCount++;
		}
	}
	console.log("That letter appeared " + charCount + " times");
}

function countingCharacters25(stringToCount, stringToFind) {
	var count = 0;
	var numChars = stringToFind.length;
	var lastIndex = stringToCount.length - numChars;
	var stringToCompare = "";
	for (var i = 0; i <= lastIndex; i++) {
		for (var j = 0; j < numChars; j++) {
			stringToCompare += (stringToCount[i+j]);
		}
		if(stringToCompare == stringToFind) {
			count++;
		}
		stringToCompare = "";
	}
	console.log("String to count: " + stringToCount);
	console.log("String to find: " + stringToFind);
	console.log("String appeared " + count + " times");
}

function countingCharacters3(stringToCount, stringToFind) {
	var count = 0;
	var numChars = stringToFind.length;
	var lastIndex = stringToCount.length - numChars;
	for (var i = 0; i <= lastIndex; i++) {
		var stringToCompare = stringToCount.substring(i, i+numChars);
		if( stringToCompare == stringToFind) {
			count++;
		}
	}
	return count;
}

function dividingFriends() {
	var friends = ["Susan", "Bob", "Sheri", "Harry", "Mike", "Brian"];
	var team1 = new Array();
	var team2 = new Array();
	for (var i=0; i < friends.length; i++) {
		if (i%2 === 0) {
			team1[team1.length] = friends[i];
		}
		else {
			team2[team2.length] = friends[i];
		}
	}
	console.log("Team 1 is:  " + team1);
	console.log("Team 2 is:  " + team2);
}

function findMax(numArray) {
	var minNum = numArray[0];
	for (var i = 0; i < numArray.length; i++) {
		if (numArray[i] < minNum) {
			minNum = numArray[i];
		}
	}
	console.log("Minimum number is: " + minNum);
}
