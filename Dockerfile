FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["CodeCraftersChallenge/CodeCraftersChallenge.csproj", "CodeCraftersChallenge/"]
RUN dotnet restore "CodeCraftersChallenge/CodeCraftersChallenge.csproj"
COPY . .
WORKDIR "/src/CodeCraftersChallenge"
RUN dotnet build "CodeCraftersChallenge.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CodeCraftersChallenge.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
CMD ASPNETCORE_URLS=http://*:$PORT dotnet CodeCraftersChallenge.dll