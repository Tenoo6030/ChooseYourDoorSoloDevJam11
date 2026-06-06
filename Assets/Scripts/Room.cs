using NUnit.Framework;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.VisualScripting;
using UnityEngine;

public class Room : MonoBehaviour
{
    [SerializeField] private RoomSO room;
    [SerializeField] private List<Transform> doorSpawnPoint = new();
    [SerializeField] private Transform cameraSpawnPoint;
    [SerializeField] private Transform spawnPoint;

    private Transform newInteraction;
    private Transform currentRoom;
    private TypesOfRoom roomType;

    private void Awake()
    {
        newInteraction = null;
    }

    public Transform CreateRoom(TypesOfRoom type)
    {

        roomType = type;
        SetTypOFRoom();

        currentRoom = Instantiate(room.roomPref); //creates a randomly selected room
        foreach (Transform point in doorSpawnPoint)
        {
            Transform currentDoor = Instantiate(SelectDoor(), point.position, point.rotation);
            currentDoor.SetParent(currentRoom);
        } //randomizes and creates a specified number of doors for the room being created

        return currentRoom;
    }

    private Transform SelectDoor()
    {
        int weaght = 0;
        foreach (var doorWeaght in room.doorSOPrefs)
        {
            weaght += doorWeaght.weaght;
        }
        int currentW = Random.Range(0, weaght);
        foreach (var door in room.doorSOPrefs)
        {
            if (currentW - door.weaght <= 0)
            {
                door.doorPref.GetComponent<Door>().SetCost();
                return door.doorPref;
            }
            else
            {
                currentW -= door.weaght;
            }

        //for (int i = 0; i < room.doorSOPrefs.Length; i++)
        //{
        //    weaght += room.doorSOPrefs[i].weaght;
        //}

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

        }
        return null;
    }

    private void SetTypOFRoom()
    {
        switch (roomType)
        {
            case TypesOfRoom.Empty:
                UnityEngine.Debug.Log(roomType);
                newInteraction = null;
                break;

            case TypesOfRoom.Item:
                UnityEngine.Debug.Log(roomType);
                newInteraction = Level.Instance.CreateNewItem();
                break;

            case TypesOfRoom.Monster:
                UnityEngine.Debug.Log(roomType);
                newInteraction = Level.Instance.CreateNewMonster();
                break;

            case TypesOfRoom.Trap:
                UnityEngine.Debug.Log(roomType);
                newInteraction = Level.Instance.CreateNewTrap();
                break;

            default:
                break;
        }
        if (newInteraction != null)
        {
            Instantiate(newInteraction, spawnPoint.position, spawnPoint.rotation);
        }


    }

}
