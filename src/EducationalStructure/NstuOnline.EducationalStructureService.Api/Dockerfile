FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["EducationalStructure/NstuOnline.EducationalStructureService.Api/NstuOnline.EducationalStructureService.Api.csproj", "EducationalStructure/NstuOnline.EducationalStructureService.Api/"]
COPY ["EducationalStructure/NstuOnline.EducationalStructureService.Application/NstuOnline.EducationalStructureService.Application.csproj", "EducationalStructure/NstuOnline.EducationalStructureService.Application/"]
COPY ["Common/Common.Models/Common.Models.csproj", "Common/Common.Models/"]
COPY ["EducationalStructure/NstuOnline.EducationalStructureService.Domain/NstuOnline.EducationalStructureService.Domain.csproj", "EducationalStructure/NstuOnline.EducationalStructureService.Domain/"]
COPY ["Common/Common.Data/Common.Data.csproj", "Common/Common.Data/"]
COPY ["EducationalStructure/NstuOnline.EducationalStructureService.Infrastructure/NstuOnline.EducationalStructureService.Infrastructure.csproj", "EducationalStructure/NstuOnline.EducationalStructureService.Infrastructure/"]
COPY ["Common/Common.Data.EntityFramework/Common.Data.EntityFramework.csproj", "Common/Common.Data.EntityFramework/"]
RUN dotnet restore "EducationalStructure/NstuOnline.EducationalStructureService.Api/NstuOnline.EducationalStructureService.Api.csproj"
COPY . .
WORKDIR "/src/EducationalStructure/NstuOnline.EducationalStructureService.Api"
RUN dotnet build "NstuOnline.EducationalStructureService.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "NstuOnline.EducationalStructureService.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NstuOnline.EducationalStructureService.Api.dll"]
