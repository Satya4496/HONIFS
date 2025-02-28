#!/bin/bash

if [[ ! -d certs ]]
then
    mkdir certs
    cd certs/
    if [[ ! -f localhost.pfx ]]
    then
        dotnet dev-certs https -v -ep localhost.pfx -p 2c3aec26-9e11-46cb-92b5-f320158b517e -t
    fi
    cd ../
fi

docker-compose up -d
