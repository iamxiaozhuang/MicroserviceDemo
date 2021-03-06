Remove-Item Publish/* -recurse
dotnet publish "SystemService.Api.csproj" -c Debug -o Publish
docker build -f Publish\Dockerfile -t systemservice-api .
kubectl apply -f Publish\KubeDevelopment.yaml
