/**
 * 
 */

$(document).ready(function() {
	//Vestecke failure, wenn Dokument geladen wird
	$("#failure").hide();
	
	$('#start').attr('disabled','disabled');
    $('#name').keyup(function() {
       if($("#name").val() != '') {
          $('#start').removeAttr('disabled');
       }
       else {
       $('#start').attr('disabled','disabled');
       }
    });

	//bei Schließen des Alert
	$("#failure-btn").click(function(e){
		$("#failure").hide();
	})
	
	//Funktion, die bei Klicken des Startbuttons ausgefhrt wird
	$("#start").click(function(){
		
		//falls kein Name eingegeben wurde, breche ab
		if($("#name").val()=== ""){
			$("#failure-response").text("Bite gebe deinen Namen ein.")
			$("#failure").show();
			$("#failure").delay(7000).fadeOut();
			return;
		}
		
		//speicher den eingegebenen Namen
		let newUser = $("#name").val();
		
		//speichern des Users, Kommunikation mit Controller
		$.ajax({
			url : "/user",
			type : "POST",
			contentType : "application/json; charset=uft-8",
			data : JSON.stringify( { name: newUser}),
			success : function() {
					console.log("Successfully added User.");
			},
			error : function(response){
					console.log("Adding user failed.")
			},
		});
		
		
	})	
	
})