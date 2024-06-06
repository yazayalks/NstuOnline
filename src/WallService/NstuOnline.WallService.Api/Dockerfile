FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["WallService/NstuOnline.WallService.Api/NstuOnline.WallService.Api.csproj", "WallService/NstuOnline.WallService.Api/"]
COPY ["WallService/NstuOnline.WallService.Infrastructure/NstuOnline.WallService.Infrastructure.csproj", "WallService/NstuOnline.WallService.Infrastructure/"]
COPY ["WallService/NstuOnline.WallService.Domain/NstuOnline.WallService.Domain.csproj", "WallService/NstuOnline.WallService.Domain/"]
COPY ["Common/Common.Data/Common.Data.csproj", "Common/Common.Data/"]
COPY ["Common/Common.Models/Common.Models.csproj", "Common/Common.Models/"]
COPY ["WallService/NstuOnline.WallService.Application/NstuOnline.WallService.Application.csproj", "WallService/NstuOnline.WallService.Application/"]
RUN dotnet restore "WallService/NstuOnline.WallService.Api/NstuOnline.WallService.Api.csproj"
COPY . .
WORKDIR "/src/WallService/NstuOnline.WallService.Api"
RUN dotnet build "NstuOnline.WallService.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "NstuOnline.WallService.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NstuOnline.WallService.Api.dll"]
