<!DOCTYPE html>
<html lang="en">
    <head>
        <meta charset="utf-8">
        <meta name="description" content="Creating Web Applications Lab 10">
        <meta name="keywords" content="PHP, MySql">
        <title>Retrieving records to HTML</title>
    </head>
    <body>
        <h1>Creating Web Applications - Lab10</h1>
        <?php
            require_once("settings.php");

            $conn = @mysqli_connect($host, $user, $pwd, $sql_db);

            //Check for failed connection
            if(!$conn) {
                //Display error message
                echo "<p>Database connection failure</p>";
            } else {

                mysqli_close($conn);
            }

    function cleanString($conn, $string) { return mysqli_escape_string($conn, htmlspecialchars(trim($string))); }
?>
</body>
</html>