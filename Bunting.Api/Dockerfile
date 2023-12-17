#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base

RUN apt update -y && \
    apt upgrade -y && \
    apt install poppler-utils imagemagick -y && \
    mkdir -p /tmp/bunting && \
    chown app /tmp/bunting

ENV TMP_DIRECTORY="/tmp/bunting" \
    BIN_POPPLER_PDFTOPPM="/bin/pdftoppm"

USER app
WORKDIR /app

EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION="Release"
WORKDIR /src
COPY ["Bunting.Api/Bunting.Api.csproj", "Bunting.Api/"]
RUN dotnet restore "./Bunting.Api/./Bunting.Api.csproj"
COPY . .
WORKDIR "/src/Bunting.Api"
RUN dotnet build "./Bunting.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Bunting.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Bunting.Api.dll"]
