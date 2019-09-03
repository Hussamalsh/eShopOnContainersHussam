FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["src/Services/Ordering/Ordering.SignalrHub/Ordering.SignalrHub.csproj", "src/Services/Ordering/Ordering.SignalrHub/"]
RUN dotnet restore "src/Services/Ordering/Ordering.SignalrHub/Ordering.SignalrHub.csproj"
COPY . .
WORKDIR "/src/src/Services/Ordering/Ordering.SignalrHub"
RUN dotnet build "Ordering.SignalrHub.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Ordering.SignalrHub.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Ordering.SignalrHub.dll"]