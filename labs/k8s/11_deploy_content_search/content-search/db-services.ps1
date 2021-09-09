function Start-Databases {

  Write-Output "`n`nStarting MongoDB...`n"
  docker compose --file ./src/mongodb/docker-compose.yml --project-name training-content-search-mongodb up --detach

  Write-Output "`n`nStarting Redis...`n"
  docker compose --file ./src/redis/docker-compose.yml --project-name training-content-search-redis up --detach

  Write-Output "`nMongoDB Info"

  Write-Output "`n  Connection String: mongodb://root:dbpass@localhost:27017/"
  Write-Output "`n  Web Admin Tool:"
  Write-Output "    Url: http://localhost:8081"
  Write-Output "    Username: root"
  Write-Output "    Password: dbpass"

  Write-Output "`nRedis Info"

  Write-Output "`n  Connection String: localhost:6379"
  Write-Output "`n  Web Admin Tool:"
  Write-Output "    Url: http://localhost:8001"
  Write-Output "    Username: N/A"
  Write-Output "    Password: N/A"

}

function Stop-Databases {

  Write-Output "`n`nStopping MongoDB...`n"
  docker compose --file ./src/mongodb/docker-compose.yml --project-name training-content-search-mongodb down

  Write-Output "`n`nStopping Redis...`n"
  docker compose --file ./src/redis/docker-compose.yml --project-name training-content-search-redis down

}

if ($args[0] -eq "start") {
  Start-Databases
  Exit
}

if ($args[0] -eq "stop") {
  Stop-Databases
  Exit
}

Write-Output "Invalid command, only 'start' and 'stop' are supported."



