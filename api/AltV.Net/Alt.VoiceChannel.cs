using System;
using AltV.Net.Elements.Entities;

namespace AltV.Net
{
    public partial class Alt
    {
        public static IVoiceChannel CreateVoiceChannel(bool spatial, float maxDistance) =>
            CoreImpl.CreateVoiceChannel(spatial, maxDistance);
    }
}