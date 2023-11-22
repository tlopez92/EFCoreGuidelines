FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["EfCore.Testing.SimpleApi/EfCore.Testing.SimpleApi.csproj", "EfCore.Testing.SimpleApi/"]
RUN dotnet restore "EfCore.Testing.SimpleApi/EfCore.Testing.SimpleApi.csproj"
COPY . .
WORKDIR "/src/EfCore.Testing.SimpleApi"
RUN dotnet build "EfCore.Testing.SimpleApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EfCore.Testing.SimpleApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EfCore.Testing.SimpleApi.dll"]
