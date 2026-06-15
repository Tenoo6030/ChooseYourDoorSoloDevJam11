using UnityEngine;

[CreateAssetMenu(fileName = "InteractionSO", menuName = "Scriptable Objects/InteractionSO")]
public class InteractionSO : ScriptableObject
{
    [Space]
    public string heder;
    public string description;
    [Space]
    public Transform interactionPref;
    public Texture2D icon;
    [Space]
    public int Uses;
    public int weaght;
    public int damage;
    public int heal;
    [Space]
    public EItemTyp itemTyp;
}
