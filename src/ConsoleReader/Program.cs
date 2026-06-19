using System;
using System.Diagnostics;
using System.IO;
using FortniteReplayReader;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Unreal.Core.Models.Enums;

var serviceCollection = new ServiceCollection()
    .AddLogging(loggingBuilder => loggingBuilder
        .AddConsole()
        .SetMinimumLevel(LogLevel.Warning));
var provider = serviceCollection.BuildServiceProvider();
var logger = provider.GetService<ILogger<Program>>();

var replayFilesFolder = args.Length > 0 ? args[0] : @"C:\Users\Barrage\replay-work\Demos";
var pattern = args.Length > 1 ? args[1] : "*.vrf";
var replayFiles = Directory.EnumerateFiles(replayFilesFolder, pattern).ToList();

Console.WriteLine($"Scanning {replayFilesFolder} for {pattern}");
Console.WriteLine($"Found {replayFiles.Count} file(s)");
Console.WriteLine();

var sw = new Stopwatch();
long total = 0;

var reader = new ReplayReader(logger, ParseMode.Normal);

foreach (var replayFile in replayFiles)
{
    var fi = new FileInfo(replayFile);
    Console.WriteLine($"==== {Path.GetFileName(replayFile)} ({fi.Length / 1024 / 1024} MB) ====");
    sw.Restart();
    try
    {
        var replay = reader.ReadReplay(replayFile);
        sw.Stop();
        Console.WriteLine($"  parse OK in {sw.ElapsedMilliseconds} ms");
        if (replay != null)
        {
            Console.WriteLine($"  replay.GetType()       = {replay.GetType().FullName}");
            var props = replay.GetType().GetProperties();
            foreach (var p in props)
            {
                try
                {
                    var v = p.GetValue(replay);
                    string sv;
                    if (v == null) sv = "null";
                    else if (v is System.Collections.IEnumerable e && !(v is string))
                    {
                        var n = 0;
                        foreach (var _ in e) n++;
                        sv = $"<{n} items>";
                    }
                    else sv = v.ToString() ?? "";
                    if (sv.Length > 120) sv = sv.Substring(0, 120) + "...";
                    Console.WriteLine($"  {p.Name,-30} = {sv}");
                }
                catch (Exception ex) { Console.WriteLine($"  {p.Name,-30} = <error: {ex.Message}>"); }
            }
        }
    }
    catch (Exception ex)
    {
        sw.Stop();
        Console.WriteLine($"  FAILED in {sw.ElapsedMilliseconds} ms");
        Console.WriteLine($"  {ex.GetType().Name}: {ex.Message}");
        Console.WriteLine(ex.StackTrace?.Split('\n').Take(8).Aggregate("", (a, b) => a + "    " + b + "\n"));
    }
    total += sw.ElapsedMilliseconds;
    Console.WriteLine();
}

Console.WriteLine($"total: {total} ms ({total / 1000.0:F1} s)");
