FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["PortfolioService/NstuOnline.PortfolioService.Api/NstuOnline.PortfolioService.Api.csproj", "PortfolioService/NstuOnline.PortfolioService.Api/"]
RUN dotnet restore "PortfolioService/NstuOnline.PortfolioService.Api/NstuOnline.PortfolioService.Api.csproj"
COPY . .
WORKDIR "/src/PortfolioService/NstuOnline.PortfolioService.Api"
RUN dotnet build "NstuOnline.PortfolioService.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "NstuOnline.PortfolioService.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NstuOnline.PortfolioService.Api.dll"]
