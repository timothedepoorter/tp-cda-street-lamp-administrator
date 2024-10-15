FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app
COPY lampadaire.csproj .
RUN dotnet restore
COPY . .
RUN dotnet dev-certs https --trust
RUN dotnet publish -c Release -o /app lampadaire.csproj
EXPOSE 7108
ENV ASPNETCORE_URLS=https://+:7108;http://+:5207
ENV ASPNETCORE_HTTPS_PORT=7108
ENTRYPOINT ["dotnet", "lampadaire.dll"]