FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["EventService/NstuOnline.EventService.Api/NstuOnline.EventService.Api.csproj", "EventService/NstuOnline.EventService.Api/"]
RUN dotnet restore "EventService/NstuOnline.EventService.Api/NstuOnline.EventService.Api.csproj"
COPY . .
WORKDIR "/src/EventService/NstuOnline.EventService.Api"
RUN dotnet build "NstuOnline.EventService.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "NstuOnline.EventService.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NstuOnline.EventService.Api.dll"]
