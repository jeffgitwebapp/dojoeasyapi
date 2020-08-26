FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["DR.Api/DR.Api.csproj", "DR.Api/"]
COPY ["DR.ModeloVisaoModelo/DR.ModeloVisaoModelo.csproj", "DR.ModeloVisaoModelo/"]
COPY ["DR.Dominio.Entidades/DR.Dominio.Entidades.csproj", "DR.Dominio.Entidades/"]
COPY ["DR.Dominio.ServicosAplicacao/DR.Dominio.ServicosAplicacao.csproj", "DR.Dominio.ServicosAplicacao/"]
COPY ["DR.Dominio.Repositorios/DR.Dominio.Repositorios.csproj", "DR.Dominio.Repositorios/"]
COPY ["DR.Infra.InjecaoDependecia/DR.Infra.InjecaoDependencia.csproj", "DR.Infra.InjecaoDependecia/"]
COPY ["DR.Infra.Comum/DR.Infra.Comum.csproj", "DR.Infra.Comum/"]
COPY ["DR.Infra.Repositorios/DR.Infra.Repositorios.csproj", "DR.Infra.Repositorios/"]
COPY ["DR.Infra.BD/DR.Infra.BD.csproj", "DR.Infra.BD/"]
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