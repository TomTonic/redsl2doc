parser grammar ReDSLParser;

options {
	tokenVocab = ReDSLLexer;
}

parse: ( fileBlock+ | (packageDecl | requirementDecl)+)?;

fileBlock:
	FILE_KEYWORD ID_STR FILE_BLOCK_START (
		packageDecl
		| requirementDecl
		| documentDecl
	)* FILE_BLOCK_END;

packageDecl: PACKAGE_KEYWORD ID_STR;

requirementDecl: REQ_DEF parameterBlock? textBlock;

textBlock:
	TEXT_START (textBlockContentFirst textBlockContentNext*)? TEXT_NEXT_PARA?
	// simple linebreaks will be skipped by the lexer but if there are multiple linebreaks at the end of a text block, the lexer will (by design) omit a TEXT_NEXT_PARA token here
	TEXT_CLOSE;

textBlockContentFirst: TEXT_NEXT_PARA? runningText;

textBlockContentNext:
	(
		exampleDecl
		| rationaleDecl
		| referenceDecl
		| (TEXT_NEXT_PARA runningText)
	);

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

// documentDecl: DOCUMENT_KEYWORD DOC_ID_STR DOC_START_BLOCK ( docPackageRef |
// DOC_VERSION_INFO_KEYWORD )* DOC_END_BLOCK;

// docPackageRef: DOC_PACKAGE_KEYWORD DOC_ID_STR ( DOC_START_BLOCK docFileRef* DOC_END_BLOCK )?;

// docFileRef: DOC_FILE_KEYWORD DOC_ID_STR;

documentDecl:
	DOCUMENT_KEYWORD ID_STR FILE_BLOCK_START (
		docPackageRef
		| VERSION_INFO_KEYWORD
	)* FILE_BLOCK_END;

docPackageRef:
	PACKAGE_KEYWORD ID_STR (
		FILE_BLOCK_START docFileRef* FILE_BLOCK_END
	)?;

docFileRef: FILE_KEYWORD ID_STR;