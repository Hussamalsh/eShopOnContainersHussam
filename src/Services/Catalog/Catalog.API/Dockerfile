FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["src/Services/Catalog/Catalog.API/Catalog.API.csproj", "src/Services/Catalog/Catalog.API/"]
RUN dotnet restore "src/Services/Catalog/Catalog.API/Catalog.API.csproj"
COPY . .
WORKDIR "/src/src/Services/Catalog/Catalog.API"
RUN dotnet build "Catalog.API.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Catalog.API.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Catalog.API.dll"]