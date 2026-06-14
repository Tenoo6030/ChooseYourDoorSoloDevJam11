using UnityEngine;

public class Trap : Interaction
{
    public override void OnClickAction()
    {
        Level.Instance.PlayerData.DealDamage(interactionData.damage);
        base.OnClickAction();
    }
}
