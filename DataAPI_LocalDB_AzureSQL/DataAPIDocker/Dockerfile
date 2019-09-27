FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
ENV ConnectionStrings__MagsConnectionMssql="Server=tcp:msdnmaglerman.database.windows.net,1433;Initial Catalog=DP0419Mags;Persist Security Info=False;User ID=ENVID;Password=ENVPW;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"
WORKDIR /app
EXPOSE 80
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