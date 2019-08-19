FROM mcr.microsoft.com/dotnet/core/aspnet:latest AS base  
WORKDIR app  
COPY publish .  
ENTRYPOINT ["dotnet", "HelloHiApi.dll"]  
