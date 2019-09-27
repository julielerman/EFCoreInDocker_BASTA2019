FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["DataAPIDocker/DataAPI_NoDocker.csproj", "DataAPIDocker/"]
RUN dotnet restore "DataAPIDocker/DataAPI_NoDocker.csproj"
COPY . .
WORKDIR "/src/DataAPIDocker"
RUN dotnet build "DataAPI_NoDocker.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "DataAPI_NoDocker.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "DataAPI_NoDocker.dll"]