FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["EfCore.Testing/EfCore.Testing.csproj", "EfCore.Testing/"]
RUN dotnet restore "EfCore.Testing/EfCore.Testing.csproj"
COPY . .
WORKDIR "/src/EfCore.Testing"
RUN dotnet build "EfCore.Testing.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EfCore.Testing.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EfCore.Testing.dll"]
