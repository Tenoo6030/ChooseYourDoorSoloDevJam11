using UnityEngine;
using UnityEngine.UIElements;

public class Monster : Interaction, IClicked
{
    protected override void Awake()
    {
        base.Awake();
    }
    public override void OnClickAction()
    {
        
        //if (Level.Instance.PlayerData.itemInLeftHand || Level.Instance.PlayerData.itemInRightHand)
        //{

        //    CheckPlayerHand();
        //    Debug.LogAssertion("gracz ma coœ w d³oniach ");
        //}
        //else
        //{
        //    Level.Instance.PlayerData.DealDamage(interactionData.damage);
        //}

        base.OnClickAction();
    }
    //private void CheckPlayerHand()
    //{
    //    if(Level.Instance.PlayerData.inLeftHand == interactionData.itemTyp)
    //    {
    //        popup.ActivePopup(interactionData);
    //    }
    //    else if (Level.Instance.PlayerData.inRightHand == interactionData.itemTyp)
    //    { 
    //        popup.ActivePopup(interactionData);
    //    }
    //    else
    //    {
    //        Level.Instance.PlayerData.DealDamage(interactionData.damage);
    //    }
    //}
}
