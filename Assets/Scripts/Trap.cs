using UnityEngine;

public class Trap : MonoBehaviour, IClicked
{
    [SerializeField] private Transform trap;
    [SerializeField] private int damage = 2;
    public void OnClickAction()
    {
        Level.Instance.PlayerData.DealDamage(damage);
        Destroy(trap.gameObject);
    }
}
