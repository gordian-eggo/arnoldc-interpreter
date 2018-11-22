NOTES FOR CMSC 124 ARNOLDC INTERPRETER:

ArnoldC.jar - the ArnoldC language pack for reference. Usage: ArnoldC [-run|-declaim] [FileToSourceCode]
			- pag na-run ko siya nang maayos update ko kayo via readme/messenger haha

11-14-18, 2014H: caught exception for MatchCollections on lines 40 and 41. Parang di pa niya kaya basahin yung 
				 newline character kaya null yung nirereturn ng match(). Di ko pa sure kung paano ayusin.

		  2031H: fixed contents of Program.cs, nadoble yung laman. Inayos din ibang variable names for readability and added regex for 		   			   variables.	

		  2252H: add variable regex and changed variable names for readability. 

11-15-18, 0229H: took the working parts for variable and function names from Waldo's code. Not a merge, more of an update.
  approx. 0317H: added better matches for macros and and integers. Integers can now be read next to the keywords YOU SET US UP, GET UP, and GET DOWN.
  		  0748H: encountered exceptions at lines 43 and 72, not sure how to fix it so ask Ma'am. Short description below. 
  		  		 Line 43: System.ArgumentException has been thrown parsing the contents of line 41.
  		  		 Line 72: System.ArgumentNullException has been thrown, value cannot be null.
  		  0801H: possible cause for bug found. The while loop that iterates through the document while data = sr.ReadLine() 
  		  		 is not null stops at YOU HAVE BEEN TERMINATED without having analyzed the line.

11-18-18, 1301H: running sample.arnoldc for reference while making the state diagram. Comments in section below.
		  1437H: finished making sample programs for reference re: ArnoldC syntax. 
		         To run, use the command: clear && java -jar ArnoldC.jar <filename>.arnoldc && java <filename>

11-21-18, 1737H: checked Waldo's code for lexical analyzer using C#'s dictionary. Bugs include:

				 > string literals are read as string literals and identifiers, e.g. "hello" is saved in the dictionary as a string literal and an identifier. Same thing happens for integer literals.

				 > variables are mistakenly saved as just identifiers. They have to be saved as "variable names"/"variable identifiers" to avoid confusion during syntax analysis (Fully fixed as of 2343H)

				 > variable names are allowed to have capital letters, ergo the variable ABC in lexemes.arnoldc should be read and saved as a variable (Fully fixed as of 2343H)

				 NOTE: variable names cannot have special characters like _/&/%/$ and so on. This counts as a bug, but the fix is a bit more advanced than we have time for at the moment.

		  1957H: falling out with Waldo is the last straw in a haystack of issues so will resume code alone. Adjusted variable names for  			   readability again, for the last time.

		  2343H: Fixed the bug where variable names are allowed to have capital letters. Due to time constraints, I might have to assume that 		   the user will adopt a more or less conventional variable naming scheme far from the likes of h4xx0r style.

		  2352H: Partially fixed the bug where integer literals are read as integer literals and identifiers. Moved the conditional loops for 		   it into pre-existing keyword conditional loops.

		  0007H: Encountered another bug. The fix for the first bug where you move conditional loops into the pre-existing keyword loops result 	   in the keyword being written to the dictionary twice. (Fixed as of 0009H)

		  0037H: Having trouble getting the regex for the macros correct. The @ character isn't getting read. But I will not lose hope, for my 		   roommate bought me McDonalds. Additionally, it might need the use of the "\p{}" regex using the Unicode value for @

11-22-18, 1009H: fixed while loop regexes such that the contents can be added to the dictionary of lexemes.


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
	> you can't put a GET TO THE CHOPPER loop and/or a HEY CHRISTMAS TREE variable declaration inside a previous GET TO THE CHOPPER loop
	> you can't put a print statement between HEY CHRISTMAS TREE and YOU SET US UP
	> you can't put if statements/if-else statements inside a GET TO THE CHOPPER loop