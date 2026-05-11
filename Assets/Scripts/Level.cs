using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] private List<Room> roomVariants = new();

    private Transform currentRoom;

    public static Level Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        CreateNextRoom();

    }

    public void CreateNextRoom()
    {
        if (currentRoom != null)
        {
            Destroy(currentRoom.gameObject);
        }
        currentRoom = roomVariants[Random.Range(0, roomVariants.Count)].CreateRoom();

    }
}
