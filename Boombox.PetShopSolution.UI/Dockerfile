FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Boombox.PetShopSolution.UI/Boombox.PetShopSolution.UI.csproj", "Boombox.PetShopSolution.UI/"]
RUN dotnet restore "Boombox.PetShopSolution.UI/Boombox.PetShopSolution.UI.csproj"
COPY . .
WORKDIR "/src/Boombox.PetShopSolution.UI"
RUN dotnet build "Boombox.PetShopSolution.UI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Boombox.PetShopSolution.UI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Boombox.PetShopSolution.UI.dll"]
