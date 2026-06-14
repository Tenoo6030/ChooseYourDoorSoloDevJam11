using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RoomSO", menuName = "Scriptable Objects/RoomSO")]
public class RoomSO : ScriptableObject
{
    [SerializeField]private int weaghtSum;

    public List<Room> roomVariantsPref = new();
    public List<InteractionSO> monstersPref = new();
    public List<Transform> itemPref = new();
    public List<Transform> trapPref = new();
    public List<DoorSO> doorSOPrefs;

    public int SetDoorWeaghtSum()
    {
        foreach (var doorWeaght in doorSOPrefs)
        {
            weaghtSum += doorWeaght.weaght;
        }
        return weaghtSum;
    }
    public int SetMonsterWeaghtSum()
    {
        foreach (var monsterWeaght in monstersPref)
        {
            weaghtSum += monsterWeaght.weaght;
        }
        return weaghtSum;
    }
    public void ResetWeaght() => weaghtSum = 0;
}

public enum ERoomTyp
{
    Empty,
    Item,
    Monster,
    Trap
}