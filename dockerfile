# =========================================================
# Stage 1 - Runtime
# =========================================================
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base

WORKDIR /app

ENV ASPNETCORE_HTTP_PORTS=5112
EXPOSE 5112


# =========================================================
# Stage 2 - Build
# =========================================================
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build

WORKDIR /src

# Copy solution
COPY RecipeApp.slnx .

# Copy project files
COPY src/RecipeApp.Api/RecipeApp.Api.csproj src/RecipeApp.Api/
COPY src/RecipeApp.Domain/RecipeApp.Domain.csproj src/RecipeApp.Domain/
COPY src/RecipeApp.DomainService/RecipeApp.DomainService.csproj src/RecipeApp.DomainService/
COPY src/RecipeApp.Dto/RecipeApp.Dto.csproj src/RecipeApp.Dto/
COPY src/RecipeApp.Exceptions/RecipeApp.Exceptions.csproj src/RecipeApp.Exceptions/
COPY src/RecipeApp.Facade/RecipeApp.Facade.csproj src/RecipeApp.Facade/
COPY src/RecipeApp.Infrastructure/RecipeApp.Infrastructure.csproj src/RecipeApp.Infrastructure/

RUN dotnet restore RecipeApp.slnx

# Copy remaining source
COPY . .

WORKDIR /src/src/RecipeApp.Api

RUN dotnet publish \
    RecipeApp.Api.csproj \
    -c Release \
    -o /app/publish \
    /p:UseAppHost=false


# =========================================================
# Stage 3 - Final
# =========================================================
FROM base AS final

WORKDIR /app

COPY --from=build /app/publish .

ENTRYPOINT ["dotnet","RecipeApp.Api.dll"]