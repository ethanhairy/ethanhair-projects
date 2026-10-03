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
    <h1>PHP Variables, Arrays and Operators</h1>
<?php
    $marks = array (85, 85, 95);
    $marks[1] = 90;
    $ave = ($marks[0] + $marks[1] + $marks[2])/3;
    if($ave >= 50) 
        $status = "PASSED";
    else 
        $status = "FAILED";
    echo "<p>The Average Score is $ave. You $status.</p>"
    ?>

</body>
</html>