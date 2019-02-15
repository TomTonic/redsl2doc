#!/bin/bash
java -Xmx500M -cp "../antlr-4.7.2-complete.jar:$CLASSPATH" org.antlr.v4.Tool -visitor -o ../../gen/cs/Parser/ -package org.ReDSL.Parser -Dlanguage=CSharp *.g4
