#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["yolo.api/yolo.api.csproj", "yolo.api/"]
COPY ["yolo.service.commands/yolo.service.commands.csproj", "yolo.service.commands/"]
COPY ["yolo.common/yolo.common.csproj", "yolo.common/"]
COPY ["yolo.service/yolo.service.csproj", "yolo.service/"]
COPY ["yolo.core/yolo.core.csproj", "yolo.core/"]
RUN dotnet restore "yolo.api/yolo.api.csproj"
COPY . .
WORKDIR "/src/yolo.api"
RUN dotnet build "yolo.api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "yolo.api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "yolo.api.dll"]
