using UnityEngine;

[CreateAssetMenu(fileName = "DoorSO", menuName = "Scriptable Objects/DoorSO")]
public class DoorSO : ScriptableObject
{
    public int weaght;

    public string doorName;
    public Transform doorPref;

    public TypesOfRoom room;

}

public enum TypesOfRoom
{
    Empty,
    Item,
    Monster,
    Trap
}
