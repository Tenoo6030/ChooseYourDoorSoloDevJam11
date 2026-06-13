using UnityEngine;

public class Door : MonoBehaviour, IClicked
{
    [SerializeField] private DoorSO doorData;
    [SerializeField] private int entryCost;

    public DoorSO DoorData { get => doorData; private set => doorData = value; }
    public int EntryCost { get => entryCost; set => entryCost = value; }

    public void OnClickAction()
    {
        Level.Instance.PlayerData.DealDamage(EntryCost); //Deal damag to player equal to entry cost
        Level.Instance.CreateNextRoom(doorData.roomTyp); //Create new room 
        entryCost = 0; //Reset entry cost
    }

}
