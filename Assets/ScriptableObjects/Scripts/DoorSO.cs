using UnityEngine;

[CreateAssetMenu(fileName = "DoorSO", menuName = "Scriptable Objects/DoorSO")]
public class DoorSO : ScriptableObject
{
    [HideInInspector]public const int MAX_ENTRY_COST = 5;
    [HideInInspector]public const int MIN_ENTRY_COST = 1;
    public int weaght;
    public string doorName;
    public Transform doorPref;
    public ERoomTyp roomTyp;

}

