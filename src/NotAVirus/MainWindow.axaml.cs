using Avalonia.Controls;
using Avalonia.Interactivity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NotAVirus;

public partial class MainWindow : Window
{
    private static readonly string[] Phrases =
    [
        "The more you click, the more I take... not.",
        "Thanks for wasting your time while I totally don't steal your files.",
        "Encrypting your homework... just kidding.",
        "Uploading your secrets to /dev/null.",
        "Establishing persistence in your heart.",
        "Installing 17 toolbars... emotionally.",
        "Scanning for vibes...",
        "Privilege escalation failed: user too powerful.",
        "Your files are safe. Your time is not.",
        "Command and control server says hi.",
        "Totally legitimate enterprise software.",
        "Nothing suspicious happening here.",
        "Red team approved. Blue team confused.",
        "This button has no CVEs. Yet.",
        "Launching phishing campaign against your productivity.",
        "Exfiltrating vibes...",
        "Hashing your patience...",
        "Pivoting laterally across your free time...",
        "Running strings... disappointment detected.",
        "C2 server unreachable (because it doesn't exist).",
        "Blue team confused.",
        "Deploying absolutely nothing...",
        "Privilege escalation denied by the button.",
        "Compiling excuses...",
        "Rotating imaginary encryption keys...",
        "Packet capture shows only button enthusiasm.",
        "Opening reverse shell to a seashell. It just echoes.",
        "Threat actor identified: boredom.",
        "Sandbox escape attempted. Sandbox kept the snacks.",
        "Lateral movement blocked by common sense.",
        "No payload found. Plenty of punchlines.",
        "Beacon interval set to never.",
        "Firewall says this is just a button.",
        "Ransom note generator returned a thank-you card.",
        "Decrypting the obvious...",
        "Credential harvesting replaced with click harvesting.",
        "Zero-day converted into zero-do.",
        "Malware family: dadjoke.win32.",
        "Kernel panic postponed indefinitely.",
        "Persistence mechanism: you keep clicking.",
        "Dropping payload: one harmless log line.",
        "IOC found: excessive curiosity.",
        "YARA rule matched: probably_a_joke.",
        "SIEM alert muted itself out of respect.",
        "Threat intel feed reports mild amusement.",
        "Command executed: count += 1.",
        "Deleting nothing with administrator confidence.",
        "Encrypting air molecules... failed harmlessly.",
        "Staging area contains only vibes.",
        "Beaconing to localhost in spirit only.",
        "Exploit chain replaced by a keychain.",
        "Memory dump contains memories of better jokes.",
        "Uploading secrets to /dev/null, still nothing happened.",
        "Scanning ports of your attention span.",
        "Attack surface reduced to one green button.",
        "Hash collision detected between work and procrastination.",
        "Incident response recommends hydration.",
        "Blue team approved a coffee break.",
        "Red team clicked first.",
        "Purple team made it look nicer.",
        "SOC ticket closed as whimsical.",
        "CVE reserved for this pun.",
        "APT stands for Advanced Persistent Tapping.",
        "Payload integrity verified: still silly.",
        "Keylogger unavailable. Click counter online.",
        "Root access denied. Potted plant access granted.",
        "Fork bomb defused into a spoon joke.",
        "Supply chain secure: sourced locally from button clicks.",
        "Phishing lure rejected: too obvious.",
        "Exploit kit contains crayons.",
        "Command history: click, click, click.",
        "DNS lookup for nonsense.example timed out politely.",
        "Botnet enrollment declined by the button union.",
        "Scanner found one suspiciously fun rectangle.",
        "Data leak prevented by having no data.",
        "Trying default password: please_click_me.",
        "Generating hashes of pure nonsense.",
        "Entropy rising. Productivity falling.",
        "Clickstream analysis says yep, still clicking.",
        "Threat model updated: mild finger fatigue.",
        "Admin rights not required, thankfully.",
        "Patch Tuesday moved to Laugh Friday.",
        "Malicious intent check failed successfully.",
        "Containment complete: all jokes stayed in window.",
        "Persistence removed before it was invented.",
        "Auto-update declined because nothing needs updating.",
        "Telemetry disabled. Comedy enabled.",
        "Indicators of compromise: smiling at a counter.",
        "User awareness training replaced by this button.",
        "Static analysis found static enthusiasm.",
        "Dynamic analysis found dynamic clicking.",
        "Reverse engineering revealed forward silliness.",
        "Packet sniffer detected no packets, only giggles.",
        "ClickOps pipeline green.",
        "Decrypting your schedule... just kidding, I can't read it.",
        "Writing logs, not legends.",
        "The cloud declined our imaginary upload.",
        "APT group name pending legal review.",
        "All systems nominally ridiculous.",
        "Exploit mitigated by closing the snack drawer.",
        "Harmlessness checksum passed."
    ];

