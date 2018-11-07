from lexical import *
from syntax import *
from file import *
from dict import lexemes

while True:
	input_line = str(input(">> "))
	tokens = lexer(lexemes, input_line)
	# print(tokens) 
	syntax_analyzer(lexemes, tokens)
	
