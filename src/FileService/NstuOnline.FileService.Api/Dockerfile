FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["FileService/NstuOnline.FileService.Api/NstuOnline.FileService.Api.csproj", "FileService/NstuOnline.FileService.Api/"]
COPY ["FileService/NstuOnline.FileService.Application/NstuOnline.FileService.Application.csproj", "FileService/NstuOnline.FileService.Application/"]
COPY ["FileService/NstuOnline.FileService.Domain/NstuOnline.FileService.Domain.csproj", "FileService/NstuOnline.FileService.Domain/"]
COPY ["Common/Common.Data/Common.Data.csproj", "Common/Common.Data/"]
COPY ["Common/Common.Models/Common.Models.csproj", "Common/Common.Models/"]
COPY ["FileService/NstuOnline.FileService.Infrastructure/NstuOnline.FileService.Infrastructure.csproj", "FileService/NstuOnline.FileService.Infrastructure/"]
COPY ["Common/Common.Data.EntityFramework/Common.Data.EntityFramework.csproj", "Common/Common.Data.EntityFramework/"]
RUN dotnet restore "FileService/NstuOnline.FileService.Api/NstuOnline.FileService.Api.csproj"
COPY . .
WORKDIR "/src/FileService/NstuOnline.FileService.Api"
RUN dotnet build "NstuOnline.FileService.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "NstuOnline.FileService.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NstuOnline.FileService.Api.dll"]
