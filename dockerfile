FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
 WORKDIR /app
 EXPOSE 80
 FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
 WORKDIR /src
 COPY ["FitNote-API.csproj", ""]
 RUN dotnet restore "./FitNote-API.csproj"
 COPY . .
 WORKDIR "/src/."
 RUN dotnet build "FitNote-API.csproj" -c Release -o /app/build
 FROM build AS publish
 RUN dotnet publish "FitNote-API.csproj" -c Release -o /app/publish
 FROM base AS final
 WORKDIR /app
 COPY --from=publish /app/publish .
 ENTRYPOINT ["dotnet", "FitNote-API.dll"]