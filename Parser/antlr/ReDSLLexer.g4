lexer grammar ReDSLLexer;

import Fragments;

FILE_KEYWORD: 'file';
FILE_BLOCK_START: '{';
FILE_BLOCK_END: '}';

PACKAGE_KEYWORD: 'package';

ID_STR: '"' ((~["\\\r\n\f]) | (ID_STR_ESC_SEQ))* '"';
ID_STR_ESC_SEQ: ('\\\\' | '\\"' | ('\\' .)) | UnicodeCP;

WS: [ \t\r\n\f] -> skip;

REQ_DEF: ('§_' | ReID) -> pushMode(REQ_DEF_MODE);

mode REQ_DEF_MODE;

PARAM_START: '[' -> pushMode(PARAM_MODE);
TEXT_START: '{' -> pushMode(TEXT_MODE);
REQ_DEF_WS: [ \t\r\n\f] -> skip;

mode TEXT_MODE;

TEXT_CLOSE: '}' -> mode(DEFAULT_MODE); // would need 2 x popMode
TEXT_COMMENT: '#' ~[\r\n\f]*;
TEXT_WS:
	Hws+; // we need the WS tokens to correctly reasseble the text
TEXT_LINE_BREAK:
	Linebreak; // only matches a single vertical white space as TEXT_NEXT_PARA is greedy
TEXT_NEXT_PARA: Linebreak (Hws* Linebreak)+ Hws*;
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

mode MATH_MODE;

MATH_CLOSE: '$' -> popMode;
MATH_ESC_SEQ: '\\' [\\$];
MATH_CONTENT: ~[\\$]+;