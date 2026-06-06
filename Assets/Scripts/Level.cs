using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] private List<Room> roomVariants = new();
    [SerializeField] private List<Transform> monstersPref = new();
    [SerializeField] private List<Transform> itemPref = new();
    [SerializeField] private List<Transform> trapPref = new();
    [SerializeField]private PlayerSO playerData;
    
    private Transform currentRoom;
    private Transform currentInteractiweObject;

    public static Level Instance { get; private set; }
    public PlayerSO PlayerData { get => playerData; set => playerData = value; }


    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        TypesOfRoom fyrstRoom = new();
        fyrstRoom.Equals("Empty");
        CreateNextRoom(fyrstRoom);

    }

    public void CreateNextRoom(TypesOfRoom type)
    {
        if (currentRoom != null)
        {
            Destroy(currentRoom.gameObject);
        }
        currentRoom = roomVariants[Random.Range(0, roomVariants.Count)].CreateRoom(type);

    }

    public Transform CreateNewMonster()
    {
        //int weaght = 0;
        //for (int i = 0; i <  i++)
        //{
        //    weaght += room.doorSOPrefs[i].weaght;
        //}

        //int currentW = Random.Range(0, weaght);
        //for (int i = 0; i < room.doorSOPrefs.Length; i++)
        //{

        //    if (currentW - room.doorSOPrefs[i].weaght <= 0)
        //    {

        //        return room.doorSOPrefs[i].doorPref;
        //    }
        //    else
        //    {
        //        currentW -= room.doorSOPrefs[i].weaght;
        //    }
        //}
        currentInteractiweObject = monstersPref[0];
        return monstersPref[0];
    }
    public Transform CreateNewItem()
    {
        //int weaght = 0;
        //for (int i = 0; i <  i++)
        //{
        //    weaght += room.doorSOPrefs[i].weaght;
        //}

        //int currentW = Random.Range(0, weaght);
        //for (int i = 0; i < room.doorSOPrefs.Length; i++)
        //{

        //    if (currentW - room.doorSOPrefs[i].weaght <= 0)
        //    {

        //        return room.doorSOPrefs[i].doorPref;
        //    }
        //    else
        //    {
        //        currentW -= room.doorSOPrefs[i].weaght;
        //    }
        //}
       currentInteractiweObject = itemPref[0];
        return itemPref[0];
    }
    public Transform CreateNewTrap()
    {
        //int weaght = 0;
        //for (int i = 0; i <  i++)
        //{
        //    weaght += room.doorSOPrefs[i].weaght;
        //}

        //int currentW = Random.Range(0, weaght);
        //for (int i = 0; i < room.doorSOPrefs.Length; i++)
        //{

        //    if (currentW - room.doorSOPrefs[i].weaght <= 0)
        //    {

        //        return room.doorSOPrefs[i].doorPref;
        //    }
        //    else
        //    {
        //        currentW -= room.doorSOPrefs[i].weaght;
        //    }
        //}
        currentInteractiweObject = trapPref[0];
        return trapPref[0];
    }

    public Transform CreateNewInteraction()
    {
        return null;
    }

    private void OnDestroy()
    {
        playerData.ResetHealth();
    }
}
