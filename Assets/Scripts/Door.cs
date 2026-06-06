using UnityEngine;

public class Door : MonoBehaviour, IClicked
{
    private const int MAX_ENTRY_COST = 5;
    private const int MIN_ENTRY_COST = 1;

    [SerializeField] private DoorSO doorData;
    [SerializeField]private int entryCost;
    private TypesOfRoom roomType;

    public DoorSO DoorData { get => doorData; private set => doorData = value; }
    public int EntryCost { get => entryCost; private set => entryCost = value; }

    public void SetCost()
    {
        entryCost = Random.Range(MIN_ENTRY_COST, MAX_ENTRY_COST);
        EntryCost = entryCost;
    }

    public void SetNewRoom()
    {
        roomType = doorData.room;

        Level.Instance.CreateNextRoom(roomType);
    }

    public void PayCost()
    {
        Level.Instance.PlayerData.DealDamage(EntryCost);
        Debug.Log(EntryCost);
    }

    public void OnClickAction()
    {
        PayCost();
        SetNewRoom();
    }
}
