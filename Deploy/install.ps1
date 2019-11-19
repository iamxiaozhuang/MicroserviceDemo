docker-compose -f docker-compose.yml build

echo "Creating deployments"
kubectl create -f (Get-ChildItem -Recurse -File -Filter "*deployment*.yaml" |
Group-Object -Property Directory |
ForEach-Object {
    @(
        $_.Group |
        Resolve-Path -Relative |   # make relative path
        ForEach-Object Substring 2 # cut '.\' part
    )-join','
})