using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.API.Features.Items;
using Exiled.Events.EventArgs;
using Exiled.Events.EventArgs.Player;
using PlayerRoles;
using UnityEngine;

namespace FlashbangGun
{
    public class EventHandlers
    {
        private readonly FlashbangGun _plugin;
        private bool _next;

        public EventHandlers(FlashbangGun plugin) => _plugin = plugin;

        public void OnShooting(ShootingEventArgs ev)
        {
            if (ev.Player.CurrentItem?.Type == ItemType.GunCom45)
            {
                ev.IsAllowed = false;

                // Alterne : flashbang, grenade, flashbang, grenade...
                _next = !_next;
                ev.Player.ThrowGrenade(_next ? ProjectileType.Flashbang : ProjectileType.FragGrenade);

                if (_plugin.Config.Debug)
                {
                    Log.Info($"{ev.Player.Nickname} a tiré avec le COM-45.");
                }
            }
        }
    }
}
