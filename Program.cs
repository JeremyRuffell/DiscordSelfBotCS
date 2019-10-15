using System;
using System.IO;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.CommandsNext;

namespace DiscordSelfBotCS
{
    class Program
    {
        public static DiscordClient discord;
        public static CommandsNextModule commands;

        static void Main(string[] args)
        {
            MainAsync(args).ConfigureAwait(false).GetAwaiter().GetResult();
        }

        static async Task MainAsync(string[] args)
        {
            Config cfg = new Config();

            // If config Exists.
            if (File.Exists(Path.Combine(Environment.CurrentDirectory, "config.json")))
            {
                cfg = cfg.Read();
            }
            // Else if config does not exist.
            else
            {
                cfg.Create();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Config has been created. Please update it!");
                Console.ResetColor();
                Environment.Exit(1);
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Bot is Running!");
            Console.ResetColor();

            // Discord Bot Configuration
            discord = new DiscordClient(new DiscordConfiguration
            {
                Token = cfg.Token,
                TokenType = TokenType.User,
                UseInternalLogHandler = true,
                LogLevel = LogLevel.Error
            });

            // Discord Command Configuration.
            commands = discord.UseCommandsNext(new CommandsNextConfiguration
            {
                StringPrefix = cfg.Prefix,
                SelfBot = true,
                CaseSensitive = false
            }); ;

            // Registering Commands List.
            commands.RegisterCommands<Commands>();

            // Connecting to Discord.
            await discord.ConnectAsync();

            // Infinite loop to stop applicaiton from exiting.
            await Task.Delay(-1);
        }
    }
}
