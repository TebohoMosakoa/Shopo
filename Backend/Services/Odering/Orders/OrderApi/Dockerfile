#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Backend/Services/Odering/Orders/OrderApi/OrderApi.csproj", "Backend/Services/Odering/Orders/OrderApi/"]
COPY ["Communication/EventBus.Messages/EventBus.Messages.csproj", "Communication/EventBus.Messages/"]
COPY ["Backend/Services/Odering/Orders/Order.Application/Order.Application.csproj", "Backend/Services/Odering/Orders/Order.Application/"]
COPY ["Backend/Services/Odering/Orders/Order.Domain/Order.Domain.csproj", "Backend/Services/Odering/Orders/Order.Domain/"]
COPY ["Backend/Services/Odering/Orders/Order.Infrastructure/Order.Infrastructure.csproj", "Backend/Services/Odering/Orders/Order.Infrastructure/"]
RUN dotnet restore "Backend/Services/Odering/Orders/OrderApi/OrderApi.csproj"
COPY . .
WORKDIR "/src/Backend/Services/Odering/Orders/OrderApi"
RUN dotnet build "OrderApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "OrderApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OrderApi.dll"]