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