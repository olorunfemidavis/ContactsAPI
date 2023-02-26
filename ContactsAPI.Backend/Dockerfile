FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ContactsAPI.Backend/ContactsAPI.Backend.csproj", "ContactsAPI.Backend/"]
RUN dotnet restore "ContactsAPI.Backend/ContactsAPI.Backend.csproj"
COPY . .
WORKDIR "/src/ContactsAPI.Backend"
RUN dotnet build "ContactsAPI.Backend.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ContactsAPI.Backend.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ContactsAPI.Backend.dll"]
