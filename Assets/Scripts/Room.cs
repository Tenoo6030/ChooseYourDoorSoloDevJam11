using NUnit.Framework;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class Room : MonoBehaviour
{

    [SerializeField] private List<Transform> doorSpawnPoint = new();
    [SerializeField] private Transform cameraSpawnPoint;
    [SerializeField] private Transform spawnPoint;

    private Transform currentRoom;
    private int weaght;

    public ERoomTyp RoomType { get; set; }

    public Transform CreateRoom(ERoomTyp type, Transform roomPref)
    {

        RoomType = type;
        SetRoomTyp();

        currentRoom = Instantiate(roomPref, roomPref.position, roomPref.rotation); //Create a randomly selected room
        foreach (Transform point in doorSpawnPoint)//Randomizes and creates a specified number of doors for the room being created
        {
            Transform currentDoor = Instantiate(SelectDoor(), point.position, point.rotation);
            currentDoor.SetParent(currentRoom);
        }

        return currentRoom;
    }

    private Transform SelectDoor() //Create a randomly selected door
    {
        weaght = Random.Range(0, Level.Instance.RoomData.SetDoorWeaghtSum() + 1);
        foreach (var door in Level.Instance.RoomData.doorSOPrefs)
        {
            if (weaght - door.weaght <= 0)
            {
                door.doorPref.GetComponent<Door>().EntryCost = Random.Range(DoorSO.MIN_ENTRY_COST, DoorSO.MAX_ENTRY_COST); //Set current entry cost this door
                Level.Instance.RoomData.ResetWeaght();
                return door.doorPref;
            }
            else
            {
                weaght -= door.weaght;
            }

        }
        return null;
    }

    private void SetRoomTyp() //Set current room typ and current interaction
    {
        switch (RoomType)
        {
            case ERoomTyp.Empty:
                UnityEngine.Debug.Log(RoomType);
                break;

            case ERoomTyp.Item:
                UnityEngine.Debug.Log(RoomType);
                CreateNewInteraction(Level.Instance.RoomData.itemPref[0]);
                break;

            case ERoomTyp.Monster:
                UnityEngine.Debug.Log(RoomType);
                CreateNewInteraction(Level.Instance.RoomData.monstersPref[0]);
                break;

            case ERoomTyp.Trap:
                UnityEngine.Debug.Log(RoomType);
                CreateNewInteraction(Level.Instance.RoomData.trapPref[0]);
                break;

            default:
                break;
        }

    }

    private void CreateNewInteraction(Transform intractionTyp) // create current room interaction
    {
        if (intractionTyp != null)
        {
            Instantiate(intractionTyp, spawnPoint.position, spawnPoint.rotation);
        }

    }
}
