# Proof of concept for a VALORANT replay parser

Please dont use this in any real project. This is just for research

---

> ## 🔀 About this fork — [`revamped-channel-hooks`](https://github.com/talhakoek/ValorantReplayParserPlayground/tree/revamped-channel-hooks) branch
>
> This is a fork of [`michel-giehl/ValorantReplayParserPlayground`](https://github.com/michel-giehl/ValorantReplayParserPlayground)
> with a ~120-line patch on the [`revamped-channel-hooks`](https://github.com/talhakoek/ValorantReplayParserPlayground/tree/revamped-channel-hooks)
> branch that exposes actor channel-open events as JSONL — so downstream
> tools can pull ability spawn locations out of the parser without
> reverse-engineering each ability's net-field bit layout.
>
> - **Branch:** https://github.com/talhakoek/ValorantReplayParserPlayground/tree/revamped-channel-hooks
> - **Diff vs upstream:** https://github.com/talhakoek/ValorantReplayParserPlayground/compare/master...revamped-channel-hooks
> - **Used by:** [ValorantWebReplayer](https://github.com/talhakoek/ValorantWebReplayer) — drop a `.vrf` in, get a browser-based scrubbable minimap viewer out.
>
> `master` here is kept clean (identical to upstream) so the diff stays readable.

---

## Special thanks
[FortniteReplayDecompressor](github.com/Shiqan/FortniteReplayDecompressor) for their amazing work

## License
Licensed under the [MIT License](LICENSE).
