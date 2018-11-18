NOTES FOR CMSC 124 ARNOLDC INTERPRETER:

ArnoldC.jar - the ArnoldC language pack for reference. Usage: ArnoldC [-run|-declaim] [FileToSourceCode]
			- pag na-run ko siya nang maayos update ko kayo via readme/messenger haha

11-14-18, 2014H: caught exception for MatchCollections on lines 40 and 41. Parang di pa niya kaya basahin yung 
				 newline character kaya null yung nirereturn ng match(). Di ko pa sure kung paano ayusin.

		  2031H: fixed contents of Program.cs, nadoble yung laman. Inayos din ibang variable names for readability
		  		 and added regex for variables.	

		  2252H: add variable regex and changed variable names for readability. 

11-15-18, 0229H: took the working parts for variable and function names from Waldo's code. Not a merge, more of an update.
  approx. 0317H: added better matches for macros and and integers. Integers can now be read next to the keywords YOU SET US 			   UP, GET UP, and GET DOWN.
  		  0748H: encountered exception at lines 43 and 72, not sure how to fix it so ask Ma'am. Short description below. 
  		  		 Line 43: System.ArgumentException has been thrown parsing the contents of line 41.
  		  		 Line 72: System.ArgumentNullException has been thrown, value cannot be null.
  		  0801H: possible cause for bug found. The while loop that iterates through the document while data = sr.ReadLine() 
  		  		 is not null stops at YOU HAVE BEEN TERMINATED without having analyzed the line.

11-18-18, 1301H: running sample.arnoldc for reference while making the state diagram. Comments in section below.
		  1437H: finished making sample programs for reference re: ArnoldC syntax. 
		         To run, use the command: clear && java -jar ArnoldC.jar <filename>.arnoldc && java <filename>


COMMENTS ON SYNTAX:

	> Variable names with underscores and possibly other special characters are not allowed.
	> YOU SET US UP doesn't work with string variables
	> free-form positioning
	> the GET TO THE CHOPPER loop completely erases and replaces the value in a variable with a new value defined inside the loop
	> if you do a comparison inside the GET TO THE CHOPPER loop, for example: "temp = 4 > 5" and then print it, it will print either 1(true) or 0(false)
	> if statements are harder, will need more time to make a suitable state diagram for them
	> structure for if-else statement:
		1. initialize a variable with a value
		2. (optional) GET TO THE CHOPPER loop
		3. if/if-else statement
	> if the value on BECAUSE I'M GOING TO SAY PLEASE is greater than 0, it will execute the if-statement
	> if there's no GET TO THE CHOPPER loop, it will automagically execute the if-statement and ignore the "else" art if there is one
	> the value of the condition statement has to be calculated beforehand
	> initialize all variables that you're going to use
	> you have to compare the value for the while loop to a different value in a different variable