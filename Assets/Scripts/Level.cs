using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] private List<RoomSO> roomWariants = new();
    private RoomSO currentRoomSO;
    private Transform currentRoom;


    private void Start()
    {
        currentRoomSO = roomWariants[Random.Range(0, roomWariants.Count)];
        Debug.Log(currentRoomSO.roomName);

        CreateRoom();

    }




    private void CreateRoom()
    {
        SelectDoor();
        currentRoom = Instantiate(currentRoomSO.roomPref);
        Transform[] roomComponent = currentRoom.GetComponentsInChildren<Transform>();

        foreach (Transform rRomponent in roomComponent)
        {
            // Debug.Log(rRomponent.name);

        }

    }

    private DoorSO SelectDoor()
    {
        int weaght = 0;
        for (int i = 0; i < currentRoomSO.doorSOPrefs.Length; i++)
        {
            weaght += currentRoomSO.doorSOPrefs[i].weaght;
        }

        int w = Random.Range(0, weaght);
        for (int i = 0; i < currentRoomSO.doorSOPrefs.Length; i++)
        {
            Debug.Log("wylosowana liczba to " + w);

            if (w - currentRoomSO.doorSOPrefs[i].weaght <= 0)
            {
                Debug.Log("to, to " + currentRoomSO.doorSOPrefs[i]);

                return currentRoomSO.doorSOPrefs[i];
            }
            else
            {
                w -= currentRoomSO.doorSOPrefs[i].weaght;
                Debug.Log("to nie to " + currentRoomSO.doorSOPrefs[i]);
            }
        }


        return null;
    }
}