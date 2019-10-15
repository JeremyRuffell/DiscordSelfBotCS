using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace DiscordSelfBotCS
{
    class Config
    {
        public string Token { get; set; } = "tokenhere";
        public string Prefix { get; set; } = "!";

        /// <summary>
        /// Reads Config File.
        /// </summary>
        public void Create()
        {
            File.WriteAllText(Path.Combine(Environment.CurrentDirectory, "config.json"), JsonConvert.SerializeObject(this, Formatting.Indented));
        }
        
        /// <summary>
        /// Reads Config File.
        /// </summary>
        public Config Read()
        {
            return JsonConvert.DeserializeObject<Config>(File.ReadAllText(Path.Combine(Environment.CurrentDirectory, "config.json")));
        }
    }
}
