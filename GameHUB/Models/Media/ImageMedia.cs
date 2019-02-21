using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Framework.DataAnnotations;

namespace GameHUB.Models.Media
{
    [ContentType(DisplayName = "ImageMedia", GUID = "c6caa8fa-62a2-4dd5-9734-56343c23abf5", Description = "Image type")]
    [MediaDescriptor(ExtensionString = "jpg, jpeg, png, bmp, gif, svg")]
    public class ImageMedia : ImageData
    {
        
    }
}