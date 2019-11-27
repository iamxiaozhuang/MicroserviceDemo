FROM microsoft/dotnet:2.2-aspnetcore-runtime
WORKDIR /app
COPY Publish/. .
EXPOSE 80
ENTRYPOINT ["dotnet", "OrderingService.Api.dll"]