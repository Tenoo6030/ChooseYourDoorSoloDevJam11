using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] protected List<Room> roomVariants = new();
    [SerializeField] protected List<Transform> monstersPref = new();
    [SerializeField] protected List<Transform> itemPref = new();
    [SerializeField] protected List<Transform> trapPref = new();

    private Transform currentRoom;
    private Transform currentInteractiweObject;

    public static Level Instance { get; private set; }

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
            DestroyIt(currentRoom.gameObject);
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
        
        return trapPref[0];
    }

    public void DestroyIt(GameObject _object)
    {
        Destroy(_object);
        
    }
}
