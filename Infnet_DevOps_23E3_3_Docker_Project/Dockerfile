FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Infnet_DevOps_23E3_3_Docker_Project/Infnet_DevOps_23E3_3_Docker_Project.csproj", "Infnet_DevOps_23E3_3_Docker_Project/"]
RUN dotnet restore "Infnet_DevOps_23E3_3_Docker_Project/Infnet_DevOps_23E3_3_Docker_Project.csproj"
COPY . .
WORKDIR "/src/Infnet_DevOps_23E3_3_Docker_Project"
RUN dotnet build "Infnet_DevOps_23E3_3_Docker_Project.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Infnet_DevOps_23E3_3_Docker_Project.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Infnet_DevOps_23E3_3_Docker_Project.dll"]