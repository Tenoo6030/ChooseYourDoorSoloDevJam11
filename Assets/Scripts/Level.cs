using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{

    [SerializeField] private PlayerSO playerData;
    [SerializeField] private RoomSO roomData;
    [SerializeField] private Transform currentRoomPref;
    [SerializeField] private Room currentRoom;
    [SerializeField] private ERoomTyp currentRoomTyp;


    public static Level Instance { get; private set; }
    public PlayerSO PlayerData { get => playerData; set => playerData = value; }
    public RoomSO RoomData { get => roomData; set => roomData = value; }
    public ERoomTyp CurrentRoomTyp { get => currentRoomTyp; set => currentRoomTyp = value; }

    private void Awake()
    {
        Instance = this;
        playerData.ResetPlayer();
    }
    private void Start()
    {
        CreateNextRoom(ERoomTyp.Item);

    }

    private void Update()
    {
        if (playerData.healtBarFill <= 0)
        {
            SceneManager.LoadScene(0);
        }
    }

    public void CreateNextRoom(ERoomTyp type)
    {
        if (currentRoomPref != null)
        {
            Destroy(currentRoomPref.gameObject);

        }
        currentRoom = roomData.roomVariantsPref[Random.Range(0, roomData.roomVariantsPref.Count)];
        currentRoomPref = currentRoom.CreateRoom(type, currentRoom.transform);
        CurrentRoomTyp = type;


    }

    private void OnDestroy()
    {
        playerData.ResetPlayer();

    }
}
