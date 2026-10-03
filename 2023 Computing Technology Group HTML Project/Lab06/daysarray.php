<!DOCTYPE html>
<html lang="en">
<head>  
    <meta charset="utf-8">
    <title>Using PHP Variables, arrays and operators</title>
    <meta name="description" content="PHP Variables, arrays and operators" />
    <meta name="keywords" content="PHP" />
    <meta name="author" content="Ethan Hair"  />
</head>
<body>
    <h1>PHP Variables, Arrays and Operators </h1>
<?php
    $days = array("Mon", "Tue", "Wed", "Thu", "Fri", "Sat", "Sun");
    echo "<p>The day of the week in english are: </p>";
    foreach($days as $day) {
        if ($day != "Sun") {
            echo $day , ", ";
        }
        else {
            echo $day , ".";
        }
    }
    $days = array("Dim", "Lun", "Mar", "Mer", "Jen", "Ven", "Sam");
    echo "<p>The day of the week in french are: </p>";
    foreach($days as $day){
        if ($day != "Sam") {
            echo $day , ", ";
        }
        else {
            echo $day , ".";
        }
    }
?>
</body>
</html>