using UnityEngine;

public abstract class Interaction : MonoBehaviour, IClicked
{
    [SerializeField] protected Transform interaction;
    public virtual void OnClickAction()
    {
        Level.Instance.CurrentRoomTyp = ERoomTyp.Empty;
       Destroy(interaction.gameObject);
    }
}
