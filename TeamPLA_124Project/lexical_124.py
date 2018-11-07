import re
import sys

def lexer(lexeme_list, input_string):
    pos = 0
    tokens = []
    input_string = input_string.strip()
    while pos < len(input_string):
        match = None
        for lexeme in lexeme_list:
            pattern = lexeme[0]
            tag = lexeme[1]
            regex = re.compile(pattern)
            match = regex.match(input_string, pos)
            if match:
                text = match.group(0)
                if tag:
                    token = (text, tag)
                    tokens.append(token)
                break
        if not match:
            sys.stderr.write('Illegal character: (%s)\\n' % input_string[pos])
            sys.exit(1)
        else:
            pos = match.end(0)
        pos += 1
    return tokens


# def lexer(lexeme_list, input_string):
