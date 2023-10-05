#!/bin/bash

# Constrói os caminhos dinamicamente
baseDirectory=$(pwd)/Infnet_DevOps_23E3_3_Docker_Project_Test

# Executa o teste e coleta o GUID gerado
dotnet test $baseDirectory/Infnet_DevOps_23E3_3_Docker_Project_Test.csproj -p:CollectCoverage=true -p:CoverletOutputFormat=cobertura --collect:"XPlat Code Coverage;Format=opencover"

# Encontra o diretório mais recente na pasta TestResults
latestDir=$(ls -td ./Infnet_DevOps_23E3_3_Docker_Project_Test/TestResults/* | head -n 1)

# Verifica se encontrou um diretório e, em caso afirmativo, obtém o nome do diretório (GUID)
if [ -n "$latestDir" ]; then
    guid=$(basename $latestDir)

    coverageXmlPath=$baseDirectory/TestResults/$guid

    # Gera o relatório de cobertura usando o GUID capturado
    reportgenerator -reports:$baseDirectory/coverage.cobertura.xml -targetdir:$coverageXmlPath/coveragereport -reporttypes:'Html;lcov;'
else
    echo "Nenhum diretório de resultados encontrado."
fi
