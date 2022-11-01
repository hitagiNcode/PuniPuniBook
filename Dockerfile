#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["PuniPuniBookWeb/PuniPuniBook.Web.csproj", "PuniPuniBookWeb/"]
COPY ["PuniPuniBook.Application/PuniPuniBook.Application.csproj", "PuniPuniBook.Application/"]
COPY ["PuniPuniBook.Data/PuniPuniBook.Data.csproj", "PuniPuniBook.Data/"]
COPY ["PuniPuniBook.Domain/PuniPuniBook.Domain.csproj", "PuniPuniBook.Domain/"]
COPY ["PuniPuniBook.Shared/PuniPuniBook.Shared.csproj", "PuniPuniBook.Shared/"]
RUN dotnet restore "PuniPuniBookWeb/PuniPuniBook.Web.csproj"
COPY . .
WORKDIR "/src/PuniPuniBookWeb"
RUN dotnet build "PuniPuniBook.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PuniPuniBook.Web.csproj" -c Release -o /app/publish 

FROM base AS final
WORKDIR /app

EXPOSE 5001
ENV ASPNETCORE_URLS=http://+:5001

COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PuniPuniBook.Web.dll"]