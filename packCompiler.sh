#!/bin/bash
SCRIPTPATH="$( cd "$(dirname "$0")" ; pwd -P )"
cd "$SCRIPTPATH/Compiler/"
dotnet publish -c Release -r osx-x64 --self-contained false