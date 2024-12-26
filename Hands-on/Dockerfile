# Start using the .Net 8.0 SDK container image
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Change current working directory
WORKDIR /app

# Copy existing files from host
COPY . ./

# Publish app to the "out" folder
RUN dotnet publish --configuration Release --output out

# Start container by running app DLL
ENTRYPOINT ["dotnet", "out/HelloWorld.dll"]