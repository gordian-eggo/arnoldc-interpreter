from datatype_124 import *
from dict_124 import *
from operator import *

def parse(statement, storage):
	re, kw = statement.pop(0)							# get the kw part from tuple
	first = re
	parsed = False									

	if kw == kw_decl_var: 			parsed = sub_parse_decl(statement, storage)
	elif kw == kw_oper_add: 		parsed = sub_parse_add(statement, storage)
	elif kw == kw_oper_sub: 		parsed = sub_parse_sub(statement, storage)
	elif kw == kw_oper_mul: 		parsed = sub_parse_mul(statement, storage)
	elif kw == kw_oper_div: 		parsed = sub_parse_div(statement, storage)
	elif kw == kw_oper_mod: 		parsed = sub_parse_mod(statement, storage)
	elif kw == kw_oper_grt: 		parsed = sub_parse_grt(statement, storage)
	elif kw == kw_oper_lst: 		parsed = sub_parse_lst(statement, storage)
	elif kw == kw_oper_cat_start:   parsed = sub_parse_cat(statement, storage)
	elif kw == kw_bool_not:			parsed = sub_parse_not(statement, storage)	
	elif kw == kw_bool_and:			parsed = sub_parse_and(statement, storage)
	elif kw == kw_bool_or:			parsed = sub_parse_or(statement, storage) 
	elif kw == kw_bool_and_inf:		parsed = sub_parse_and_inf(statement, storage)
	elif kw == kw_bool_or_inf:		parsed = sub_parse_or_inf(statement, storage)
	elif kw == kw_prnt:				parsed = sub_parse_print(statement, storage)
	elif kw == variable_name:		parsed = sub_parse_assn(first, statement, storage)
	else: 							return False

	return parsed    

def sub_parse_assn(first, statement, storage):
	statement.pop(0)

	re, kw = statement.pop(0) 

	if kw == lit_int:			re = int(re)
	elif kw == lit_float:		re = float(re)
	elif kw == lit_string: 		re = re.replace('"','')
	elif kw == lit_bool:		re = bool(re)

	if storage.get(first) == None:
		print("ERROR: Variable not initialized. DO U HAS IT?")
		return False
	else:
		storage[first] = re
		return True

def sub_parse_decl(statement, storage):
	re, kw = statement.pop(0)
	if kw != variable_name: 
		print("ERROR: Expected {}, got {}.".format(variable_name, kw))
		return False

	# initialize variable name
	temp = re
	storage[temp] = 0

	# check if there's more
	if len(statement) == 0:
		return True

	# pop and check an expected "ITZ"
	re, kw = statement.pop(0)
	if kw == kw_decl_val:
		# pop the value and assign it to var
		re, kw = statement.pop(0)

		# typecast to int or float or more(?)
		if kw == lit_int:			re = int(re)
		elif kw == lit_float:		re = float(re)
		elif kw == lit_string: 		re = re.replace('"','')
		elif kw == lit_bool:		re = bool(re)

		storage[temp] = re
		return True

	else:
		print("ERROR: Expected {}, got {}.".format(kw_decl_val, kw))
		return False

# copy pasta for other operations
# max(x,y) for biggr of
# min(x,y) for smallr of 
def sub_parse_add(statement, storage):
	# get the first operand as a start
	re, kw = statement.pop(0)
	
	# typecast
	if kw == lit_int:
		re = int(re)
	elif kw == lit_float:	
		re = float(re)
	elif kw == variable_name:
		re = storage[re]

	temp = re
	
	# pop AN and operands and do operation on operands
	while (len(statement) > 0):

		# pop AN
		re, kw = statement.pop(0)
		if kw != kw_conj:
			print('ERROR: Expected {}, got {}.'.format(kw_conj, kw))
			return False

		# pop operand, typecast, and do operation
		if (len(statement) > 0):
			re, kw = statement.pop(0)
			if kw == lit_int:
				re = int(re)
			elif kw == lit_float:
				re = float(re)
			elif kw == variable_name:
				re = storage[re]

			temp = temp + re

		else:
			print('ERROR: Unexpected end of statement')
			return False

	# assigns the final value to the anon var
	print(temp)
	storage['IT'] = temp
	return True

