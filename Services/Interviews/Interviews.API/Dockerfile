FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Services/Interviews/Interviews.API/Interviews.API.csproj", "Services/Interviews/Interviews.API/"]
COPY ["Services/Interviews/Infrastructure/Infrastructure.csproj", "Services/Interviews/Infrastructure/"]
COPY ["Services/Interviews/ApplicationCore/ApplicationCore.csproj", "Services/Interviews/ApplicationCore/"]
RUN dotnet restore "Services/Interviews/Interviews.API/Interviews.API.csproj"
COPY . .
WORKDIR "/src/Services/Interviews/Interviews.API"
RUN dotnet build "Interviews.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Interviews.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Interviews.API.dll"]
