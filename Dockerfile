FROM mcr.microsoft.com/dotnet/sdk:6.0-bullseye-slim AS builder

COPY . ./app

WORKDIR /app

RUN dotnet publish "Jironimo.Web/Jironimo.Web.csproj" -c Release -o output
WORKDIR /app/Jironimo.Web

FROM mcr.microsoft.com/dotnet/aspnet:6.0-bullseye-slim AS runtime

COPY --from=builder /app/output /app
WORKDIR /app
EXPOSE 80
EXPOSE 443

ENTRYPOINT ["dotnet", "Jironimo.Web.dll"]