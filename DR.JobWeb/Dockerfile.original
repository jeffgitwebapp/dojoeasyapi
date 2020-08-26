FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["DR.JobWeb/DR.JobWeb.csproj", "DR.JobWeb/"]
RUN dotnet restore "DR.JobWeb/DR.JobWeb.csproj"
COPY . .
WORKDIR "/src/DR.JobWeb"
RUN dotnet build "DR.JobWeb.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "DR.JobWeb.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "DR.JobWeb.dll"]