def sub_parse_sub(statement, storage):
	# get the first operand as a start
	re, kw = statement.pop(0)
	
	# typecast
	if kw == lit_int:
		re = int(re)
	elif kw == lit_float:	
		re = float(re)
	elif kw == variable_name:
		re = storage[re]

	temp = re
	
	# pop AN and operands and do operation on operands
	while (len(statement) > 0):

		# pop AN
		re, kw = statement.pop(0)
		if kw != kw_conj:
			print('ERROR: Expected {}, got {}.'.format(kw_conj, kw))
			return False

		# pop operand, typecast, and do operation
		if (len(statement) > 0):
			re, kw = statement.pop(0)
			if kw == lit_int:
				re = int(re)
			elif kw == lit_float:
				re = float(re)
			elif kw == variable_name:
				re = storage[re]

			temp = temp - re

		else:
			print('ERROR: Unexpected end of statement')
			return False

	# assigns the final value to the anon var
	print(temp)
	storage['IT'] = temp
	return True

def sub_parse_mul(statement, storage):
	# get the first operand as a start
	re, kw = statement.pop(0)
	
	# typecast
	if kw == lit_int:
		re = int(re)
	elif kw == lit_float:	
		re = float(re)
	elif kw == variable_name:
		re = storage[re]

	temp = re
	
	# pop AN and operands and do operation on operands
	while (len(statement) > 0):

		# pop AN
		re, kw = statement.pop(0)
		if kw != kw_conj:
			print('ERROR: Expected {}, got {}.'.format(kw_conj, kw))
			return False

		# pop operand, typecast, and do operation
		if (len(statement) > 0):
			re, kw = statement.pop(0)
			if kw == lit_int:
				re = int(re)
			elif kw == lit_float:
				re = float(re)
			elif kw == variable_name:
				re = storage[re]

			temp = temp * re

		else:
			print('ERROR: Unexpected end of statement')
			return False

	# assigns the final value to the anon var
	print(temp)
	storage['IT'] = temp
	return True

def sub_parse_div(statement, storage):
	# get the first operand as a start
	re, kw = statement.pop(0)
	
	# typecast
	if kw == lit_int:
		re = int(re)
	elif kw == lit_float:	
		re = float(re)
	elif kw == variable_name:
		re = storage[re]

	temp = re
	
	# pop AN and operands and do operation on operands
	while (len(statement) > 0):

		# pop AN
		re, kw = statement.pop(0)
		if kw != kw_conj:
			print('ERROR: Expected {}, got {}.'.format(kw_conj, kw))
			return False

		# pop operand, typecast, and do operation
		if (len(statement) > 0):
			re, kw = statement.pop(0)
			if kw == lit_int:
				re = int(re)
			elif kw == lit_float:
				re = float(re)
			elif kw == variable_name:
				re = storage[re]

			temp = temp / re

		else:
			print('ERROR: Unexpected end of statement')
			return False

	# assigns the final value to the anon var
	print(temp)
	storage['IT'] = temp
	return True

def sub_parse_mod(statement, storage):
	# get the first operand as a start
	re, kw = statement.pop(0)
	
	# typecast
	if kw == lit_int:
		re = int(re)
	elif kw == lit_float:	
		re = float(re)
	elif kw == variable_name:
		re = storage[re]


	temp = re
	
	# pop AN and operands and do operation on operands
	while (len(statement) > 0):

		# pop AN
		re, kw = statement.pop(0)
		if kw != kw_conj:
			print('ERROR: Expected {}, got {}.'.format(kw_conj, kw))
			return False

		# pop operand, typecast, and do operation
		if (len(statement) > 0):
			re, kw = statement.pop(0)
			if kw == lit_int:
				re = int(re)
			elif kw == lit_float:
				re = float(re)
			elif kw == variable_name:
				re = storage[re]

			temp = temp % re

		else:
			print('ERROR: Unexpected end of statement')
			return False

	# assigns the final value to the anon var
	print(temp)
	storage['IT'] = temp
	return True


