<%@ page language="java" contentType="text/html; charset=ISO-8859-1"
	pageEncoding="ISO-8859-1"%>
<!DOCTYPE html>
<html>
<head>
<meta charset="ISO-8859-1">
<link
	href="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/css/bootstrap.min.css"
	rel="stylesheet">
<link rel="stylesheet" href="/resources/css/style.css">
<script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
<script type="text/javascript" src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
<script type="text/javascript" src="/resources/css/index.js"></script>



<title>Spring Boot</title>
</head>
<body>
	<div id="eingabe">
		<div class="container">
			<div class="jumbotron">
				<h1>Geben Sie hier Ihren Namen ein</h1>
				<!--  <form action="game" method="get">-->
					<div class="input-group">
						<input id="name" type="text" class="form-control">
						<div class="input-group-btn">
							<button id ="start" class="btn btn-success" type="submit">Spiel starten</button>
						</div>
					</div>
				<!--  </form>-->
			</div>
		</div>
	</div>
	<div id="failure" class="alert alert-danger alert-dismissible fade show hide" role="alert"> 
		<pre id="failure-response"></pre>
		<button id="failure-btn" type="button" class="close" aria-label="Close">
			<span aria-hidden="true">&times;</span>
		</button>
	</div>
</body>
</html>