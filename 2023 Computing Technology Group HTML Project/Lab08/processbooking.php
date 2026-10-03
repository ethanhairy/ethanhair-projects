<!DOCTYPE html>
<html lang="en">
<head>
	<title>Rohirrim Booking</title>
	<meta charset="utf-8"/>
	<meta name="description" content="Rohirrim Booking Form">
	<meta name="keywords"    content="PHP, HTML">
	<meta name="author" 	 content="Ethan Hair">
</head>

<body>
	<h1>Rohirrim Tour Booking Confirmation</h1>

<?php

    if(isset ($_POST["firstname"])) {
        $firstname = $_POST["firstname"];
        echo "<p>This is a test: Your First Name is $firstname</p>";
    }
    else {
        echo "<p>Error: Enter data in the <a href='register.html'>form</a></p>";
    }

    if(isset ($_POST["lastname"])) {
        $lastname = $_POST["lastname"];
        echo "<p>This is a test: Your Last Name is $lastname</p>";
    }
    else {
        echo "<p>Error: Enter data in the <a href='register.html'>form</a></p>";
    }

    if(isset ($_POST["age"])) {
        $age = $_POST["age"];
        echo "<p>This is a test: Your Age is $age</p>";
    }
    else {
        echo "<p>Error: Enter data in the <a href='register.html'>form</a></p>";
    }

    if(isset ($_POST["food"])) {
        $food = $_POST["food"];
        echo "<p>This is a test: Meal Preference is: $food</p>";
    }
    else {
        echo "<p>Error: Enter data in the <a href='register.html'>form</a></p>";
    }

    if(isset ($_POST["partySize"])) {
        $partySize = $_POST["partySize"];
        echo "<p>This is a test: Your Party Size is $partySize</p>";
    }
    else {
        echo "<p>Error: Enter data in the <a href='register.html'>form</a></p>";
    }
?>




</body>