FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["NstuOnline.BFF.Api/NstuOnline.BFF.Api.csproj", "NstuOnline.BFF.Api/"]
COPY ["NstuOnline.BFF.Application/NstuOnline.BFF.Application.csproj", "NstuOnline.BFF.Application/"]
COPY ["NstuOnline.BFF.Domain/NstuOnline.BFF.Domain.csproj", "NstuOnline.BFF.Domain/"]
COPY ["NstuOnline.BFF.Infrastructure/NstuOnline.BFF.Infrastructure.csproj", "NstuOnline.BFF.Infrastructure/"]
RUN dotnet restore "NstuOnline.BFF.Api/NstuOnline.BFF.Api.csproj"
COPY . .
WORKDIR "/src/NstuOnline.BFF.Api"
RUN dotnet build "NstuOnline.BFF.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "NstuOnline.BFF.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NstuOnline.BFF.Api.dll"]
