#!/bin/bash
SCRIPTPATH="$( cd "$(dirname "$0")" ; pwd -P )"
TARGETPATH="$SCRIPTPATH/Compiler/src/gen/"
SOURCEPATH="$SCRIPTPATH/Parser/antlr/"
rm -rf "$TARGETPATH/*"
cd "$SOURCEPATH"
java -Xmx500M -cp "../antlr-4.13.2-complete.jar:$CLASSPATH" org.antlr.v4.Tool -o "$TARGETPATH" -package org.ReDSL.Parser -Dlanguage=CSharp ReDSLParser.g4 ReDSLLexer.g4