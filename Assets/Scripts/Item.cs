using UnityEngine;

public class Item : MonoBehaviour, IClicked
{
    [SerializeField] private Transform item;
    public void OnClickAction()
    {
        Destroy(item.gameObject);
    }
}
