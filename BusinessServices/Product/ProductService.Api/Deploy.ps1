Remove-Item Publish/* -recurse
dotnet publish "ProductService.Api.csproj" -c Debug -o Publish
docker build -f Publish\Dockerfile -t productservice-api .
kubectl apply -f Publish\KubeDevelopment.yaml
