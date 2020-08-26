FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["DR.Api/DR.Api.csproj", "DR.Api/"]
RUN dotnet restore "DR.Api/DR.Api.csproj"
COPY . .
WORKDIR "/src/DR.Api"
RUN dotnet build "DR.Api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "DR.Api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "DR.Api.dll"]