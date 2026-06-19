using Microsoft.Extensions.Logging;
using Unreal.Core.Models.Enums;

namespace ValorantReplayParser;

public class Program
{
    public static int Main(string[] args)
    {
        var path = args.Length > 0 ? args[0] : @"C:\Users\Barrage\replay-work\Demos\3e32371f-5a44-4052-b221-8cb9fd38115f.vrf";
        var verbose = args.Length > 1 && args[1] == "--verbose";
        var full = args.Length > 2 && args[2] == "--full";
        var channelOutPath = @"C:\Users\Barrage\replay-work\channels.jsonl";

        try
        {
            using var loggerFactory = LoggerFactory.Create(b => { b.AddConsole(o => { o.FormatterName = "minimal"; }); b.SetMinimumLevel(verbose ? LogLevel.Information : LogLevel.Error); });
            var logger = loggerFactory.CreateLogger<ValorantReplayReader>();
            var reader = new ValorantReplayReader(verbose ? logger : null, full ? ParseMode.Full : ParseMode.Normal);

            using var channelWriter = new StreamWriter(channelOutPath) { AutoFlush = true };
            reader.ChannelEventWriter = channelWriter;

            Console.Error.WriteLine($"Path:      {path}");
            Console.Error.WriteLine($"ParseMode: {(full ? "Full" : "Normal")}");
            Console.Error.WriteLine($"Channels:  {channelOutPath}");

            var sw = System.Diagnostics.Stopwatch.StartNew();
            var replay = reader.ReadReplay(path);
            sw.Stop();
            Console.Error.WriteLine($"Parse:     {sw.ElapsedMilliseconds} ms");
            channelWriter.Flush();
            var fi = new FileInfo(channelOutPath);
            Console.Error.WriteLine($"Channels written: {fi.Length} bytes");
            return 0;
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"FAIL: {ex.GetType().Name}: {ex.Message}\n{ex.StackTrace}");
            return 1;
        }
    }
}
