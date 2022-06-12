#!/bin/bash

set -e
run_cmd="dotnet watch run --project ./Mc2.CrudTest.Presentation/Server/ --urls http://0.0.0.0:5000"

until /root/.dotnet/tools/dotnet-ef --project ./Mc2.CrudTest.Persistence/ database update --context CustomerDbContext; do
>&2 echo "SQL Server is starting up"
sleep 1
done

>&2 echo "SQL Server is up - executing command"
exec $run_cmd

