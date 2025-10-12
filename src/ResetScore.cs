using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SwiftlyS2.Shared;
using SwiftlyS2.Shared.Plugins;

namespace ResetScore;

[PluginMetadata(
    Id = "ResetScore",
    Version = "1.0.0",
    Name = "ResetScore",
    Author = "blu",
    Description = "Reset your stats to 0."
)]
public partial class ResetScore : BasePlugin
{
    private ServiceProvider? _provider;
    public ResetScore(ISwiftlyCore core)
        : base(core) { }

    public override void Load(bool hotReload)
    {
        Core.Configuration.InitializeJsonWithModel<ConfigModel>("config.jsonc", "Main")
            .Configure(builder =>
            {
                builder.AddJsonFile("config.jsonc", false, true);
            });

        ServiceCollection services = new();
        services.AddSwiftly(Core).AddSingleton<CommandsManager>();

        services.AddOptionsWithValidateOnStart<ConfigModel>().BindConfiguration("Main");

        _provider = services.BuildServiceProvider();

        var commands = _provider.GetRequiredService<CommandsManager>();
        commands.RegisterCommands();
    }

    public override void Unload() { }
}
