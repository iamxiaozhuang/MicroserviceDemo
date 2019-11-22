Remove-Item Publish/* -recurse
dotnet publish "HostWeb.csproj" -c Debug -o Publish
docker build -f Publish\Dockerfile -t host-web .
kubectl apply -f Publish\Kubefile.yaml
