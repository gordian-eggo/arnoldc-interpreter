from lexical import *
#from syntax import *
from file import *
from dict import lexemes

storage = {}

# gawing function 'to to check for HAI, KTHXBYE???
# im sorry ang uncreative ko sa names ffs kayo magrename nito huhuhu
while True:
	statement = ""
	line = input(">> ")
	line = line.strip()
	if line[:3] == "BTW":
		continue
	elif line[:4] == "OBTW":
		while line != "TLDR":
			line = input(">> ")
			line = line.strip()
	elif line == "HAI":
		while True:
			line = input("++ ")
			line = line.strip()										# kinky jk. removes all trailing spaces before and after the string.
			if line == "KTHXBYE":
				break
			elif line[:3] == "BTW":
				continue
			elif line[:4] == "OBTW":
				while line != "TLDR":
					line = input(">> ")
					line = line.strip()

			statement = statement + " " + line
		
		print(statement)
		tokens = lexer(lexemes, statement)
		# insert parse fn here
		print(tokens)
	else:
		print("ERROR: WTF Y U NO HAI U SNOB? I HET U!!11~ >:( ")
