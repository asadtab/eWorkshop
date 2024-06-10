#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 7189
ENV ASPNETCORE_URLS=http://+:7189

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["eWorkshop/eWorkshop.csproj", "eWorkshop/"]
RUN dotnet restore "eWorkshop/eWorkshop.csproj"
COPY . .
WORKDIR "/src/eWorkshop"
RUN dotnet build "eWorkshop.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "eWorkshop.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "eWorkshop.dll"]