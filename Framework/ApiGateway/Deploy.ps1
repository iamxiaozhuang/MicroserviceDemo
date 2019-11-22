Remove-Item Publish/* -recurse
dotnet publish "ApiGateway.csproj" -c Debug -o Publish
docker build -f Publish\Dockerfile -t api-gateway .
kubectl apply -f Publish\Kubefile.yaml
