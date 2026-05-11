using Unity.VisualScripting;
using UnityEngine;

public class Door : MonoBehaviour, IClicked
{
    private const int MAX_ENTRY_COST = 5;
    private const int MIN_ENTRY_COST = 1;

    [SerializeField] private DoorSO door;
    private TypesOfRoom roomType;
    private int entryCost;
   

    public void SetNewRoom()
    {
        roomType = door.room;

       Level.Instance.CreateNextRoom(roomType);
    }

    public void PayCost()
    {
        entryCost = Random.Range(MIN_ENTRY_COST,MAX_ENTRY_COST);
        Debug.Log(entryCost);
    }

    public void OnClickAction()
    {
        PayCost();
        SetNewRoom();
    }
}
