FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["EFCore.Migrations/EFCore.Migrations.csproj", "EFCore.Migrations/"]
RUN dotnet restore "EFCore.Migrations/EFCore.Migrations.csproj"
COPY . .
WORKDIR "/src/EFCore.Migrations"
RUN dotnet build "EFCore.Migrations.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EFCore.Migrations.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EFCore.Migrations.dll"]
