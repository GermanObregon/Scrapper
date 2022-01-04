#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["BCR.WebScrapper.DockerAPI/BCR.WebScrapper.DockerAPI.csproj" , "./"]
COPY . .
RUN dotnet restore "BCR.WebScrapper.DockerAPI/BCR.WebScrapper.DockerAPI.csproj"

RUN dotnet publish "BCR.WebScrapper.DockerAPI/BCR.WebScrapper.DockerAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "BCR.WebScrapper.DockerAPI.dll"]