FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Boombox.PetShopSolution.WebAPI/Boombox.PetShopSolution.WebAPI.csproj", "Boombox.PetShopSolution.WebAPI/"]
RUN dotnet restore "Boombox.PetShopSolution.WebAPI/Boombox.PetShopSolution.WebAPI.csproj"
COPY . .
WORKDIR "/src/Boombox.PetShopSolution.WebAPI"
RUN dotnet build "Boombox.PetShopSolution.WebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Boombox.PetShopSolution.WebAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Boombox.PetShopSolution.WebAPI.dll"]
