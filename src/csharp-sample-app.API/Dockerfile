FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["src/csharp-sample-app.API/csharp-sample-app.API.csproj", "src/csharp-sample-app.API/"]
RUN dotnet restore "src/csharp-sample-app.API/csharp-sample-app.API.csproj"
COPY . .
WORKDIR "/src/src/csharp-sample-app.API"
RUN dotnet build "csharp-sample-app.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "csharp-sample-app.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "csharp-sample-app.API.dll"]
