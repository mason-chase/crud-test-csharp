#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Mc2.CrudTest.Presentation/Server/Mc2.CrudTest.Presentation.Server.csproj", "Mc2.CrudTest.Presentation/Server/"]
COPY ["Mc2.CrudTest.Presentation/Shared/Mc2.CrudTest.Shared.csproj", "Mc2.CrudTest.Presentation/Shared/"]
COPY ["Mc2.CrudTest.Domain/Mc2.CrudTest.Domain.csproj", "Mc2.CrudTest.Domain/"]
COPY ["Mc2.CrudTest.Bootstrapper/Mc2.CrudTest.Bootstrapper.csproj", "Mc2.CrudTest.Bootstrapper/"]
COPY ["Mc2.CrudTest.Services/Mc2.CrudTest.Services.csproj", "Mc2.CrudTest.Services/"]
COPY ["Mc2.CrudTest.Data/Mc2.CrudTest.Data.csproj", "Mc2.CrudTest.Data/"]
COPY ["Mc2.CrudTest.Presentation/Front/Mc2.CrudTest.Presentation.Front.csproj", "Mc2.CrudTest.Presentation/Front/"]
RUN dotnet restore "Mc2.CrudTest.Presentation/Server/Mc2.CrudTest.Presentation.Server.csproj"
COPY . .
WORKDIR "/src/Mc2.CrudTest.Presentation/Server"
RUN dotnet build "Mc2.CrudTest.Presentation.Server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Mc2.CrudTest.Presentation.Server.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Mc2.CrudTest.Presentation.Server.dll"]
