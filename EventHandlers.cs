using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.Events.EventArgs.Player;
using PlayerRoles;
using UnityEngine;

namespace FlashbangGun
{
    public class EventHandlers
    {
        private readonly FlashbangGun _plugin;
        private int _index;

        private static readonly ProjectileType[] Projectiles =
        {
            ProjectileType.Flashbang,
            ProjectileType.FragGrenade,
            ProjectileType.Scp018,
        };

        public EventHandlers(FlashbangGun plugin) => _plugin = plugin;

        public void OnShooting(ShootingEventArgs ev)
        {
            if (ev.Player.CurrentItem?.Type != ItemType.GunCom45)
                return;

            ev.IsAllowed = false;

            // Alterne : flashbang -> grenade -> SCP-018 -> flashbang...
            ProjectileType type = Projectiles[_index];
            _index = (_index + 1) % Projectiles.Length;

            ev.Player.ThrowGrenade(type);

            if (_plugin.Config.Debug)
                Log.Info($"{ev.Player.Nickname} a tiré avec le COM-45 ({type}).");
        }
    }
}
