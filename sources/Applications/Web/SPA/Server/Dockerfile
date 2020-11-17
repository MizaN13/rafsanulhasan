#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["Applications/Web/SPA/RH.Apps.Web.SPA.Lite/RH.Apps.Web.SPA.Lite.csproj", "Applications/Web/SPA/RH.Apps.Web.SPA.Lite/"]
RUN dotnet restore "Applications/Web/SPA/RH.Apps.Web.SPA.Lite/RH.Apps.Web.SPA.Lite.csproj"
COPY . .
WORKDIR "/src/Applications/Web/SPA/RH.Apps.Web.SPA.Lite"
RUN dotnet build "RH.Apps.Web.SPA.Lite.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RH.Apps.Web.SPA.Lite.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RH.Apps.Web.SPA.Lite.dll"]