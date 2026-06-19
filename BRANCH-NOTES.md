# `revamped-channel-hooks` branch

This branch adds a ~120-line patch on top of
[`michel-giehl/ValorantReplayParserPlayground` @ master](https://github.com/michel-giehl/ValorantReplayParserPlayground/tree/master)
that exposes actor channel-open events as JSONL, so downstream tools can
pull ability spawn locations out of the parser without reverse-engineering
each ability's net-field bit layout.

**Full diff:** [master ⇢ revamped-channel-hooks](https://github.com/talhakoek/ValorantReplayParserPlayground/compare/master...revamped-channel-hooks)

## What changed

- `src/ValorantReplayParser/ValorantReplayReader.cs` — added
  `public StreamWriter? ChannelEventWriter`, a `_lastBombSec` tracker
  (peeks `BombGameState.ReplicatedWorldTimeSecondsDouble`), and channel
  open/close lifecycle hooks that emit `{ev, ch, guid, arch, cls, x, y, z, t}`
  per event.
- `src/ValorantReplayParser/Program.cs` — wires the writer to a
  `channels.jsonl` file next to the input `.vrf`.
- `src/ConsoleReader/Program.cs` — generic test-harness tweaks.

## Used by

[`ValorantWebReplayer`](https://github.com/talhakoek/ValorantWebReplayer) —
a single-command pipeline that parses a `.vrf`, derives abilities + rounds
+ player positions, and serves a browser-based scrubbable minimap viewer.
Ability classification is in
[`scripts/build-abilities.mjs`](https://github.com/talhakoek/ValorantWebReplayer/blob/main/scripts/build-abilities.mjs)
— it just pattern-matches the UE class names this branch surfaces.

## Building from this branch

```powershell
git clone -b revamped-channel-hooks https://github.com/talhakoek/ValorantReplayParserPlayground.git
cd ValorantReplayParserPlayground
dotnet publish src/ValorantReplayParser/ValorantReplayParser.csproj `
  -c Release -r win-x64 --self-contained true `
  /p:PublishSingleFile=true /p:IncludeNativeLibrariesForSelfExtract=true `
  -o ../publish
```

Output: `../publish/ValorantReplayParser.exe` (~75 MB, self-contained).

## License

MIT, same as upstream. All real work is michel-giehl's.
