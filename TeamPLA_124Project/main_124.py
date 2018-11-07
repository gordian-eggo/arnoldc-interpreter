from dict_124 import *
from file_124 import load_file
from lexical_124 import lexer
from parsers_124 import parse

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
			line = line.strip()
			if line == "KTHXBYE":
				break
			elif line[:3] == "BTW":
				continue
			elif line[:4] == "OBTW":
				while line != "TLDR":
					line = input(">> ")
					line = line.strip()

			statement = line
			#print(statement)
			tokens = lexer(lexemes, statement)
			#print(tokens)
			parse(tokens, storage)
			#print(storage)
	else:
		print("ERROR: WTF Y U NO HAI U SNOB? I HET U!!11~ >:( ")
