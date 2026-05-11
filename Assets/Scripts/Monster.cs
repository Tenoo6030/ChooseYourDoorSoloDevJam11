using UnityEngine;

public class Monster : MonoBehaviour, IClicked
{
    [SerializeField] private Transform monster;
    public void OnClickAction()
    {
       Destroy(monster.gameObject);
    }
}
