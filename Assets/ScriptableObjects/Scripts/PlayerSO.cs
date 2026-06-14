using Unity.Mathematics;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerSO", menuName = "Scriptable Objects/PlayerSO")]
public class PlayerSO : ScriptableObject
{
    private const int HEALTH_BAR_WIDTH = 800;
    private const int MAX_HEALTH = 100;
    private const int MIN_HEALTH = 0;
    [SerializeField, Range(0, 100)] private int healt = 100;
    [Range(0, 800)] public int healtBarFill;
    public string doorCost;
    public InteractionSO itemInLeftHend, itemInRightHend;

    public void DealDamage(int damage)
    {
        healt -= damage;
        healt = math.clamp(healt, MIN_HEALTH, MAX_HEALTH);
        healtBarFill = (int)(HEALTH_BAR_WIDTH * ((float)healt / MAX_HEALTH));
    }
    public void Heal(int heal)
    {
        healt += heal;
        healt = math.clamp(healt, MIN_HEALTH, MAX_HEALTH);
        healtBarFill = (int)(HEALTH_BAR_WIDTH * ((float)healt / MAX_HEALTH));
    }
    public void ResetHealth()
    {
        healt = MAX_HEALTH;
        healtBarFill = HEALTH_BAR_WIDTH;
    }


}
