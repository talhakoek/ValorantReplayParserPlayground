// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Unreal.Core.Attributes;
using Unreal.Core.Contracts;
using Unreal.Core.Models.Enums;

namespace ValorantReplayParser.Models;

[NetFieldExportGroup("/Game/GameModes/Common/BaseReplayPlayerState.BaseReplayPlayerState_C", minimalParseMode: ParseMode.Normal)]
public class BaseReplayPlayerState : INetFieldExportGroup
{
    [NetFieldExport("RemoteRole", RepLayoutCmdType.Ignore)]
    public uint? RemoteRole { get; set; }

    [NetFieldExport("Owner", RepLayoutCmdType.Ignore)]
    public uint? Owner { get; set; }

    [NetFieldExport("Role", RepLayoutCmdType.Ignore)]
    public uint? Role { get; set; }

    [NetFieldExport("bOnlySpectator", RepLayoutCmdType.PropertyBool)]
    public bool? bOnlySpectator { get; set; }
}
