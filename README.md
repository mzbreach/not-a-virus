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

## Icons

The app icon assets live in `src/NotAVirus/Assets`.

- Windows uses `not-a-virus.ico` for the application and window icon.
- Linux uses the Avalonia window icon at runtime unless the app is packaged with a `.desktop` file that declares a desktop environment icon.
- macOS uses the Avalonia window icon in this direct publish layout, but a proper `.app` bundle with an `.icns` file is needed for the Dock and Finder icon to look fully native.

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

The workflow in `.github/workflows/build.yml` runs on push and pull request. It publishes separate self-contained single-file workflow artifacts for:

- `win-x64`
- `linux-x64`
- `osx-x64`
- `osx-arm64`

## Releases

Successful tagged builds automatically create a GitHub Release when the pushed tag matches `v*.*.*`.

Release process:

1. Update `<Version>` in `src/NotAVirus/NotAVirus.csproj`.
2. Commit the change.
3. Create and push a matching tag, for example `v1.2.3`.
4. GitHub Actions builds all four platforms and publishes the release automatically.

The release tag must exactly match the project version as `v<Version>`. For example, `<Version>1.2.3</Version>` must be released with tag `v1.2.3`; a mismatched tag build fails before publishing.

GitHub automatically generates release notes from merged PRs and commit history.
