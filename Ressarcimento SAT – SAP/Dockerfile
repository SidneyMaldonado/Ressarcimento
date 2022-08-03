#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["Ressarcimento SAT – SAP/Ressarcimento SAT – SAP.csproj", "Ressarcimento SAT – SAP/"]
RUN dotnet restore "Ressarcimento SAT – SAP/Ressarcimento SAT – SAP.csproj"
COPY . .
WORKDIR "/src/Ressarcimento SAT – SAP"
RUN dotnet build "Ressarcimento SAT – SAP.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Ressarcimento SAT – SAP.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Ressarcimento SAT – SAP.dll"]