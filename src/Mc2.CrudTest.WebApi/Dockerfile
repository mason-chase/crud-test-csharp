#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/Mc2.CrudTest.WebApi/Mc2.CrudTest.WebApi.csproj", "src/Mc2.CrudTest.WebApi/"]
RUN dotnet restore "src/Mc2.CrudTest.WebApi/Mc2.CrudTest.WebApi.csproj"
COPY . .
WORKDIR "/src/src/Mc2.CrudTest.WebApi"
RUN dotnet build "Mc2.CrudTest.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Mc2.CrudTest.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Mc2.CrudTest.WebApi.dll"]