FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["BlazorStandalonApp/BlazorStandalonApp.csproj", "BlazorStandalonApp/"]
RUN dotnet restore "BlazorStandalonApp/BlazorStandalonApp.csproj"
COPY . .
WORKDIR "/src/BlazorStandalonApp"
RUN dotnet build "BlazorStandalonApp.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "BlazorStandalonApp.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BlazorStandalonApp.dll"]
