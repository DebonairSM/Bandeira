#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

#FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
#WORKDIR /src
#COPY ["src/Bandeira.Api/Bandeira.Api.csproj", "src/Bandeira.Api/"]
#RUN dotnet restore "src/Bandeira.Api/Bandeira.Api.csproj"
#COPY . .
#WORKDIR "/src/src/Bandeira.Api"
#RUN dotnet build "Bandeira.Api.csproj" -c Release -o /app/build

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Bandeira.Api.csproj", "./"]
RUN dotnet restore "Bandeira.Api.csproj"
COPY . .
RUN dotnet build "Bandeira.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Bandeira.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Bandeira.Api.dll"]
