// Copyright 2019 by Tom Gelhausen. License: GNU GENERAL PUBLIC LICENSE Version 3, 29 June 2007. See
// https://opensource.org/licenses/GPL-3.0
parser grammar ReDSLParser;

options {
	tokenVocab = ReDSLLexer;
}

parse: ( fileDecl+ | (packageDecl | requirementDecl)+)?;

fileDecl:
	FILE_KEYWORD ID_STR BLOCK_START (
		packageDecl
		| requirementDecl
		| requirementDeduction
		| documentDecl
	)* BLOCK_END;

packageDecl: PACKAGE_KEYWORD ID_STR;

requirementDecl:
	REQ_DEF parameterBlock? TEXT_START TEXT_NEXT_PARA? (
		runningText (
			(
				exampleDecl
				| rationaleDecl
				| referenceDecl
				| (TEXT_NEXT_PARA runningText)
			)*
		)
	)? TEXT_NEXT_PARA? TEXT_CLOSE;

requirementDeduction:
	REQ_DEF DEDUCT_START logicalExpression DEDUCT_CLOSE;

logicalExpression:
	logicalAtom
	| logicalUnaryExpression
	| logicalBinaryExpression;

logicalAtom: DEDUCT_RE_ID_REF | DEDUCT_TRUE | DEDUCT_FALSE;

logicalUnaryExpression:
	(DEDUCT_NOT logicalExpression)
	| (DEDUCT_LPAREN logicalExpression DEDUCT_RPAREN);

logicalBinaryExpression:
	DEDUCT_RE_ID_REF (DEDUCT_AND | DEDUCT_OR) logicalExpression;

exampleDecl: TEXT_EXAMPLE_MARKER runningText;

rationaleDecl: TEXT_RATIO_MARKER runningText;

referenceDecl: TEXT_REF_MARKER runningText;

runningText:
	(
		TEXT_CONTENT
		| TEXT_ESC_SEQ
		| TEXT_RE_ID_REF
		| TEXT_TERM_REF
		| TEXT_COMMENT
		| TEXT_URI
		| TEXT_WS
		| TEXT_LINE_BREAK
		| mathModeExpression
	)+;

parameterBlock: PARAM_START paramDecl* PARAM_CLOSE;

paramDecl:
	(
		stringParamDecl
		| idParamDecl
		| numericParamDecl
		| boolParamDecl
		| idListParamDecl
	);

stringParamDecl: PARAM_ID PARAM_EQUALS PARAM_STRING;

idParamDecl: PARAM_ID PARAM_EQUALS PARAM_ID;

//reIdParamDecl
// : PARAM_ID PARAM_EQUALS PARAM_RE_ID_REF ;

numericParamDecl: PARAM_ID PARAM_EQUALS PARAM_NUMBER;

boolParamDecl: PARAM_ID (PARAM_EQUALS PARAM_BOOL)?;

idListParamDecl:
	PARAM_ID PARAM_EQUALS (
		PARAM_ID_LIST_START PARAM_ID (PARAM_ID_LIST_SEP PARAM_ID)* PARAM_ID_LIST_END
	);

mathModeExpression:
	TEXT_START_MATH (MATH_ESC_SEQ | MATH_CONTENT)* MATH_CLOSE;

documentDecl:
	DOCUMENT_KEYWORD ID_STR BLOCK_START (
		packageRef
		| VERSION_INFO_KEYWORD
		| (GLOSSARY_KEYWORD (LOCAL_KEYWORD | GLOBAL_KEYWORD)?)
	)* BLOCK_END;

packageRef:
	PACKAGE_KEYWORD ID_STR (BLOCK_START fileRef* BLOCK_END)?;

fileRef: FILE_KEYWORD ID_STR;