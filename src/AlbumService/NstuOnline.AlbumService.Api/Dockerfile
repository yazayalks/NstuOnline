FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["AlbumService/NstuOnline.AlbumService.Api/NstuOnline.AlbumService.Api.csproj", "AlbumService/NstuOnline.AlbumService.Api/"]
COPY ["AlbumService/NstuOnline.AlbumService.Application/NstuOnline.AlbumService.Application.csproj", "AlbumService/NstuOnline.AlbumService.Application/"]
COPY ["Common/Common.Models/Common.Models.csproj", "Common/Common.Models/"]
COPY ["AlbumService/NstuOnline.AlbumService.Domain/NstuOnline.AlbumService.Domain.csproj", "AlbumService/NstuOnline.AlbumService.Domain/"]
COPY ["Common/Common.Data/Common.Data.csproj", "Common/Common.Data/"]
COPY ["AlbumService/NstuOnline.AlbumService.Infrastructure/NstuOnline.AlbumService.Infrastructure.csproj", "AlbumService/NstuOnline.AlbumService.Infrastructure/"]
RUN dotnet restore "AlbumService/NstuOnline.AlbumService.Api/NstuOnline.AlbumService.Api.csproj"
COPY . .
WORKDIR "/src/AlbumService/NstuOnline.AlbumService.Api"
RUN dotnet build "NstuOnline.AlbumService.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "NstuOnline.AlbumService.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NstuOnline.AlbumService.Api.dll"]
