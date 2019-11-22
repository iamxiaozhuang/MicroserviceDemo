Remove-Item Publish/* -recurse
dotnet publish "AuthWeb.csproj" -c Debug -o Publish
docker build -f Publish\Dockerfile -t auth-web .
kubectl apply -f Publish\Kubefile.yaml
