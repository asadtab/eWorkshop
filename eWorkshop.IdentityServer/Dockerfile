# Use the official .NET image
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 5443
ENV ASPNETCORE_URLS=http://+:5443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["eWorkshop.IdentityServer/eWorkshop.IdentityServer.csproj", "eWorkshop.IdentityServer/"]
RUN dotnet restore "eWorkshop.IdentityServer/eWorkshop.IdentityServer.csproj"
COPY . .
WORKDIR "/src/eWorkshop.IdentityServer"
RUN dotnet build "eWorkshop.IdentityServer.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "eWorkshop.IdentityServer.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "eWorkshop.IdentityServer.dll"]
