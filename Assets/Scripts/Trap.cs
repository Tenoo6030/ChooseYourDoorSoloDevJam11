using UnityEngine;

public class Trap : MonoBehaviour
{
    [SerializeField] private Transform trap;
    public void OnClickAction()
    {
        Destroy(trap.gameObject);
    }
}
