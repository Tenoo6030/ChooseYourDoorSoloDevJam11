using UnityEngine;
using UnityEngine.UIElements;

public class Item : Interaction, IClicked
{
    protected override void Awake()
    {
       base.Awake();
    }
    public override void OnClickAction()
    {
        //popup.ActivePopup(interactionData);
        base.OnClickAction();
    }
}