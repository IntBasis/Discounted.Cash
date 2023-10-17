$watcher = New-Object System.IO.FileSystemWatcher
$watcher.Path = "."
$watcher.Filter = "*.md"
$watcher.EnableRaisingEvents = $true

$onChange = Register-ObjectEvent $watcher "Changed" -Action {
    ./build.ps1
}

try {
    while ($true) {
        Wait-Event -Timeout 5
    }
} finally {
    Unregister-Event $onChange.Id
}
