using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private DoorSO thisdoor;
   

    public void SetNewRoom()
    {
       Level.Instance.CreateNextRoom();
    }
}
