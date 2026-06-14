using UnityEngine;
using UnityEngine.UIElements;

public class Monster : Interaction, IClicked
{
    public override void OnClickAction()
    {
        Level.Instance.PlayerData.DealDamage(interactionData.damage);
        base.OnClickAction();
    }
}
