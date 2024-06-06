FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["MessageService/NstuOnline.MessageService.Api/NstuOnline.MessageService.Api.csproj", "MessageService/NstuOnline.MessageService.Api/"]
COPY ["Common/Common.Data/Common.Data.csproj", "Common/Common.Data/"]
COPY ["Common/Common.Models/Common.Models.csproj", "Common/Common.Models/"]
COPY ["MessageService/NstuOnline.MessageService.Application/NstuOnline.MessageService.Application.csproj", "MessageService/NstuOnline.MessageService.Application/"]
COPY ["MessageService/NstuOnline.MessageService.Domain/NstuOnline.MessageService.Domain.csproj", "MessageService/NstuOnline.MessageService.Domain/"]
COPY ["MessageService/NstuOnline.MessageService.Infrastructure/NstuOnline.MessageService.Infrastructure.csproj", "MessageService/NstuOnline.MessageService.Infrastructure/"]
COPY ["Common/Common.Data.EntityFramework/Common.Data.EntityFramework.csproj", "Common/Common.Data.EntityFramework/"]
RUN dotnet restore "MessageService/NstuOnline.MessageService.Api/NstuOnline.MessageService.Api.csproj"
COPY . .
WORKDIR "/src/MessageService/NstuOnline.MessageService.Api"
RUN dotnet build "NstuOnline.MessageService.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "NstuOnline.MessageService.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NstuOnline.MessageService.Api.dll"]
