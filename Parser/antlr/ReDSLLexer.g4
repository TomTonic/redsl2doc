// Copyright 2019 by Tom Gelhausen. License: GNU GENERAL PUBLIC LICENSE Version 3, 29 June 2007. See
// https://opensource.org/licenses/GPL-3.0
lexer grammar ReDSLLexer;

import Fragments;

FILE_KEYWORD: 'file';
BLOCK_START: '{';
BLOCK_END: '}';

PACKAGE_KEYWORD: 'package';

ID_STR: IdStr;
//ID_STR: '"' ((~["\\\r\n\f]) | (ID_STR_ESC_SEQ))* '"'; ID_STR_ESC_SEQ: ('\\\\' | '\\"' | ('\\' .))
// | UnicodeCP;

WS: [ \t\r\n\f] -> skip;

REQ_DEF: ('§_' | ReID) -> pushMode(REQ_DEF_MODE);

DOCUMENT_KEYWORD: 'document';

VERSION_INFO_KEYWORD: 'version-info';
GLOSSARY_KEYWORD: 'glossary';
LOCAL_KEYWORD: 'local';
GLOBAL_KEYWORD: 'global';

mode REQ_DEF_MODE;

PARAM_START: '[' -> pushMode(PARAM_MODE);
TEXT_START: '{' -> pushMode(TEXT_MODE);
DEDUCT_START: '=>' | '\u21D2';
REQ_DEF_WS: [ \t\r\n\f] -> skip;

mode TEXT_MODE;

TEXT_CLOSE: '}' -> mode(DEFAULT_MODE); // would need 2 x popMode
TEXT_COMMENT: '#' ~[\r\n\f]*;
TEXT_WS:
	Hws+; // we need the WS tokens to correctly reasseble the text
TEXT_LINE_BREAK:
	Linebreak; // only matches a single vertical white space as TEXT_NEXT_PARA is greedy
TEXT_NEXT_PARA: NextPara;
// greedy - matches every time when there are multiple succesive line breaks
TEXT_EXAMPLE_MARKER:
	Linebreak (Hws* Linebreak)+ Hws* 'EXAMPLE' Hws* ':'; // greedy!
TEXT_RATIO_MARKER:
	Linebreak (Hws* Linebreak)+ Hws* 'RATIONALE' Hws* ':'; // greedy!
TEXT_REF_MARKER:
	Linebreak (Hws* Linebreak)+ Hws* 'REFERENCE' Hws* ':'; // greedy!
TEXT_RE_ID_REF: ReID;
TEXT_URI: URI;
TEXT_TERM_REF:
	'[' TEXT_WS* LetterOrNumber (TEXT_WS | LetterOrNumber)* Hws* ']';
TEXT_START_MATH: '$' -> pushMode(MATH_MODE);
TEXT_ESC_SEQ: ('\\' ([\\§$[\]{}#] | .)) | UnicodeCP;
TEXT_CONTENT: ~[\\§$[\]{}# \t\r\n\f]+;

mode PARAM_MODE;

PARAM_CLOSE: ']' -> popMode;
PARAM_ID: UnicodeLetter (UnicodeLetter | UnicodeNumber)*;
PARAM_EQUALS: '=';
PARAM_STRING: '"' .*? '"';
PARAM_ID_LIST_START: '{';
PARAM_ID_LIST_SEP: ',';
PARAM_ID_LIST_END: '}';
//PARAM_RE_ID_REF     : ReID ;
PARAM_BOOL: 'true' | 'false';
PARAM_NUMBER: '-'? [0-9]+;
//PARAM_SEP           : ';' ;
PARAM_WS: [ \t\r\n] -> skip;

mode DEDUCT_MODE;

DEDUCT_CLOSE: ';';
DEDUCT_COMMENT: '#' ~[\r\n\f]*;
DEDUCT_RE_ID_REF: ReID;
DEDUCT_AND: '&' | '\u2227';
DEDUCT_OR: '|' | '\u2228';
DEDUCT_NOT: '!' | '\u00AC';
DEDUCT_TRUE: 'true' | '\u22A4';
DEDUCT_FALSE: 'false' | '\u22A5';
DEDUCT_LPAREN: '(';
DEDUCT_RPAREN: ')';
DEDUCT_WS: [ \t\r\n] -> skip;

mode MATH_MODE;

MATH_CLOSE: '$' -> popMode;
MATH_ESC_SEQ: '\\' [\\$];
MATH_CONTENT: ~[\\$]+;