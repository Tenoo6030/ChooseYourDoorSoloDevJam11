using UnityEngine;

public abstract class Interaction : MonoBehaviour, IClicked
{
    [SerializeField] protected Transform interaction;
    [SerializeField] protected InteractionSO interactionData;

    public virtual void OnClickAction()
    {
        Level.Instance.CurrentRoomTyp = ERoomTyp.Empty;
        Destroy(interaction.gameObject);
    }
}

public enum EItem
{
    Potion,
    MasterKey,
    Sword,
    Shield
}
