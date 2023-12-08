FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["EFCore.API.BiggerSolution/EFCore.API.BiggerSolution.csproj", "EFCore.API.BiggerSolution/"]
RUN dotnet restore "EFCore.API.BiggerSolution/EFCore.API.BiggerSolution.csproj"
COPY . .
WORKDIR "/src/EFCore.API.BiggerSolution"
RUN dotnet build "EFCore.API.BiggerSolution.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "EFCore.API.BiggerSolution.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EFCore.API.BiggerSolution.dll"]
