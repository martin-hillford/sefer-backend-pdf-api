#!/bin/bash
dotnet restore
dotnet build --no-restore 
dotnet publish Sefer.Backend.Pdf.Api.csproj --output ./build