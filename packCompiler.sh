#!/bin/bash
SCRIPTPATH="$( cd "$(dirname "$0")" ; pwd -P )"
cd "$SCRIPTPATH/Compiler/"
dotnet publish -c Release -r osx-arm64 --self-contained true /p:PublishSingleFile=true /p:SelfContained=false /p:PublishTrimmed=false
dotnet publish -c Release -r win-x64 --self-contained true /p:PublishSingleFile=true /p:SelfContained=false /p:PublishTrimmed=false
dotnet publish -c Release -r linux-x64 --self-contained true /p:PublishSingleFile=true /p:SelfContained=false /p:PublishTrimmed=false
