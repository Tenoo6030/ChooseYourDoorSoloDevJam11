using UnityEngine;
using UnityEngine.UIElements;

public class Monster : Interaction, IClicked
{
    [SerializeField] private int damage;

    public override void OnClickAction()
    {
        damage = Random.Range(1, 5);
        Level.Instance.PlayerData.DealDamage(damage);
        Debug.Log(damage);
        base.OnClickAction();
    }
}
