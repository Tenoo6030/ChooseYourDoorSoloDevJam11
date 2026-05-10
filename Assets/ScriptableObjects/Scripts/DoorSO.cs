using UnityEngine;

[CreateAssetMenu(fileName = "DoorSO", menuName = "Scriptable Objects/DoorSO")]
public class DoorSO : ScriptableObject 
{
    public string doorName;
    public string roomName;
    public TypesOfRoom room;
    public int weaght;
}

public enum TypesOfRoom
{
    Empty,
    Item,
    Monster,
    Trap
}
