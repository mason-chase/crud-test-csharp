FROM mcr.microsoft.com/dotnet/sdk:5.0 AS base

EXPOSE 5000

COPY . /app

WORKDIR /app

RUN dotnet restore
RUN dotnet build
RUN dotnet tool install --global dotnet-ef --version 5.0.17
RUN /root/.dotnet/tools/dotnet-ef --project ./Mc2.CrudTest.Persistence/ migrations add Initial --context CustomerDbContext


RUN chmod +x ./entrypoint.sh
CMD /bin/bash ./entrypoint.sh
