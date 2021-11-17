#!/usr/bin/env bash

set -e

export dir=$(cd -P -- "$(dirname -- "$0")" && pwd -P)
export API_KEY=$API_KEY
export VERSION=$VERSION

nugetpush() {
  dotnet nuget push "$dir/../$1/bin/Release/$1.$VERSION.nupkg" --api-key "$API_KEY" --source https://api.nuget.org/v3/index.json
}

dotnet build "$dir/../NApi.sln" -c Release

nugetpush NApi
nugetpush NApi.Sdk.AOT
nugetpush NApi.Sdk.CLR
nugetpush NApi.SourceGenerators
nugetpush NApi.Template
