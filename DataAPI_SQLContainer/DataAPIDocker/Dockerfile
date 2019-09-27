FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

ENV ConnectionStrings__MagsConnectionMssql="Server=db;Database=DP0419Mags;User=sa;Password=ENVPW;"

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["DataAPIDocker/DataAPIDocker.csproj", "DataAPIDocker/"]
RUN dotnet restore "DataAPIDocker/DataAPIDocker.csproj"
COPY . .
WORKDIR "/src/DataAPIDocker"
RUN dotnet build "DataAPIDocker.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "DataAPIDocker.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "DataAPIDocker.dll"]