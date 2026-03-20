# Usa apenas a imagem de execução (Runtime), que não precisa de NuGet/SSL para rodar
FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app
EXPOSE 8080

# Copia a pasta 'publish' que você gerou manualmente na sua máquina para dentro do container
COPY ./Ordering.API/out/ .

# Comando para iniciar a aplicação
ENTRYPOINT ["dotnet", "Ordering.API.dll"]