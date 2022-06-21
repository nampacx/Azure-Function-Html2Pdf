#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/azure-functions/dotnet:4 AS base
RUN apt-get update && apt-get install -y --allow-unauthenticated libgdiplus
WORKDIR /home/site/wwwroot
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["HtmlToPdf/HtmlToPdf.csproj", "HtmlToPdf/"]
RUN dotnet restore "HtmlToPdf/HtmlToPdf.csproj"
COPY . .
WORKDIR "/src/HtmlToPdf"
RUN dotnet build "HtmlToPdf.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HtmlToPdf.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /home/site/wwwroot
COPY --from=publish /app/publish .
#copy /bin/Debug/net6.0/libwkhtmltox.so /bin/Debug/net6.0/bin/libwkhtmltox.so 
ENV AzureWebJobsScriptRoot=/home/site/wwwroot \
    AzureFunctionsJobHost__Logging__Console__IsEnabled=true