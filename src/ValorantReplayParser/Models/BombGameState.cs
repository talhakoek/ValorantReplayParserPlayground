using Unreal.Core.Attributes;
using Unreal.Core.Contracts;
using Unreal.Core.Models.Enums;

namespace ValorantReplayParser.Models;

[NetFieldExportGroup("/Game/GameModes/Bomb/BombGameState.BombGameState_C", minimalParseMode: ParseMode.Normal)]
public class BombGameState : INetFieldExportGroup
{
    [NetFieldExport("RemoteRole", RepLayoutCmdType.Ignore)]
    public uint? RemoteRole { get; set; }

    [NetFieldExport("Role", RepLayoutCmdType.Ignore)]
    public uint? Role { get; set; }

    [NetFieldExport("GameModeClass", RepLayoutCmdType.Ignore)]
    public uint? GameModeClass { get; set; }

    [NetFieldExport("SpectatorClass", RepLayoutCmdType.Ignore)]
    public uint? SpectatorClass { get; set; }

    [NetFieldExport("PlayerArray", RepLayoutCmdType.Ignore)]
    public uint? PlayerArray { get; set; }

    [NetFieldExport("bReplicatedHasBegunPlay", RepLayoutCmdType.PropertyBool)]
    public bool? bReplicatedHasBegunPlay { get; set; }

    [NetFieldExport("ReplicatedWorldTimeSecondsDouble", RepLayoutCmdType.PropertyDouble)]
    public double? ReplicatedWorldTimeSecondsDouble { get; set; }

    [NetFieldExport("MatchState", RepLayoutCmdType.Ignore)]
    public uint? MatchState { get; set; }

    [NetFieldExport("bBotDesiredCharactersReady", RepLayoutCmdType.PropertyBool)]
    public bool? bBotDesiredCharactersReady { get; set; }

    [NetFieldExport("bShouldPerformanceInstabilityTrackingBeEnabled", RepLayoutCmdType.PropertyBool)]
    public bool? bShouldPerformanceInstabilityTrackingBeEnabled { get; set; }

    [NetFieldExport("TeamEconomy", RepLayoutCmdType.Ignore)]
    public uint? TeamEconomy { get; set; }

    [NetFieldExport("TeamComponents", RepLayoutCmdType.Ignore)]
    public uint? TeamComponents { get; set; }

    [NetFieldExport("Phase", RepLayoutCmdType.Ignore)]
    public uint? Phase { get; set; }

    [NetFieldExport("DisplayRemainingTime", RepLayoutCmdType.Ignore)]
    public uint? DisplayRemainingTime { get; set; }

    [NetFieldExport("StateRemainingTime", RepLayoutCmdType.Ignore)]
    public uint? StateRemainingTime { get; set; }

    [NetFieldExport("GamePhaseElapsedTime", RepLayoutCmdType.Ignore)]
    public float? GamePhaseElapsedTime { get; set; }

    [NetFieldExport("NetServerMaxTickRate", RepLayoutCmdType.Ignore)]
    public uint? NetServerMaxTickRate { get; set; }

    [NetFieldExport("MatchID", RepLayoutCmdType.Ignore)]
    public uint? MatchID { get; set; }

    [NetFieldExport("GameStateHUDConfig", RepLayoutCmdType.Ignore)]
    public uint? GameStateHUDConfig { get; set; }

    [NetFieldExport("AllowedVoteTypes", RepLayoutCmdType.Ignore)]
    public uint? AllowedVoteTypes { get; set; }

    [NetFieldExport("ModifierManager", RepLayoutCmdType.Ignore)]
    public uint? ModifierManager { get; set; }
}
