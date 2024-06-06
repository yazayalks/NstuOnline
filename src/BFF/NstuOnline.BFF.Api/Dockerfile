FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["BFF/NstuOnline.BFF.Api/NstuOnline.BFF.Api.csproj", "BFF/NstuOnline.BFF.Api/"]
COPY ["BFF/NstuOnline.BFF.Application/NstuOnline.BFF.Application.csproj", "BFF/NstuOnline.BFF.Application/"]
COPY ["Common/Common.Models/Common.Models.csproj", "Common/Common.Models/"]
COPY ["MessageService/NstuOnline.MessageService.ApiClientContracts/NstuOnline.MessageService.ApiClientContracts.csproj", "MessageService/NstuOnline.MessageService.ApiClientContracts/"]
COPY ["BFF/NstuOnline.BFF.Domain/NstuOnline.BFF.Domain.csproj", "BFF/NstuOnline.BFF.Domain/"]
COPY ["Common/Common.Data/Common.Data.csproj", "Common/Common.Data/"]
COPY ["BFF/NstuOnline.BFF.Infrastructure/NstuOnline.BFF.Infrastructure.csproj", "BFF/NstuOnline.BFF.Infrastructure/"]
RUN dotnet restore "BFF/NstuOnline.BFF.Api/NstuOnline.BFF.Api.csproj"
COPY . .
WORKDIR "/src/BFF/NstuOnline.BFF.Api"
RUN dotnet build "NstuOnline.BFF.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "NstuOnline.BFF.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NstuOnline.BFF.Api.dll"]
