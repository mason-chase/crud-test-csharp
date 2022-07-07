FROM mcr.microsoft.com/dotnet/sdk:6.0 AS base

EXPOSE 5000

COPY . /app

WORKDIR /app

RUN dotnet restore
RUN dotnet build
RUN dotnet tool install --global dotnet-ef
RUN /root/.dotnet/tools/dotnet-ef --project ./Mc2.CrudTest.Persistence/ --startup-project ./Mc2.CrudTest.Presentation/Server/ migrations add Initial --context CustomerDbContext


RUN chmod +x ./entrypoint.sh
CMD /bin/bash ./entrypoint.sh
