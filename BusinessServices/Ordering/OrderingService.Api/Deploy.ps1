Remove-Item Publish/* -recurse
dotnet publish "OrderingService.Api.csproj" -c Debug -o Publish
docker build -f Publish\Dockerfile -t orderingservice-api .
kubectl apply -f Publish\Kube.Development.yaml
