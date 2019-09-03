FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["src/Services/Ordering/Ordering.API/Ordering.API.csproj", "src/Services/Ordering/Ordering.API/"]
RUN dotnet restore "src/Services/Ordering/Ordering.API/Ordering.API.csproj"
COPY . .
WORKDIR "/src/src/Services/Ordering/Ordering.API"
RUN dotnet build "Ordering.API.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Ordering.API.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Ordering.API.dll"]