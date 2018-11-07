import re
import sys

def syntax_analyzer(lexeme_list, tokens):
	# assuming whitespaces take only one cell..
	line_count = 0
	index = 0
	match = 0
	while index <= len(tokens):								# len(tokens) - 1????
		print(tokens)
		actual, (tag, next_list) = tokens[index] 			# "unravel" the tuple
		if actual == '\n': line_count += 1					# no need to regex this shit i guess..?
		for accepted_lexeme in next_list:					# for every regex in the next_list
			regex = re.compile(accepted_lexeme)
			next_actual, (tag, next_next_list) = tokens[index]
			match = regex.match(next_actual, 0)					# not sure about this, match regex to the array element
		if not match:
			sys.stderr.write('Error at line <n>. Expected: (%s). Found: <something else>\n' % next_list) 
			# <something else> the next next list element. can be accessed using index.
			# idk how to print > 1 variables in one statement. 
			sys.exit(1)
		index += 1

'''
	So basically kelangan nasa labas yung mga ibang variables. Like in an ipapasa sa function kinda way.
	Fuck.
	
	1025H: No matter what the test case is the error's still "Error at line <n>. Expected: ([]). Found: <something else>"
		   Program also throws error when you give it a newline character
	1029H: Tried Ren's suggestion about line 14. addded the next_actual line and made the match index 0 again.
	       Nothing happened.
	1059H: It can read whitespaces under certain conditions.
		   If you spell something wrong like "HAAI", it'll read it as a variable which is okay, but it won't read the
		   "AI" at the end 
'''