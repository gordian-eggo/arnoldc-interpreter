lit_int = "Literal (integer) "
lit_signed = "Literal (signed integer)" 
lit_string = "Literal (string)" 
lit_boolean = "Literal (boolean value)"
lit_bool = "Literal (boolean value)"
lit_float = "Literal (float)"
code_delim = "Code delimiter"
variable_name = "Variable indentifier"
white_space = ""
kw_line_comment = "Line comment"
kw_block_comment = "Block comment"
kw_decl_var = "Variable declaration"
kw_decl_val = "Variable assignment"
kw_anon_var = "Anonymous variable"
kw_conj = "Conjunction keyword"
kw_oper_add = "Arithmetic operation (addition)"
kw_oper_sub = "Arithmetic operation (subtraction)"
kw_oper_mul = "Arithmetic operation (multiplication)"
kw_oper_div = "Arithmetic operation (division)"
kw_oper_mod = "Arithmetic operation (modulo)"
kw_oper_grt = "Arithmetic operation (maximum)"
kw_oper_lst = "Atithmetic operation (minimum)"
kw_oper_cat_start = "String concatenation"
kw_oper_cat_end = "String concatenation delimiter"
kw_bool_and_inf = "Boolean operation for infinite arity (and)"
kw_bool_or_inf = "Boolean operation for infinite arity (or)"
kw_bool_not = "Boolean operation (not)"
kw_bool_and = "Boolean operation (and)"
kw_bool_or = "Boolean operation (or)"
kw_bool_xor = "Boolean operation (x-or)"
kw_bool_equ = "Boolean operation (equal)"
kw_bool_nor = "Boolean operation (nor)"
kw_prnt = "Output keyword"
kw_scan = "Input keyword"
kw_type_string = "Input value keyword"
kw_type_int = "Integer data type"
kw_type_float = "Float data type" 
kw_type_boolean = "Boolean data type"
kw_assign = "Assignment operation"
kw_if_start = "Flow control statement delimiter"
kw_if_true = "Flow control statement (true)"
kw_if_other = "Flow control statement (other)"
kw_if_false = "Flow control statement (else)" 
kw_if_end = "Flow control statement delimiter"
kw_match_start = "Flow control statement delimiter"
kw_match_case = "Flow control instance keyword"
kw_match_default = "Flow control default keyword"
kw_match_break = "Flow control break keyword"

lexemes = [
	(r'([+-]*[0-9]+[.][0-9]+)', 				lit_float),
	(r'([+-]*[0-9]+)',							lit_int),
	(r'HAI',									code_delim),
	(r'KTHXBYE',								code_delim),
	(r'BTW',									kw_line_comment),
	(r'OBTW', 									kw_block_comment),
	(r'TLDR',									kw_block_comment),			
	(r'I HAS A',								kw_decl_var),
	(r'ITZ',									kw_decl_val),
	(r'IT',										kw_anon_var),
	(r'WIN|FAIL',								lit_bool),
	(r'AN',										kw_conj),
	(r'SUM OF',									kw_oper_add),
	(r'DIFF OF',								kw_oper_sub),
	(r'PRODUKT OF', 							kw_oper_mul),
	(r'QUOSHUNT OF',							kw_oper_div),
	(r'MOD OF',									kw_oper_mod),
	(r'BIGGR OF',								kw_oper_grt),		
	(r'SMALLR OF',								kw_oper_lst),
	(r'SMOOSH',									kw_oper_cat_start),
	(r'MMKAY?',									kw_oper_cat_end),
	(r'ALL OF',									kw_bool_and_inf),
	(r'ANY OF',									kw_bool_or_inf),
	(r'NOT',									kw_bool_not),
	(r'BOTH OF',								kw_bool_and),
	(r'EITHER OF',								kw_bool_or),
	(r'WON OF',									kw_bool_xor),
	(r'BOTH SAEM',								kw_bool_equ),
	(r'DIFFRINT',								kw_bool_nor),
	(r'VISIBLE',								kw_prnt),
	(r'GIMMEH',									kw_scan),
	(r'YARN',									kw_type_string),
	(r'NUMBR',									kw_type_int),
	(r'NUMBAR',									kw_type_float),
	(r'TROOF',									kw_type_boolean),
	(r'R',										kw_assign),
	(r'O RLY?',									kw_if_start),
	(r'YA RLY',									kw_if_true),
	(r'MEBBE',									kw_if_other),
	(r'NO WAI',									kw_if_false),
	(r'OIC',									kw_if_end),
	(r'WTF?',									kw_match_start),
	(r'OMG',									kw_match_case),
	(r'OMGWTF',									kw_match_default),
	(r'GTFO',									kw_match_break),
	(r'"(\S*)"',								lit_string),
	(r'[A-Za-z0-9_]+', 							variable_name),
]