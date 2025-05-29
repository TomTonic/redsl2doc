#!/bin/bash
SCRIPTPATH="$( cd "$(dirname "$0")" ; pwd -P )"
rm -rf "$SCRIPTPATH/Compiler/bin/*"
cd "$SCRIPTPATH/Compiler/"
dotnet clean
dotnet build