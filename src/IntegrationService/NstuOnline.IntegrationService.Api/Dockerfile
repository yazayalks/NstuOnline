FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["IntegrationService/NstuOnline.IntegrationService.Api/NstuOnline.IntegrationService.Api.csproj", "IntegrationService/NstuOnline.IntegrationService.Api/"]
RUN dotnet restore "IntegrationService/NstuOnline.IntegrationService.Api/NstuOnline.IntegrationService.Api.csproj"
COPY . .
WORKDIR "/src/IntegrationService/NstuOnline.IntegrationService.Api"
RUN dotnet build "NstuOnline.IntegrationService.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "NstuOnline.IntegrationService.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NstuOnline.IntegrationService.Api.dll"]
