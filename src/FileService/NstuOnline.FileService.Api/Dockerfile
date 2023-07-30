FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["FileService/NstuOnline.FileService.Api/NstuOnline.FileService.Api.csproj", "FileService/NstuOnline.FileService.Api/"]
RUN dotnet restore "FileService/NstuOnline.FileService.Api/NstuOnline.FileService.Api.csproj"
COPY . .
WORKDIR "/src/FileService/NstuOnline.FileService.Api"
RUN dotnet build "NstuOnline.FileService.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "NstuOnline.FileService.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NstuOnline.FileService.Api.dll"]
