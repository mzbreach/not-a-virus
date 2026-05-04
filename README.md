# not-a-virus.exe

`not-a-virus.exe` is a harmless cross-platform Avalonia UI joke clicker. It shows a fake playful "malware" dashboard, counts button clicks, rotates silly fake hacking blurbs, advances a fake "Exfiltrating vibes" progress bar, and unlocks harmless milestone flags.

It does not access files, network, credentials, registry, startup folders, environment secrets, or system settings. There is no telemetry, persistence, auto-update, obfuscation, installer logic, hidden behavior, or background task. The project also disables Avalonia build statistics, and CI opts out of .NET/Avalonia build telemetry.

This application only writes logs to `./logs` and does not access any other files or system resources.

## Requirements

- .NET 8 SDK or a newer SDK that can target `net8.0`

## Run

```bash
dotnet run --project src/NotAVirus
```

## Build

```bash
dotnet build
```

## Publish Self-Contained Builds

The project is configured for self-contained single-file publishing with native libraries bundled for self-extraction where needed.

Windows x64:

```bash
dotnet publish src/NotAVirus -c Release -r win-x64 --self-contained true
```

Linux x64:

```bash
dotnet publish src/NotAVirus -c Release -r linux-x64 --self-contained true
```

macOS x64:

```bash
dotnet publish src/NotAVirus -c Release -r osx-x64 --self-contained true
```

macOS ARM64 for Apple Silicon:

```bash
dotnet publish src/NotAVirus -c Release -r osx-arm64 --self-contained true
```

Publish outputs are written by GitHub Actions to:

- `artifacts/win-x64/`
- `artifacts/linux-x64/`
- `artifacts/osx-x64/`
- `artifacts/osx-arm64/`

## Logs

On start, the app uses `AppContext.BaseDirectory` to create a `logs` folder next to the launched executable. Each run creates a timestamped log file:

```text
logs/not-a-virus_YYYY-MM-DD_HH-mm-ss.log
```

Example log file:

```text
[2026-05-04 14:03:21] [INFO] Application started
[2026-05-04 14:03:25] [INFO] Click #1
[2026-05-04 14:03:25] [DEBUG] Phrase: "Exfiltrating vibes..."
[2026-05-04 14:04:10] [WARN] Productivity dropping rapidly
[2026-05-04 14:05:00] [INFO] Flag unlocked: flag{clicking_is_not_a_cve}
```

The logger is intentionally small and synchronous. It writes only to `./logs`.

## GitHub Actions

The workflow in `.github/workflows/build.yml` runs on push and pull request. It publishes separate self-contained single-file artifacts for:

- `win-x64`
- `linux-x64`
- `osx-x64`
- `osx-arm64`
