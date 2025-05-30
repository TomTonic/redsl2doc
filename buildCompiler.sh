#!/bin/bash
SCRIPTPATH="$( cd "$(dirname "$0")" ; pwd -P )"
rm -rf "$SCRIPTPATH/Compiler/bin/*"
cd "$SCRIPTPATH/Compiler/"
dotnet restore
dotnet clean
dotnet build