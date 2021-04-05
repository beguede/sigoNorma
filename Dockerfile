FROM registryll.azurecr.io/ti/container/images/netcore3/x-runweb:stable AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM registryll.azurecr.io/ti/container/images/netcore3/x-build:stable AS build
WORKDIR /src
COPY src .
WORKDIR /src/NormasService.Api
RUN dotnet publish NormasService.Api.csproj -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "NormasService.Api.dll"]