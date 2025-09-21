using UnityEngine;

public class GrabbableMine : GrabbablePickup
{
    public override void Pickup(SubPlayerController subPlayer)
    {
        subPlayer.GetComponent<DamageHandler>().TakeDamage(transform.position);
        base.Pickup(subPlayer);
    }
}