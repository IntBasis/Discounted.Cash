$destinationDir = "..\wwwroot\blog"
$templatePath = ".\templates\template.html"

Get-ChildItem -Filter *.md | ForEach-Object {
    $outputFile = Join-Path $destinationDir ($_.BaseName + ".html")
    pandoc $_.Name -o $outputFile --template=$templatePath
}
