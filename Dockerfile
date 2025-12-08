FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY WellnessTracker/WellnessTracker.csproj WellnessTracker/
RUN dotnet restore WellnessTracker/WellnessTracker.csproj

COPY WellnessTracker/ WellnessTracker/

WORKDIR /src/WellnessTracker
RUN dotnet publish -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app

COPY --from=build /app/publish ./

ENV ASPNETCORE_URLS=http://+:10000
ENV ASPNETCORE_ENVIRONMENT=Production

EXPOSE 10000

ENTRYPOINT ["dotnet", "WellnessTracker.dll"]
