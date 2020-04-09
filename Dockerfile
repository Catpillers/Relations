#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM  mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["Relation.API/Relations.API.csproj", "Relation.API/"]
COPY ["RelationInfrastructure/Relations.Dal.csproj", "RelationInfrastructure/"]
COPY ["RelationsBll/Relations.Bll.csproj", "RelationsBll/"]
RUN dotnet restore "Relation.API/Relations.API.csproj"
COPY . .
WORKDIR "/src/Relation.API"
RUN dotnet build "Relations.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Relations.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Relations.API.dll"]