FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ["LanchesMac/LanchesMac.csproj", "LanchesMac/"]
RUN dotnet restore "LanchesMac/LanchesMac.csproj"

COPY . .
WORKDIR "/src/LanchesMac"

RUN dotnet build "LanchesMac.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LanchesMac.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LanchesMac.dll"]
