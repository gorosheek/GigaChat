FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-stage
WORKDIR /WebApi
COPY . .
RUN dotnet publish GigaChat.Server -c Release -r linux-x64 -o /WebApiRelease

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime-stage
WORKDIR /WebApi
COPY --from=build-stage /WebApiRelease /WebApi
CMD ["dotnet", "GigaChat.Server.dll"]