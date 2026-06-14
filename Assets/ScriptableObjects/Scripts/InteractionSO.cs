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
    public int currentUses;
    public int weaght;
    public int damage;
    public int heal;
    [Space]
    public EItem item;
}
