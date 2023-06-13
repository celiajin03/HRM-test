FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Recruiting.API/Recruiting.API.csproj", "Services/Recruiting/Recruiting.API/"]
COPY ["ApplicationCore/ApplicationCore.csproj", "Services/Recruiting/ApplicationCore/"]
COPY ["Infrastructure/Infrastructure.csproj", "Services/Recruiting/Infrastructure/"]
RUN dotnet restore "Services/Recruiting/Recruiting.API/Recruiting.API.csproj"
COPY . .
WORKDIR "/src/Services/Recruiting/Recruiting.API"
RUN dotnet build "Recruiting.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Recruiting.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV angularURL='http://localhost:4200'
ENTRYPOINT ["dotnet", "Recruiting.API.dll"]
