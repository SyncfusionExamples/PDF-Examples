# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/runtime:9.0 AS base
RUN mkdir -p /app/input
RUN apt-get update && \
    apt-get install -y libfontconfig1 && \
    rm -rf /var/lib/apt/lists/*
COPY "jQuery_Succinctly.pdf" /app/input/
RUN chmod -R 755 /app/input/
USER $APP_UID
WORKDIR /app

#docker cp "jQuery_Succinctly.pdf"


# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["PDFCompression/PDFCompression.csproj", "PDFCompression/"]
RUN dotnet restore "./PDFCompression/PDFCompression.csproj"
COPY . .
WORKDIR "/src/PDFCompression"
RUN dotnet build "./PDFCompression.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./PDFCompression.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PDFCompression.dll"]