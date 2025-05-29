#!/bin/bash
SCRIPTPATH="$( cd "$(dirname "$0")" ; pwd -P )"
cd "$SCRIPTPATH/Compiler/"
dotnet publish -c Release -r osx-x64 --self-contained true
dotnet publish -c Release -r win10-x64 --self-contained true
dotnet publish -c Release -r linux-x64 --self-contained true