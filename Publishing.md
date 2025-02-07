# Publish to nuget
Automatic publishing to nuget is triggered by new release. 
To publish new nuget version, edit project version in /AISI/AISIS100.csproj and create new release with a new version tag. 
This will trigger github actions to publish a new package to nuget.

# Publish to github pages
Any changes to the following to trigger a github action to publish github pages:
* Edit project version in /AISI/AISIS100.csproj
* Edit files related to DocFx, which includes:
  * index.md
  * AISIS100/docs/**/*.md
  * toc.yml
  * docfx.json
