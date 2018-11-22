function validate (){
	var name = document.getElementById("name");
	if (name == ""){
		alert("Please enter a valid name.");
		return false;
	}else{
		return true;
	}
}