def sub_parse_grt(statement, storage):
	# get the first operand as a start
	re, kw = statement.pop(0)
	
	# typecast
	if kw == lit_int:
		re = int(re)
	elif kw == lit_float:	
		re = float(re)
	elif kw == variable_name:
		re = storage[re]

	temp = re
	
	# pop AN
	re, kw = statement.pop(0)
	if kw != kw_conj:
		print('ERROR: Expected {}, got {}.'.format(kw_conj, kw))
		return False

	# pop operand, typecast, and do operation
	if (len(statement) > 0):
		re, kw = statement.pop(0)
		if kw == lit_int:
			re = int(re)
		elif kw == lit_float:
			re = float(re)
		elif kw == variable_name:
			re = storage[re]

		temp = max(temp, re)

	else:
		print('ERROR: Unexpected end of statement')
		return False

	if (len(statement) > 0):
		print('ERROR: Expected end of statement')
		return False
	# assigns the final value to the anon var
	print(temp)
	storage['IT'] = temp
	return True

def sub_parse_lst(statement, storage):
	# get the first operand as a start
	re, kw = statement.pop(0)
	
	# typecast
	if kw == lit_int:
		re = int(re)
	elif kw == lit_float:	
		re = float(re)
	elif kw == variable_name:
		re = storage[re]

	temp = re
	
	# pop AN
	re, kw = statement.pop(0)
	if kw != kw_conj:
		print('ERROR: Expected {}, got {}.'.format(kw_conj, kw))
		return False

	# pop operand, typecast, and do operation
	if (len(statement) > 0):
		re, kw = statement.pop(0)
		if kw == lit_int:
			re = int(re)
		elif kw == lit_float:
			re = float(re)
		elif kw == variable_name:
			re = storage[re]

		temp = min(temp, re)

	else:
		print('ERROR: Unexpected end of statement')
		return False

	if (len(statement) > 0):
		print('ERROR: Expected end of statement')
		return False

	# assigns the final value to the anon var
	print(temp)
	storage['IT'] = temp
	return True
# almost same algo as add and other operators
# stringifies the operands and 'adds' them together
# (change this, not all can be smooshed, right?)
def sub_parse_cat(statement, storage):
	# pop first operand and assign to temp
	re, kw = statement.pop(0)
	re = re.replace('"','')						# removes the quotes
	temp = str(re)

	# pop AN and smoosh until end of statement or error
	while (len(statement) > 0):
		
		# pop AN
		re, kw = statement.pop(0)
		if kw != kw_conj:
			print('ERROR: Expected {}, got {}.'.format(kw_conj, kw))
			return False
		elif kw == kw_oper_cat_end:
			if (len(statement) > 0):
				print('ERROR: Unexpected end of statement')
				return False

		# pop operand and concat
		if (len(statement) > 0):
			re, kw = statement.pop(0)
			re = str(re)
			re = re.replace('"','')						# removes the quotes
			temp = temp + re
		else:
			print('ERROR: Unexpected end of statement')
			return False

	print(temp)
	storage['IT'] = temp
	return True

def sub_parse_print(statement, storage):
	# pop operand
	re, kw = statement.pop(0)
	if kw == lit_float: 				print(float(re)),
	elif kw == lit_int: 				print(int(re)),
	elif kw == lit_string: 				print(re.replace('"','')),
	elif kw == variable_name: 			print(storage[re])

	return True

# boolean unary
def sub_parse_not(statement, storage):
	# get the first operand as a start
	re, kw = statement.pop(0)
	
	# typecast
	if kw == lit_bool:
		re = bool(re)
	elif kw == variable_name:
		re = storage[re]
	else:
		print("ERROR Expected {}, or {}, got {}.".format(lit_bool, variable_name, kw))

	temp = False if re == True else True
	print(temp)
	storage['IT'] = temp
	return True

# boolean binary
def sub_parse_and(statement, storage):
	# get the first operand as a start
	re, kw = statement.pop(0)
	
	# typecast
	if kw == lit_bool:
		re = bool(re)
	elif kw == variable_name:
		re = storage[re]
	else:
		print("ERROR Expected {}, or {}, got {}.".format(lit_bool, variable_name, kw))

	temp = re
	
	# short circuit evaluation
	if temp == False:
		# assigns the final value to the anon var
		print(temp)
		storage['IT'] = temp
		return True

	re, kw = statement.pop(0)
	if kw != kw_conj:
		print('ERROR: Expected {}, got {}.'.format(kw_conj, kw))
		return False

	if (len(statement) > 0):
		re, kw = statement.pop(0)
		if kw == lit_bool:
			re = bool(re)
		elif kw == variable_name:
			re = storage[re]
		else:
			print("ERROR Expected {}, or {}, got {}.".format(lit_bool, variable_name, kw))

	else:
		print('ERROR: Unexpected end of statement')
		return False

	temp = temp & re
	print(temp)
	storage['IT'] = temp
	return True

