FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 5105

ENV ASPNETCORE_URLS=http://+:5105

USER app
FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG configuration=Release
WORKDIR /src
COPY . .
WORKDIR /src/ACME.Api.Reviews
RUN dotnet restore "ACME.Api.Reviews.csproj"
RUN dotnet build "ACME.Api.Reviews.csproj" -c $configuration -o /app/build

FROM build AS publish
ARG configuration=Release
RUN dotnet publish "ACME.Api.Reviews.csproj" -c $configuration -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ACME.Api.Reviews.dll"]
