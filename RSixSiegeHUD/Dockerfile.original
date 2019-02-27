FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["RSixSiegeHUD/RSixSiegeHUD.csproj", "RSixSiegeHUD/"]
RUN dotnet restore "RSixSiegeHUD/RSixSiegeHUD.csproj"
COPY . .
WORKDIR "/src/RSixSiegeHUD"
RUN dotnet build "RSixSiegeHUD.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "RSixSiegeHUD.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "RSixSiegeHUD.dll"]