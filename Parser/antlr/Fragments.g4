// Copyright 2019 by Tom Gelhausen. License: GNU GENERAL PUBLIC LICENSE Version 3, 29 June 2007. See
// https://opensource.org/licenses/GPL-3.0

lexer grammar Fragments;

// URI parsing based on work by Tom Everett, Copyright (c) 2016. See
// https://github.com/antlr/grammars-v4/blob/master/url/url.g4 (BSD-License)

fragment URI:
	URIScheme '://' URILogin? URIHost (':' URIPort)? (
		'/' URIPath
	)? URIQuery? URIFrag?;
fragment URIScheme: URIString; // append more schemes here...
fragment URILogin: URIString ':' URIString '@';
fragment URIPort: [0-9]+;
fragment URIHost: '/'? URIString ('.' URIString)*;
fragment URIPath: URIString ('.' URIString)*;
fragment URIQuery: '?' URISearch ('&' URISearch)*;
fragment URISearch:
	URIString ('=' (URIString | [0-9]+ | URIHex))?;
fragment URIFrag: '#' URIString;
fragment URIString: ([a-zA-Z~0-9] | URIHex) (
		[a-zA-Z0-9.-]
		| URIHex
	)+;
fragment URIStringNoDot: ([a-zA-Z~0-9] | URIHex) (
		[a-zA-Z0-9-]
		| URIHex
	)+;
fragment URIHex: ('%' [a-fA-F0-9] [a-fA-F0-9])+;

// ----------------------------------- Unicode

fragment UnicodeCP:
	'\\u' (HexDigit (HexDigit (HexDigit HexDigit?)?)?)?;
fragment HexDigit: [0-9a-fA-F];

fragment LetterOrNumber: [\p{Letter}\p{Number}];

fragment UnicodeLetter: [\p{Letter}];
fragment UnicodeNumber: [\p{Number}];
//fragment UnicodePunct : [\p{Punctuation}] ; fragment UnicodePSep : [\p{Paragraph_Separator}] ;
// fragment UnicodeLSep : [\p{Line_Separator}] ; fragment UnicodeSpace : [\p{Space_Separator}] ;

// ----------------------------------- ReDSL specific fragments

fragment ReID: '§' LetterOrNumber ([._]* LetterOrNumber)*;

fragment Linebreak: '\r'? [\n\f];
fragment Hws: [ \t];
fragment NextPara: Linebreak (Hws* Linebreak)+ Hws*;

fragment IdStr: '"' ((~["\\\r\n\f]) | (IdStrEsc))* '"';
fragment IdStrEsc: ('\\\\' | '\\"' | ('\\' .)) | UnicodeCP;