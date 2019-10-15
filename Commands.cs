using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using DSharpPlus.Interactivity;

namespace DiscordSelfBotCS
{
    public class Commands
    {
        [Command("stream")]
        public async Task Ping(CommandContext ctx, string streamname)
        {

            DiscordGame Game = new DiscordGame();

            if (streamname == "clear")
            {
                await Program.discord.UpdateStatusAsync(null);
                await ctx.Message.ModifyAsync($"~~{ctx.Message.Content}~~ *Streaming Status cleared!*");
            }
            else
            {
                Game.Name = streamname;
                Game.StreamType = GameStreamType.Twitch;
                Game.Url = "https://www.twitch.tv/!";
                await Program.discord.UpdateStatusAsync(Game);
                await ctx.Message.ModifyAsync($"~~{ctx.Message.Content}~~ *Streaming {streamname}*");
            }
        }

        [Command("prune")]
        public async Task prune(CommandContext ctx)
        {
            IReadOnlyList<DiscordMessage> Messages = await ctx.Guild.GetChannel(ctx.Channel.Id).GetMessagesAsync(limit: 100);
            foreach (var _message in Messages)
            {
                if (_message.Author.Id == ctx.User.Id)
                {
                    await _message.DeleteAsync();
                }
            }
        }
    }
}
