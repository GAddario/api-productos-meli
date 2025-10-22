param(
  [string]$Branch = "master",
  [int]$Retries = 20,
  [int]$DelaySec = 3
)

Write-Host "== CD manual =="
Write-Host "1) Git pull de $Branch"
git fetch origin
git checkout $Branch
git pull origin $Branch

Write-Host "2) Docker Compose up (con build)"
docker compose up -d --build
docker image prune -f

Write-Host "3) Esperando health=healthy..."
$ok = $false
for ($i=0; $i -lt $Retries; $i++) {
  $id = (docker compose ps -q api-productos)
  if (-not $id) { Start-Sleep -Seconds $DelaySec; continue }
  $status = (docker inspect --format='{{.State.Health.Status}}' $id) 2>$null
  if ($status) { Write-Host "Estado: $status" } else { Write-Host "Estado: (sin health aún)" }
  if ($status -eq 'healthy') { $ok = $true; break }
  Start-Sleep -Seconds $DelaySec
}
if (-not $ok) {
  Write-Error "❌ El contenedor no llegó a healthy a tiempo."; exit 1
}

Write-Host "4) Health HTTP"
try {
  $resp = (Invoke-WebRequest -UseBasicParsing http://localhost:5000/health -TimeoutSec 10)
  if ($resp.StatusCode -ne 200) { throw "HTTP $($resp.StatusCode)" }
  Write-Host "✅ Health OK: $($resp.Content)"
} catch {
  Write-Error "❌ Health HTTP falló: $_"; exit 1
}

Write-Host "✅ Despliegue COMPLETO."
