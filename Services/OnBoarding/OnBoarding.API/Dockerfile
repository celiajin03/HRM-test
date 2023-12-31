﻿FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Services/OnBoarding/OnBoarding.API/OnBoarding.API.csproj", "Services/OnBoarding/OnBoarding.API/"]
COPY ["Services/OnBoarding/Infrastructure/Infrastructure.csproj", "Services/OnBoarding/Infrastructure/"]
COPY ["Services/OnBoarding/ApplicationCore/ApplicationCore.csproj", "Services/OnBoarding/ApplicationCore/"]
RUN dotnet restore "Services/OnBoarding/OnBoarding.API/OnBoarding.API.csproj"
COPY . .
WORKDIR "/src/Services/OnBoarding/OnBoarding.API"
RUN dotnet build "OnBoarding.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "OnBoarding.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OnBoarding.API.dll"]
