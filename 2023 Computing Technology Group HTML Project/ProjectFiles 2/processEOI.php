<!DOCTYPE HTML>
<html lang ="en">
<head>
	<title>EOI Table Validation</title>
	<meta charset="utf-8">
	<meta name="description" content="Swinburne SoftWare Group">
	<meta name="keywords" content="Swinburne Software Group, PHP, HTML">
	<meta name="author"	content="Ethan Hair">
</head>

<body> 


<?php

echo "<p><b>Entered Data</b></p>";

//Checks for Job Reference Code
if (isset ($_POST["job_reference"])) {
    $job_reference = $_POST["job_reference"];
	trim($job_reference);
    echo "<p>Your Job Reference Code entered was $job_reference</p>";
}
else {
    echo "<p>Error: Please input Job Reference Code</p>";
}


//Checks for First Name
if (isset ($_POST["fname"])) {
    $fname = $_POST["fname"];
	trim($fname);
    echo "<p>Your First Name entered was $fname</p>";
}
else {
    echo "<p>Error: Please input First Name</p>";
}


//Checks for Last Name
if (isset ($_POST["lname"])) {
    $lname = $_POST["lname"];
	trim($lname);
    echo "<p>Your Last Name entered was $lname</p>";
}
else {
    echo "<p>Error: Please input Last Name</p>";
}


//Checks for Date of Birth
if (isset ($_POST["date"])) {
    $date = $_POST["date"];
	trim($date);
    echo "<p>Your Date of Birth entered was $date</p>";
}
else {
    echo "<p>Error: Please input DOB</p>";
}


//Checks for Gender
if (isset ($_POST["gender"])) {
    $gender = $_POST["gender"];
	trim($gender);
    echo "<p>Your Gender entered was $gender</p>";
}
else {
    echo "<p>Error: Please input Gender</p>";
}


//Checks for Address
if (isset ($_POST["address"])) {
    $address = $_POST["address"];
	trim($address);
    echo "<p>Your Address entered was $address</p>";
}
else {
    echo "<p>Error: Please input Address</p>";
}


//Checks for suburb
if (isset ($_POST["suburb"])) {
    $suburb = $_POST["suburb"];
	trim($suburb);
    echo "<p>Your Suburb entered was $suburb</p>";
}
else {
    echo "<p>Error: Please input Suburb</p>";
}


//Checks for postcode
if (isset ($_POST["postcode"])) {
    $postcode = $_POST["postcode"];
	trim($postcode);
    echo "<p>Your Postcode entered was $postcode</p>";
}
else {
    echo "<p>Error: Please input Postcode</p>";
}


//Checks for State
if (isset ($_POST["state"])) {
    $state = $_POST["state"];
	trim($state);
    echo "<p>Your State entered was $state</p>";
}
else {
    echo "<p>Error: Please input State</p>";
}


//Checks for Email
if (isset ($_POST["email"])) {
    $email = $_POST["email"];
	trim($email);
    echo "<p>Your Email entered was $email</p>";
}
else {
    echo "<p>Error: Please input Email</p>";
}


//Checks for Phone
if (isset ($_POST["phone"])) {
    $phone = $_POST["phone"];
	trim($phone);
    echo "<p>Your Phone entered was $phone</p>";
}
else {
    echo "<p>Error: Please input Phone</p>";
}


//Skills Area
if (isset ($_POST["category"])) {
	foreach($_POST["category"] as $value){  //code used from https://makitweb.com/get-checked-checkboxes-value-with-php/
		trim($value);
		echo "Selected skill: ".$value.'<br/>';
	}
}
else {
    echo "<p>Error: Please input Skills</p>";
}




echo "<br><p><b>Validation Check</b></p>";

//Validation
$alphaChar = "/^[a-zA-Z ]*$/";
$DOB = "/^(\d{2})\/(\d{2})\/(\d{4})*$/"; //DOB format taken from https://stackoverflow.com/questions/3720977/preg-match-check-birthday-format-dd-mm-yyyy
$alphaCharNum = "/^[a-zA-Z0-9 ]*$/";
$Num = "/^[0-9 ]*$/";
$PhoneNum = "/^(\s*[0-9+]){8,12}\s*$/"; //The addition of spaces format taken from https://stackoverflow.com/questions/32996004/regex-fixed-number-of-characters-but-any-quantity-of-spaces
$mailFormat = "/^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-z]{2,}$/";

//job reference code validation
if ($job_reference == "") {
	echo "<p>You must enter your Job Reference Code.</p>";
}
else if (!preg_match($alphaCharNum, $job_reference)) {
    echo "<p>Only 5 alphanumeric characters allowed in your job reference code</p>";
}
else {
    echo "<p>Job Refernce inputed Correctly</p>";
}

//First Name Validation
if ($fname == "") {
	echo "<p>You must enter your First Name.</p>";
}
else if (!preg_match($alphaChar, $fname)) {
	echo "<p>Only 20 alpha characters allowed in your First Name</p>";
}
else {
    echo "<p>First name inputed Correctly";
}

//Last Name Validation
if ($lname == "") {
	echo "<p>You must enter your Last Name.</p>";
}
else if (!preg_match($alphaChar, $lname)) {
    echo "<p>Only 20 alpha characters allowed in your Last Name</p>";
}
else {
    echo "<p>Last name inputed Correctly</p>";
}

//DOB validation
if ($date == "") {
	echo "<p>You must enter your date of birth.</p>";
}
else if (!preg_match($DOB, $date)) {
    echo "Only dd/mm/yyyy format allowed in your date of birth</p>";
}
else {
    echo "<p>Date of Birth entered correctly</p>";
}

//Gender Validation
if ($gender == "") {
	echo "<p>You must enter your Gender.</p>";
}
else {
    echo "<p>Gender inputed Correctly</p>";
}

//Address Validation
if ($address == "") {
	echo "<p>You must enter your Address.</p>";
}
else if (!preg_match($alphaCharNum, $address)) {
    echo "<p>Only 40 alphanumeric characters allowed in your Address</p>";
}
else {
    echo "<p>Address inputed Correctly</p>";
}

//Suburb Validation
if ($suburb == "") {
	echo "<p>You must enter your suburb.</p>";
}
else if (!preg_match($alphaCharNum, $suburb)) {
    echo "<p>Only 40 alphanumeric characters allowed in your suburb</p>";
}
else {
    echo "<p>Suburb inputed Correctly</p>";
}

//Postcode Validation
if ($postcode == "") {
	echo "<p>You must enter your postcode.</p>";
}
else if (!preg_match($Num, $postcode)) {
    echo "<p>Only 4 numbers allowed in your postcode</p>";
}
else {
    echo "<p>Postcode inputed Correctly</p>";
}

//Email Validation
if ($email == "") {
	echo "<p>You must enter your email.</p>";
}
else if (!preg_match($mailFormat, $email)) {
    echo "<p>Only email format allowed in your email</p>";
}
else {
    echo "<p>Email inputed Correctly</p>";
}

//Phone Validation
if ($phone == "") {
	echo "<p>You must enter your phone.</p>";
}
else if (!preg_match($PhoneNum, $phone)) {
    echo "<p>Only 8-12 numbers and '+' allowed in your phone</p>";
}
else {
    echo "<p>Phone entered correctly</p>";
}



?>





</body>