dotnet publish Flow.Launcher.Plugin.FlowLauncherPluginEmailTo -c Release -r win-x64
Compress-Archive -LiteralPath Flow.Launcher.Plugin.FlowLauncherPluginEmailTo/bin/Release/win-x64/publish -DestinationPath Flow.Launcher.Plugin.FlowLauncherPluginEmailTo/bin/FlowLauncherPluginEmailTo.zip -Force