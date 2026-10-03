<!DOCTYPE HTML>
<html lang ="en">
<head>
	<title>SoftWare ~ Job Applications</title>
	<link rel="stylesheet" href="styles/style.css">
	<meta charset="UTF-8">
	<meta name="description" content="Swinburne SoftWare Group - apply for jobs at SoftWare">
	<meta name="keywords" content="Swinburne, Software, Jobs, SoftWare">
	<meta name="author"	content="Ethan Hair">
</head>
<body>
	<header>
		<?php
			include_once ("header.inc");
			include_once ("menu.inc");
		?>
	</header>

	<div class="JobApplication">
	<h1>Job Application Page</h1> <!-- Header of the page -->
	</div>
	
	
	<!-- creates a form for the user to input required data -->
	<form method="post" action="processEOI.php" novalidate="novalidate">
	<div class="ApplicantForm">
		<!--Start of The application form, which is defines within the fieldset Apply Form-->
		<fieldset id="ApplyForm">
			
			<P>
				<label for="job_reference">Job Reference Code: </label>
				<!--min and max length defines the amount of characters that can be entered into the field-->
				<!-- placeholder shows a set of defined characters within the field--> 
				<input type="text" name="job_reference" id="job_reference" required="required" minlength="5" maxlength="5" placeholder="#####"> 
				<br>
				
			</p>
			<h3><b>Name</b></h3>
			<p>
				<label for="fname"></label>
				<input type="text" name="fname" id="fname" required="required" pattern="[A-Za-z-]{1,20}" placeholder="First"> 
				<!--Any letters can be selected and 1-20 characters can be inputed-->
				
				<label for="lname"></label>
				<input type="text" name="lname" id="lname" required="required" pattern="[A-Za-z-]{1,20}" placeholder="Last"> 
				<!--Any letters can be selected and 1-20 characters can be inputed-->
			</p>
			<h3><b>Date of Birth</b></h3>
			<p>
				<label for="date"></label> 
				<input type="text" id="date" name="date" required="required" placeholder="dd/mm/yy" pattern="\d{2}/\d{2}/\d{4}"> 
				<!--The  DOB format must be 00/00/0000 to be allowed-->
			</p>
			
			<!-- Start of GenderField fieldset-->
			<fieldset id="GenderField">
				
				<legend><h3><b>Gender</b></h3></legend>
				<p>
					<label for="male">
					<input type="radio" name="gender" id="male" value="male" required="required"> 
					<!--Radio Button Male-->
					Male</label> 
				
					<label for="female">
					<input type="radio" name="gender" id="female" value="female" required="required"> 
					<!--Radio Button Female-->
					Female</label> 

					<label for="othergender">
					<input type="radio" name="gender" id="othergender" value="other" required="required"> 
					<!--Radio Button Other-->
					Other</label> 
				</p>
			</fieldset>
			<!-- End of GenderField fieldset-->
			<p>
				<label for="address">Street Address:</label>
				<input type="text" name="address" id="address" required="required" maxlength="40"> 
				<!--Field must be a max of 40 characters-->
			</p>

			<p>
				<label for="suburb">Suburb/Town:</label>
				<input type="text" name="suburb" id="suburb" required="required" maxlength="40"> 
				<!--Field must be a max of 40 characters-->

				<label for="postcode">Postcode:</label>
				<input type="text" name="postcode" id="postcode" required="required" pattern="\d{4}" maxlength="4"> 
				<!--4 digit postcodes in Aus, pattern makes the postcode be required to be 4 digits exactly--> 
			
			</p>
			<p>
				<label for="state">State:</label>
				<select name="state" id="state">
					<option value="ACT">ACT</option>	<!-- Option value defines ACT in the dropdown box -->		
					<option value="NT">NT</option>		<!-- Option value defines NT in the dropdown box -->	
					<option value="QLD">QLD</option>	<!-- Option value defines QLD in the dropdown box -->	
					<option value="SA">SA</option>		<!-- Option value defines SA in the dropdown box -->	
					<option value="TAS">TAS</option>	<!-- Option value defines TAS in the dropdown box -->	
					<option value="VIC">VIC</option>	<!-- Option value defines VIC in the dropdown box -->	
					<option value="WA">WA</option>		<!-- Option value defines WA in the dropdown box -->	
				</select>
			</p>


			<div class="ContactField">
			<fieldset id="Contact">
				<legend><h3><b>Contact Information</b></h3></legend>
				<p><label for="email">Email:</label>
				<input type="email" name="email" id="email" pattern="[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,}$" required="required">
				<!-- Pattern Code from W3schools.com input pattern examples page. it allows the email to be a valid format. (Characters + @ + Characters + . + Domain)-->
				</p>
			
				<p><label for="phone">Phone:</label>
				<input type="text" name="phone" id="phone" pattern="[0-9]{8,12}"  required="required"> 
				<!--allows for the phone number to be between 8-10 digits long and cannot include any letters or symbols-->
				</p>
			</fieldset>
			</div>
			
			<label for="resume">Resume:</label> 
			<!--Uses type=file as to allow the user to upload their resume as either a pdf, doc or docx -->
			<input type="file" name="resume" id="resume" accept=".pdf,.doc,.docx">
			<br>
			<br>

			<div class="SkillField">
			
			<fieldset>
				<legend><b>Skills</b></legend>
				<p>Select all that apply to You</p>
				<p><label for="efficient">Efficient</label> 
					<input type="checkbox" id="efficient" name="category[]" value="efficient">
				
					<label for="organised">Organised</label> 
					<input type="checkbox" id="organised" name="category[]" value="organised">
				
					<label for="attentive">Attentive</label> 
					<input type="checkbox" id="attentive" name="category[]" value="attentive">
				</p>
				<p><label for="reliable">Reliable</label> 
					<input type="checkbox" id="reliable" name="category[]" value="reliable">
				
					<label for="collaborative">Collaborative</label> 
					<input type="checkbox" id="collaborative" name="category[]" value="collaborative">
				
					<label for="adaptable">Adaptable</label> 
					<input type="checkbox" id="adaptable" name="category[]" value="adaptable">
				</p>
				<p><label for="other">Other:</label> 
				<p>
					<textarea id="other" name="category[]" rows="4" cols="50" placeholder="Please follow up other skils with a ','. (eg. time management, clean)"></textarea> <!--Placeholder fills the text area with a temporary text-->
				</p>
			</fieldset>
			</div>
			
		</fieldset>
		<!--Start of The application form, which is defines within the fieldset Apply Form-->
		<div class="SubRes">
			<input type= "submit" value="Apply" id="submit"> <!--Allows the Form to be submitted-->
			<input type= "reset" value="Clear Form" id="reset"> <!--Allows the Forms Fields to be Reset to their default state-->
		</div>
	</div>
	<br>
	
	</form>
	
	<?php include_once("footer.inc");?>
</body>
</html>