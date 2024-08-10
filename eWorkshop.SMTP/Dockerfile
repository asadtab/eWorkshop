#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 7339
ENV ASPNETCORE_URLS=http://+:7339

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["eWorkshop.SMTP/eWorkshop.SMTP.csproj", "eWorkshop.SMTP/"]
RUN dotnet restore "eWorkshop.SMTP/eWorkshop.SMTP.csproj"
COPY . .
WORKDIR "/src/eWorkshop.SMTP"
RUN dotnet build "eWorkshop.SMTP.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "eWorkshop.SMTP.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "eWorkshop.SMTP.dll"]