using UnityEngine;

public class Trap : Interaction
{
    [SerializeField] private int damage = 2;

    public override void OnClickAction()
    {
        Level.Instance.PlayerData.DealDamage(damage);
        base.OnClickAction();
    }
}
