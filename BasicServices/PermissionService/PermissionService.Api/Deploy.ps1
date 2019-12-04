Remove-Item Publish/* -recurse
dotnet publish "PermissionService.Api.csproj" -c Debug -o Publish
docker build -f Publish\Dockerfile -t permissionservice-api .
kubectl apply -f Publish\KubeDevelopment.yaml
