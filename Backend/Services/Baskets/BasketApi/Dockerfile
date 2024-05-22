#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Backend/Services/Baskets/BasketApi/BasketApi.csproj", "Backend/Services/Baskets/BasketApi/"]
COPY ["Communication/EventBus.Messages/EventBus.Messages.csproj", "Communication/EventBus.Messages/"]
RUN dotnet restore "Backend/Services/Baskets/BasketApi/BasketApi.csproj"
COPY . .
WORKDIR "/src/Backend/Services/Baskets/BasketApi"
RUN dotnet build "BasketApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BasketApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BasketApi.dll"]