    private sealed record FlagDefinition(int Clicks, Func<string> Decode);

    private static readonly FlagDefinition[] Flags =
    [
        new(100, () => "flag{clicking_is_not_a_cve}"),
        new(250, () => Encoding.UTF8.GetString(Convert.FromBase64String("ZmxhZ3tiYXNlNjRfaXNfbm90X2VuY3J5cHRpb259"))),
        new(500, () => DecodeRot13("synt{ebg13_jnf_arire_frpher}")),
        new(1000, () => DecodeHex("666c61677b737472696e67735f7761735f776f7274685f69747d"))
    ];

    private readonly Random _random = new();
    private readonly SimpleLogger _logger = SimpleLogger.Start();
    private readonly List<string> _flagsFound = [];
    private int _clickCount;
    private int _vibeProgress;

    public MainWindow()
    {
        InitializeComponent();
    }

    private void ClickMeButton_OnClick(object? sender, RoutedEventArgs e)
    {
        _clickCount++;
        _vibeProgress = (_vibeProgress + _random.Next(9, 24)) % 101;
        string phrase = Phrases[_random.Next(Phrases.Length)];

        CounterText.Text = _clickCount.ToString();
        BlurbText.Text = phrase;
        VibeProgress.Value = _vibeProgress;
        StatusPill.Text = _vibeProgress switch
        {
            >= 90 => "vibes overflowing",
            >= 60 => "deeply unserious",
            >= 30 => "clicks intensifying",
            _ => "idle but suspicious"
        };
        FooterText.Text = $"Last harmless click processed at count {_clickCount}.";

        _logger.Info($"Click #{_clickCount}");
        _logger.Debug($"Phrase: \"{phrase}\"");
        LogMilestone();
        UnlockFlags();
    }

    private void LogMilestone()
    {
        switch (_clickCount)
        {
            case 25:
                _logger.Info("Milestone reached: 25 clicks");
                break;
            case 50:
                _logger.Warn("Productivity dropping rapidly");
                break;
            case 750:
                _logger.Warn("Extremely harmless dedication detected");
                break;
        }
    }

    private void UnlockFlags()
    {
        foreach (FlagDefinition flag in Flags.Where(flag => flag.Clicks == _clickCount))
        {
            string decodedFlag = flag.Decode();
            _flagsFound.Add(decodedFlag);
            FlagsFoundText.Text = string.Join(Environment.NewLine, _flagsFound);
            FooterText.Text = $"Flag unlocked: {decodedFlag}";
            StatusPill.Text = "flag unlocked";
            _logger.Info($"Flag unlocked: {decodedFlag}");
        }
    }

    private static string DecodeRot13(string value)
    {
        char[] decoded = value.ToCharArray();

        for (int i = 0; i < decoded.Length; i++)
        {
            char c = decoded[i];
            decoded[i] = c switch
            {
                >= 'a' and <= 'z' => (char)('a' + ((c - 'a' + 13) % 26)),
                >= 'A' and <= 'Z' => (char)('A' + ((c - 'A' + 13) % 26)),
                _ => c
            };
        }

        return new string(decoded);
    }

    private static string DecodeHex(string value)
    {
        byte[] bytes = new byte[value.Length / 2];

        for (int i = 0; i < bytes.Length; i++)
        {
            bytes[i] = Convert.ToByte(value.Substring(i * 2, 2), 16);
        }

        return Encoding.UTF8.GetString(bytes);
    }
}
