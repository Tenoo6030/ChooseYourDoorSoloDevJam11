using NUnit.Framework;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Room : MonoBehaviour
{
    [SerializeField] private RoomSO room;
    [SerializeField] private List<Transform> doorSpawnPoint = new();
    private Transform currentRoom;


    public Transform CreateRoom()
    {
        currentRoom = Instantiate(room.roomPref);
        foreach (Transform point in doorSpawnPoint)
        {
            Transform currentDoor = Instantiate(SelectDoor(), point.position, point.rotation);
            currentDoor.SetParent(currentRoom);
        }
        return currentRoom;
    }

    private Transform SelectDoor()
    {
        int weaght = 0;
        for (int i = 0; i < room.doorSOPrefs.Length; i++)
        {
            weaght += room.doorSOPrefs[i].weaght;
        }

        int currentW = Random.Range(0, weaght);
        for (int i = 0; i < room.doorSOPrefs.Length; i++)
        {

            if (currentW - room.doorSOPrefs[i].weaght <= 0)
            {

                return room.doorSOPrefs[i].doorPref;
            }
            else
            {
                currentW -= room.doorSOPrefs[i].weaght;
            }
        }

        return null;
    }

    private void DestroyRoom()
    {
        Destroy(this);
    }
}
