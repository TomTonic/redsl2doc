#!/bin/bash
java -Xmx500M -cp "../antlr-4.7.2-complete.jar:$CLASSPATH" org.antlr.v4.Tool -o ../../Compiler/src/gen/ -package org.ReDSL.Parser -Dlanguage=CSharp ReDSLParser.g4 ReDSLLexer.g4