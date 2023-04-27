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

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:7.0 as runtime
# WORKDIR /publish
WORKDIR /app

# COPY --from=build-env /publish .
COPY --from=build-env /app/out .
ENV ASPNETCORE_URLS=http://+:5000
EXPOSE 5000
ENTRYPOINT ["dotnet", "tasApi.dll"]