#!/bin/bash
SCRIPTPATH="$( cd "$(dirname "$0")" ; pwd -P )"
TESTFILE="$SCRIPTPATH/Compiler/testdata/ex2.redsl"
OUTPUTDIR="$SCRIPTPATH/Compiler/testdata/"
cd "$SCRIPTPATH/Compiler/"
dotnet run -- -i "$TESTFILE" -o "$OUTPUTDIR"