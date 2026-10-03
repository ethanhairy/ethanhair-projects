<!DOCTYPE html>
<html>
<head>
	<title>SoftWare ~ About Us</title>
	<link rel="stylesheet" href="styles/style.css">
	<meta charset="UTF-8">
	<meta name="description" content="Swinburne SoftWare Group - apply for jobs at SoftWare">
	<meta name="keywords" content="Swinburne, Software, Jobs, SoftWare">
</head>
<body>
	<header>
		<?php
			include_once ("header.inc");
			include_once ("menu.inc");
		?>
	</header>
  
	<main id="aboutUsMain">
		<h1>About Us</h1>
    <dl id="groupDetails">
        <dt>Group Name</dt>
        <dd>Swinburne Software Group</dd>
        <dt>Group ID</dt>
        <dd>007</dd>
        <dt>Tutor's Name</dt>
        <dd>Ru Jia</dd>
        <dt>Course you are doing</dt>
        <dd>Bachelor of Computer Science</dd>
    </dl>
    <fig><img id="groupPhoto" src="images/GroupPhotomin.jpg" alt="Group photo"></fig>
    <table id="timeTable">
      <tr>
        <th>Timetable</th>
        <td>
          <table>
            <thead>
              <tr>
                <th>Day</th>
                <th>Time</th>
                <th>Activity</th>
              </tr>
            </thead>
            <tbody>
              <tr>
                <td>Monday</td>
                <td>1:00pm - 3:00pm</td>
                <td>Home Page Discussion</td>
              </tr>
              <tr>
                <td>Tuesday</td>
                <td>11:00am - 1:00pm</td>
                <td>Apply Page Discussion</td>
              </tr>
              <tr>
                <td>Wednesday</td>
                <td>2:30pm - 5:00pm</td>
                <td>Job Page Discussion</td>
              </tr>
              <tr>
                <td>Thursday</td>
                <td>10:00am - 1:00pm</td>
                <td>About Us Discussion</td>
              </tr>
              <tr>
                <td>Friday</td>
                <td>2:00pm - 4:00pm</td>
                <td>Enhancements Discussion</td>
              </tr>
            </tbody>
          </table>
        </td>
      </tr>
    </table>
    <p>
      Email <a href="mailto:group007@outlook.com">group007@outlook.com</a>
    </p>
	</main>

	<?php include_once("footer.inc");?>
</body>
</html>