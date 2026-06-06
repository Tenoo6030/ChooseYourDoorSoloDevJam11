using UnityEngine;
using UnityEngine.UIElements;

public class Monster : MonoBehaviour, IClicked
{
    [SerializeField] private Transform monster;
    [SerializeField] private int damage;
    public void OnClickAction()
    {
        damage = Random.Range(1, 5);
        Level.Instance.PlayerData.DealDamage(damage);
        Debug.Log(damage);
        Destroy(monster.gameObject);
    }
}
