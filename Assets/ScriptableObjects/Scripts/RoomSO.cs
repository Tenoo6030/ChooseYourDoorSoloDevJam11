using UnityEngine;

[CreateAssetMenu(fileName = "RoomSO", menuName = "Scriptable Objects/RoomSO")]
public class RoomSO : ScriptableObject
{
    public string roomName;
    public Transform roomPref;

    public int doorNamber;
    public DoorSO[] doorSOPrefs;

}
