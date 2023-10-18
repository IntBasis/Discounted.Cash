$destinationDir = "..\wwwroot\blog"
$templatePath = ".\templates\template.html"

Get-ChildItem -Filter *.md | ForEach-Object {
    $outputFile = Join-Path $destinationDir ($_.BaseName + ".html")

    # Special treatment for index.md to suppress title warning
    $quietArg = ""
    if ($_.Name -eq "index.md") {
        $quietArg = "--quiet"
    }

    pandoc $_.Name -o $outputFile --template=$templatePath --lua-filter=./bootstrap_filter.lua --mathjax $quietArg
}
