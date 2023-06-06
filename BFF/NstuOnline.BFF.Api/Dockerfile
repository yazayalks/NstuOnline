FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["NstuOnline.BFF.Api/NstuOnline.BFF.Api.csproj", "NstuOnline.BFF.Api/"]
RUN dotnet restore "NstuOnline.BFF.Api/NstuOnline.BFF.Api.csproj"
COPY . .
WORKDIR "/src/NstuOnline.BFF.Api"
RUN dotnet build "NstuOnline.BFF.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "NstuOnline.BFF.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NstuOnline.BFF.Api.dll"]
