using UnityEngine;

public abstract class Interaction : MonoBehaviour, IClicked
{
    [SerializeField] protected Transform interaction;
    [SerializeField] protected InteractionSO interactionData;
    [SerializeField] protected PopupController popup;

    protected virtual void Awake()
    {
        popup = FindFirstObjectByType<PopupController>();
    }

    public virtual void OnClickAction()
    {
        if (Level.Instance.CurrentRoomTyp == ERoomTyp.Item)
        {
            popup.ActivePopup(interactionData);
        }
        else
        {
            if (Level.Instance.PlayerData.itemInLeftHand || Level.Instance.PlayerData.itemInRightHand)
            {
                CheckPlayerHand();
            }
            else
            {
                Level.Instance.PlayerData.DealDamage(interactionData.damage);
            }
        }

        Level.Instance.CurrentRoomTyp = ERoomTyp.Empty;
        Destroy(interaction.gameObject);
    }
    protected void CheckPlayerHand()
    {
        if (Level.Instance.PlayerData.inLeftHand == interactionData.itemTyp)
        {
            popup.ActivePopup(interactionData);
        }
        else if (Level.Instance.PlayerData.inRightHand == interactionData.itemTyp)
        {
            popup.ActivePopup(interactionData);
        }
        else
        {
            Level.Instance.PlayerData.DealDamage(interactionData.damage);
        }
    }

}

public enum EItemTyp
{
    none,
    Potion,
    MasterKey,
    Sword,
    Shield
}
