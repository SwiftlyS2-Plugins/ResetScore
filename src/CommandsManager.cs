using System.Data;
using System.Reflection;
using System.Security.Permissions;
using Dapper;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SwiftlyS2.Shared;
using SwiftlyS2.Shared.Commands;
using SwiftlyS2.Shared.Players;
using SwiftlyS2.Shared.ProtobufDefinitions;
using SwiftlyS2.Shared.SchemaDefinitions;
using SwiftlyS2.Shared.Services;

namespace ResetScore;

public class CommandsManager
{
    private readonly ISwiftlyCore _core;
    private readonly ConfigModel _config;

    public CommandsManager(ISwiftlyCore core, IOptions<ConfigModel> config)
    {
        _core = core;
        _config = config.Value;
    }

    public void RegisterCommands()
    {
        foreach (var command in _config.Commands)
        {
            _core.Command.RegisterCommand(
                command,
                async (ICommandContext ctx) =>
                {
                    IPlayer? player = ctx.Sender;
                    if (player == null)
                        return;

                    var matchstats = player.Controller.ActionTrackingServices.MatchStats;

                    if (
                        matchstats.Kills == 0
                        && matchstats.Deaths == 0
                        && matchstats.Assists == 0 & matchstats.Damage == 0
                    )
                    {
                        player.SendMessage(
                            MessageType.Chat,
                            _config.Prefix + _core.Localizer["already_resetted"]
                        );
                        return;
                    }

                    matchstats.Kills = 0;
                    matchstats.Deaths = 0;
                    matchstats.Assists = 0;
                    matchstats.Damage = 0;

                    player.Controller.ActionTrackingServicesUpdated();

                    player.SendMessage(
                        MessageType.Chat,
                        _config.Prefix + _core.Localizer["resetscore"]
                    );

                    player.SendMessage(MessageType.Chat, _config.Prefix);
                    Console.WriteLine(_config.Prefix);
                }
            );
        }
    }
}
