# NOTA: Ver documentação oficial.
#   https://learn.microsoft.com/en-us/aspnet/core/host-and-deploy/docker/building-net-docker-images?view=aspnetcore-7.0
# Get the base image
FROM mcr.microsoft.com/dotnet/sdk:7.0 as build-env
#WORKDIR /src
WORKDIR /app

# Copy the csproj and restore all of the nugets
COPY *.csproj .
RUN dotnet restore

# Copy everything else and build
COPY . .
# RUN dotnet publish -c Release -o /publish
RUN dotnet publish -c Release -o out 

# Build runtime image, alterado de dotnet/aspnet para dotnet/sdk    
# FROM mcr.microsoft.com/dotnet/aspnet:7.0 as runtime
FROM mcr.microsoft.com/dotnet/sdk:7.0 as runtime
# WORKDIR /publish
WORKDIR /app

# COPY --from=build-env /publish .
COPY --from=build-env /app/out .
ENV ASPNETCORE_URLS=http://+:5005
EXPOSE 5000
ENTRYPOINT ["dotnet", "tasApi.dll"]