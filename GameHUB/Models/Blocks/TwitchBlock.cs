using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using GameHUB.Infrastructure.Editor;

namespace GameHUB.Models.Blocks
{
    [ContentType(DisplayName = "TwitchBlock", GUID = "c9686569-7340-4b8a-a593-a9984c648e52", Description = "")]
    public class TwitchBlock : BlockData
    {
        [CultureSpecific]
        [Display(
            Name = "Channel",
            Description = "Name of the twitch channel to use",
            GroupName = GroupNames.Main,
            Order = 1)]
        public virtual string Channel { get; set; }
    }
}