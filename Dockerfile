#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/1 - UI/GameStore.UI.WebApi/GameStore.UI.WebApi.csproj", "src/1 - UI/GameStore.UI.WebApi/"]
COPY ["src/4 - Infra/GameStore.Infra.Data/GameStore.Infra.Data.csproj", "src/4 - Infra/GameStore.Infra.Data/"]
COPY ["src/3 - Domain/GameStore.Domain/GameStore.Domain.csproj", "src/3 - Domain/GameStore.Domain/"]
COPY ["src/4 - Infra/GameStore.Infra.CrossCutting.IoC/GameStore.Infra.CrossCutting.IoC.csproj", "src/4 - Infra/GameStore.Infra.CrossCutting.IoC/"]
COPY ["src/2 - Application/GameStore.Application/GameStore.Application.csproj", "src/2 - Application/GameStore.Application/"]
RUN dotnet restore "src/1 - UI/GameStore.UI.WebApi/GameStore.UI.WebApi.csproj"
COPY . .
WORKDIR "/src/src/1 - UI/GameStore.UI.WebApi"
RUN dotnet build "GameStore.UI.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GameStore.UI.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GameStore.UI.WebApi.dll"]