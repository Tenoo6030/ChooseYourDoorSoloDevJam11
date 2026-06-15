using Unity.Mathematics;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerSO", menuName = "Scriptable Objects/PlayerSO")]
public class PlayerSO : ScriptableObject
{
    private const int HEALTH_BAR_WIDTH = 800;
    private const int MAX_HEALTH = 100;
    private const int MIN_HEALTH = 0;

    [Header("Player Healt"), Space]
    [SerializeField, Range(0, 100)] private int healt = 100; //Curent player healt 
    [Range(0, 800)] public int healtBarFill; //Current UI healt bar value

    [Header("Left Hand"), Space] //Curent item in left player hand
    public InteractionSO itemInLeftHand;
    public EItemTyp inLeftHand;
    public int leftCurrentItemUse;

    [Header("Right Hand"), Space] //Curent item in right player hand
    public InteractionSO itemInRightHand;
    public EItemTyp inRightHand;
    public int rightCurrentItemUse;

    public void DealDamage(int damage) //Set damag to player healt
    {
        healt -= damage;
        healt = math.clamp(healt, MIN_HEALTH, MAX_HEALTH);
        healtBarFill = (int)(HEALTH_BAR_WIDTH * ((float)healt / MAX_HEALTH));
    } 
    public void Heal(int heal)//Heal player healt
    {
        healt += heal;
        healt = math.clamp(healt, MIN_HEALTH, MAX_HEALTH);
        healtBarFill = (int)(HEALTH_BAR_WIDTH * ((float)healt / MAX_HEALTH));
    }
    public void ResetPlayer() //Reset player to start point
    {
        healt = MAX_HEALTH;
        healtBarFill = HEALTH_BAR_WIDTH;
        leftCurrentItemUse = 0;
        rightCurrentItemUse = 0;
        itemInLeftHand = null;
        itemInRightHand = null;
        inRightHand = EItemTyp.none;
        inLeftHand = EItemTyp.none;
    }


}
