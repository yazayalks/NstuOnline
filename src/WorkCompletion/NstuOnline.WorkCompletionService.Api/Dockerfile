FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["WorkCompletion/NstuOnline.WorkCompletionService.Api/NstuOnline.WorkCompletionService.Api.csproj", "WorkCompletion/NstuOnline.WorkCompletionService.Api/"]
COPY ["WorkCompletion/NstuOnline.WorkCompletionService.Application/NstuOnline.WorkCompletionService.Application.csproj", "WorkCompletion/NstuOnline.WorkCompletionService.Application/"]
COPY ["Common/Common.Models/Common.Models.csproj", "Common/Common.Models/"]
COPY ["WorkCompletion/NstuOnline.WorkCompletionService.Domain/NstuOnline.WorkCompletionService.Domain.csproj", "WorkCompletion/NstuOnline.WorkCompletionService.Domain/"]
COPY ["Common/Common.Data/Common.Data.csproj", "Common/Common.Data/"]
COPY ["WorkCompletion/NstuOnline.WorkCompletionService.Infrastructure/NstuOnline.WorkCompletionService.Infrastructure.csproj", "WorkCompletion/NstuOnline.WorkCompletionService.Infrastructure/"]
RUN dotnet restore "WorkCompletion/NstuOnline.WorkCompletionService.Api/NstuOnline.WorkCompletionService.Api.csproj"
COPY . .
WORKDIR "/src/WorkCompletion/NstuOnline.WorkCompletionService.Api"
RUN dotnet build "NstuOnline.WorkCompletionService.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "NstuOnline.WorkCompletionService.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NstuOnline.WorkCompletionService.Api.dll"]
