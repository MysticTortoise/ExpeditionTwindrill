using UnityEngine;

public class GrabbableCollectible : GrabbablePickup
{
    public override void Pickup(SubPlayerController subPlayer)
    {
        StoreCollectible.instance.AddCollectible();
        base.Pickup(subPlayer);
    }
}