def sub_parse_or(statement, storage):
	# get the first operand as a start
	re, kw = statement.pop(0)
	
	# typecast
	if kw == lit_bool:
		re = bool(re)
	elif kw == variable_name:
		re = storage[re]
	else:
		print("ERROR Expected {}, or {}, got {}.".format(lit_bool, variable_name, kw))

	temp = re
	
	# short circuit evaluation
	if temp == True:
		# assigns the final value to the anon var
		print(temp)
		storage['IT'] = temp
		return True

	re, kw = statement.pop(0)
	if kw != kw_conj:
		print('ERROR: Expected {}, got {}.'.format(kw_conj, kw))
		return False

	if (len(statement) > 0):
		re, kw = statement.pop(0)
		if kw == lit_bool:
			re = bool(re)
		elif kw == variable_name:
			re = storage[re]
		else:
			print("ERROR Expected {}, or {}, got {}.".format(lit_bool, variable_name, kw))

	else:
		print('ERROR: Unexpected end of statement')
		return False

	temp = temp | re
	print(temp)
	storage['IT'] = temp
	return True

# boolean inf arity
def sub_parse_and_inf(statement, storage):
	# get the first operand as a start
	re, kw = statement.pop(0)
	
	# typecast
	if kw == lit_bool:
		re = bool(re)
	elif kw == variable_name:
		re = storage[re]
	else:
		print("ERROR Expected {}, or {}, got {}.".format(lit_bool, variable_name, kw))

	temp = re
	
	# short circuit evaluation
	if temp == False:
		# assigns the final value to the anon var
		print(temp)
		storage['IT'] = temp
		return True
	else:
		# pop AN and operands and do operation on operands
		while (len(statement) > 0):

			# pop AN
			re, kw = statement.pop(0)
			if kw != kw_conj:
				print('ERROR: Expected {}, got {}.'.format(kw_conj, kw))
				return False

			# pop operand, typecast, and do operation
			if (len(statement) > 0):
				re, kw = statement.pop(0)
				if kw == lit_bool:
					re = bool(re)
				elif kw == variable_name:
					re = storage[re]
				else:
					print("ERROR Expected {}, or {}, got {}.".format(lit_bool, variable_name, kw))

				temp = re
				
				# return if there's a False spotted
				if temp == False:
					# assigns the final value to the anon var
					print(temp)
					storage['IT'] = temp
					return True

			else:
				print('ERROR: Unexpected end of statement')
				return False

		print(temp)
		storage['IT'] = temp
		return True

def sub_parse_or_inf(statement, storage):
	# get the first operand as a start
	re, kw = statement.pop(0)
	
	# typecast
	if kw == lit_bool:
		re = bool(re)
	elif kw == variable_name:
		re = storage[re]
	else:
		print("ERROR Expected {}, or {}, got {}.".format(lit_bool, variable_name, kw))

	temp = re
	
	# short circuit evaluation
	if temp == True:
		# assigns the final value to the anon var
		print(temp)
		storage['IT'] = temp
		return True
	else:
		# pop AN and operands and do operation on operands
		while (len(statement) > 0):

			# pop AN
			re, kw = statement.pop(0)
			if kw != kw_conj:
				print('ERROR: Expected {}, got {}.'.format(kw_conj, kw))
				return False

			# pop operand, typecast, and do operation
			if (len(statement) > 0):
				re, kw = statement.pop(0)
				if kw == lit_bool:
					re = bool(re)
				elif kw == variable_name:
					re = storage[re]
				else:
					print("ERROR Expected {}, or {}, got {}.".format(lit_bool, variable_name, kw))

				temp = re
				
				# return if there's a False spotted
				if temp == True:
					print(temp)
					# assigns the final value to the anon var
					storage['IT'] = temp
					return True

			else:
				print('ERROR: Unexpected end of statement')
				return False

		print(temp)
		storage['IT'] = temp
		return True

