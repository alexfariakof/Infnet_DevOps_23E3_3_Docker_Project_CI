# TRABALHO DE INTEGRAÇÃO CONTÍNUA E DEVOPS

This project was generated with [Microsoft .NET Plataform](https://github.com/dotnet) version 6.0.

## Application in Development

This project can be access at :

   > [Health Checks UI](http://alexfariakof.com:42536/healthchecks-ui).

   > [Swagger UI](http://alexfariakof.com:42536/swagger).

   > [Endpoint API](http://alexfariakof.com:42536/WeatherForecast).

## Build

Run `dotnet build` to build the project. The build artifacts will be stored in the `./bin` directory.

## Running Development Project in Docker

Run `docker-compose -f docker-compose.dev.yml up -d` to build create docker image and initialize container.

## Running Production Project in Docker

Run `docker-compose -f docker-compose.prod.yml up` to compile and running container in docker.

## Running Unit Tests

Run `dotnet test` to execute the unit tests [XUnit](https://github.com/xunit/xunit).

## Running Unit Tests and Collect data to generate reporsts [Code Coverage](https://learn.microsoft.com/pt-br/dotnet/core/testing/unit-testing-code-coverage?tabs=windows)

   > Make sure you have installed Report Generator If not Run `dotnet tool install -g dotnet-reportgenerator-globaltool` to install.

   > Then If you using Powershell Run `.\generate_coverage_report.ps1` or If you using linux bash Run `generate_coverage_report.sh`.

After running this command, an HTML file represents the generated report is create at root Test Project `.\TestResults\{GUID}\coveragereport\index.html`.

![coveragereport](https://github.com/alexfariakof/Infnet_DevOps_23E3_3_Docker_Project_CI/assets/42475620/57e9a43d-b6aa-44d0-9798-eb67d451480c)

## Sonar Cloud [Overview Project in Sonar Cloud](https://sonarcloud.io/project/overview?id=alexfariakof_Infnet_DevOps_23E3_3_Docker_Project_CI)

SonarCloud is a cloud-based static code analysis platform that helps development teams maintain code quality and identify issues early in the software development process. It offers automated code review, continuous inspection, and code analytics. SonarCloud scans your code for bugs, vulnerabilities, and code smells, providing actionable feedback to improve code quality and security. It is an essential tool for ensuring that your software projects are maintainable, reliable, and secure. via [Sonar Cloud](https://sonarcloud.io/).

[![Health Checks](https://sonarcloud.io/api/project_badges/measure?project=alexfariakof_Infnet_DevOps_23E3_3_Docker_Project_CI&metric=reliability_rating)](http://alexfariakof.com:42537/healthchecks-ui#/healthchecks) [![Reliability Rating](https://sonarcloud.io/api/project_badges/measure?project=alexfariakof_Infnet_DevOps_23E3_3_Docker_Project_CI&metric=reliability_rating)](https://sonarcloud.io/summary/new_code?id=alexfariakof_Infnet_DevOps_23E3_3_Docker_Project_CI) [![Duplicated Lines (%)](https://sonarcloud.io/api/project_badges/measure?project=alexfariakof_Infnet_DevOps_23E3_3_Docker_Project_CI&metric=duplicated_lines_density)](https://sonarcloud.io/summary/new_code?id=alexfariakof_Infnet_DevOps_23E3_3_Docker_Project_CI) [![Vulnerabilities](https://sonarcloud.io/api/project_badges/measure?project=alexfariakof_Infnet_DevOps_23E3_3_Docker_Project_CI&metric=vulnerabilities)](https://sonarcloud.io/summary/new_code?id=alexfariakof_Infnet_DevOps_23E3_3_Docker_Project_CI) [![Bugs](https://sonarcloud.io/api/project_badges/measure?project=alexfariakof_Infnet_DevOps_23E3_3_Docker_Project_CI&metric=bugs)](https://sonarcloud.io/summary/new_code?id=alexfariakof_Infnet_DevOps_23E3_3_Docker_Project_CI) [![Security Rating](https://sonarcloud.io/api/project_badges/measure?project=alexfariakof_Infnet_DevOps_23E3_3_Docker_Project_CI&metric=security_rating)](https://sonarcloud.io/summary/new_code?id=alexfariakof_Infnet_DevOps_23E3_3_Docker_Project_CI) [![Maintainability Rating](https://sonarcloud.io/api/project_badges/measure?project=alexfariakof_Infnet_DevOps_23E3_3_Docker_Project_CI&metric=sqale_rating)](https://sonarcloud.io/summary/new_code?id=alexfariakof_Infnet_DevOps_23E3_3_Docker_Project_CI) [![Code Smells](https://sonarcloud.io/api/project_badges/measure?project=alexfariakof_Infnet_DevOps_23E3_3_Docker_Project_CI&metric=code_smells)](https://sonarcloud.io/summary/new_code?id=alexfariakof_Infnet_DevOps_23E3_3_Docker_Project_CI) [![Lines of Code](https://sonarcloud.io/api/project_badges/measure?project=alexfariakof_Infnet_DevOps_23E3_3_Docker_Project_CI&metric=ncloc)](https://sonarcloud.io/summary/new_code?id=alexfariakof_Infnet_DevOps_23E3_3_Docker_Project_CI) [![Coverage](https://sonarcloud.io/api/project_badges/measure?project=alexfariakof_Infnet_DevOps_23E3_3_Docker_Project_CI&metric=coverage)](https://sonarcloud.io/summary/new_code?id=alexfariakof_Infnet_DevOps_23E3_3_Docker_Project_CI) [![Technical Debt](https://sonarcloud.io/api/project_badges/measure?project=alexfariakof_Infnet_DevOps_23E3_3_Docker_Project_CI&metric=sqale_index)](https://sonarcloud.io/summary/new_code?id=alexfariakof_Infnet_DevOps_23E3_3_Docker_Project_CI) [![Quality Gate Status](https://sonarcloud.io/api/project_badges/measure?project=alexfariakof_Infnet_DevOps_23E3_3_Docker_Project_CI&metric=alert_status)](https://sonarcloud.io/summary/new_code?id=alexfariakof_Infnet_DevOps_23E3_3_Docker_Project_CI)

## INTRODUÇÃO

Este projeto aborda a implementação dos conceitos passados em aula para criar uma solução de projeto de software utilizando CI/CD `Integração Contínua/Entrega Contínua`  em nuvem usando docker, Github como repositório do código fonte e Git Action para criação de pipelines atutomatizadas. A solução também inclui o uso do Git Flow para manter um fluxo de cada ação do projeto, TDD implementado com XUnit para realização de testes unitários, Sonar Cloud para análise estática do código fonte no repositório sendo executado automaticamente em Jobs pré definidos no pipeline do Gitactions. A aplicação está publicada em um servidor EC2 da AWS configurado com Docker e monitorada proativamente em nuvem usando Azure Application Insights.

## APLICAÇÃO BASEADA EM CONTÊINERES DOCKER

A aplicação foi desenvolvida utilizando contêineres Docker e orquestrada com Docker Compose, permitindo a criação eficiente de ambientes de produção e desenvolvimento, facilitando a implantação e escalabilidade de forma consistente e controlada.

## IMPLEMENTAÇÃO DE INTEGRAÇÃO E ENTREGA CONTÍNUA EM NUVEM

Foram criados 3 arquivos de configuração do GitHub Actions seguindo o fluxo git flow implementando uma esteira de integração e entrega contínua:

    - Test and Analyze Code In Sonar Cloud

        > Este arquivo configura uma automação no GitHub Actions para construir, testar e analisar código em um projeto. Ele é acionado em "push" e "pull_request" para as branches "main", "develop", "hotfix/", "feature/" e "bugfix/*". A análise é realizada usando o SonarCloud.
    
    - Build Test Deploy and Publish Dev Project In AWS

        > Este arquivo configura uma automação no GitHub Actions para construir, testar, implantar e publicar um projeto de desenvolvimento na AWS. É acionado em "push" para a branch "pre-release". A implantação é feita usando Docker e instâncias EC2 da AWS.
    
    - Build Test Deploy and Publish Production Project In AWS
        
        > Este arquivo configura uma automação no GitHub Actions para construir, testar, implantar e publicar um projeto de produção na AWS. É acionado apenas quando há "push" em branch "release/*". A implantação é feita usando Docker e instâncias EC2 da AWS.

## TEST-DRIVEN DEVELOPMENT WITH SONAR CLOUD INTEGRATION

A aplicação desenvolvida adota uma abordagem de Desenvolvimento Orientado por Testes (TDD), incorporando testes unitários para garantir a qualidade do código. Além disso, a integração com o SonarCloud inclui análises abrangentes, que abrangem a cobertura de código, auxiliando na melhoria contínua da qualidade do software. [Overview Project in Sonar Cloud](https://sonarcloud.io/project/overview?id=alexfariakof_Infnet_DevOps_23E3_3_Docker_Project_CI).

## MONITORAMETO PROATIVO EM NUVEM

A aplicação está sendo monitorada de forma proativa na nuvem, através da implementação de Health Checks e da integração com o Azure Application Insights. Isso permite o acompanhamento em tempo real do desempenho, disponibilidade e integridade da aplicação, garantindo uma experiência confiável para os usuários e facilitando a detecção precoce de problemas.