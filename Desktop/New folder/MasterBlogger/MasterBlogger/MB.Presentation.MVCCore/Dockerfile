#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["MB.Presentation.MVCCore/MB.Presentation.MVCCore.csproj", "MB.Presentation.MVCCore/"]
RUN dotnet restore "MB.Presentation.MVCCore/MB.Presentation.MVCCore.csproj"
COPY . .
WORKDIR "/src/MB.Presentation.MVCCore"
RUN dotnet build "MB.Presentation.MVCCore.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MB.Presentation.MVCCore.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MB.Presentation.MVCCore.dll"]