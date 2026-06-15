using UnityEngine;
using UnityEngine.UIElements;

public class PopupController : MonoBehaviour
{
    [SerializeField] private UIDocument uiDocument;
    [SerializeField] private VisualElement leftHandIcon, rightHandIcon, icon, itemPopupWindow, questionPopupWindow;
    [SerializeField] private Label heder, description, leftCurrentUse, rightCurrentUse;
    [SerializeField] private Button acceptButton, cancelButton, leftHandButton, rightHandButton;
    [SerializeField] private InteractionSO currentInteraction;
    
    private void Awake()
    {
        leftHandIcon = uiDocument.rootVisualElement.Q<VisualElement>("ItemInLeftHand");
        rightHandIcon = uiDocument.rootVisualElement.Q<VisualElement>("ItemInRightHand");
        itemPopupWindow = uiDocument.rootVisualElement.Q<VisualElement>("PopupContener");
        questionPopupWindow = uiDocument.rootVisualElement.Q<VisualElement>("QuestionPopupContener");
        icon = uiDocument.rootVisualElement.Q<VisualElement>("Icon");

        heder = uiDocument.rootVisualElement.Q<Label>("Header");
        description = uiDocument.rootVisualElement.Q<Label>("Description");
        leftCurrentUse = uiDocument.rootVisualElement.Q<Label>("LeftUseNumber");
        rightCurrentUse = uiDocument.rootVisualElement.Q<Label>("RightUseNumber");

        acceptButton = uiDocument.rootVisualElement.Q<UnityEngine.UIElements.Button>("AcceptButton");
        cancelButton = uiDocument.rootVisualElement.Q<UnityEngine.UIElements.Button>("CancelButton");
        leftHandButton = uiDocument.rootVisualElement.Q<UnityEngine.UIElements.Button>("LeftHandButton");
        rightHandButton = uiDocument.rootVisualElement.Q<UnityEngine.UIElements.Button>("RightHandButton");


        itemPopupWindow.visible = false;
        questionPopupWindow.visible = false;
        leftHandIcon.visible = false;
        leftCurrentUse.visible = false;
        rightHandIcon.visible = false;
        rightCurrentUse.visible = false;

    }
    
    private void SetItemToLeftHend()
    {
        Level.Instance.PlayerData.itemInLeftHand = currentInteraction; //set item tu left hend and show it 
        leftHandIcon.dataSource = currentInteraction;
        leftHandIcon.visible = true;

        Level.Instance.PlayerData.leftCurrentItemUse = currentInteraction.Uses; //set courrent use
        Level.Instance.PlayerData.inLeftHand = currentInteraction.itemTyp;
        leftCurrentUse.dataSource = Level.Instance.PlayerData;
        leftCurrentUse.visible = true;

        itemPopupWindow.visible = false;
        questionPopupWindow.visible = false; //hide popup window
        leftHandButton.clicked -= SetItemToLeftHend;
    }
    
    private void SetItemToRightHend()
    {
        Level.Instance.PlayerData.itemInRightHand = currentInteraction; //set item tu left hend and show it 
        rightHandIcon.dataSource = currentInteraction;
        rightHandIcon.visible = true;

        Level.Instance.PlayerData.rightCurrentItemUse = currentInteraction.Uses; // set courrent use 
        Level.Instance.PlayerData.inRightHand = currentInteraction.itemTyp;
        rightCurrentUse.dataSource = Level.Instance.PlayerData;
        rightCurrentUse.visible = true;

        itemPopupWindow.visible = false;
        questionPopupWindow.visible = false; //hide popup window 
        rightHandButton.clicked -= SetItemToRightHend;

    }

    public void ActivePopup(InteractionSO item)
    {
        currentInteraction = item;
        itemPopupWindow.visible = true;
        heder.dataSource = currentInteraction;
        description.dataSource = currentInteraction;
        icon.dataSource = currentInteraction;
        switch (Level.Instance.CurrentRoomTyp)
        {
            case ERoomTyp.Item:
                acceptButton.clicked += PickUpItem;
                cancelButton.clicked += DropItem;
                break;
            case ERoomTyp.Trap:
            case ERoomTyp.Monster:
                acceptButton.clicked += UseItem;
                cancelButton.clicked += DealDamage;
                break;
        }
    }
    private void UseItem()
    {
        if (Level.Instance.PlayerData.inLeftHand == currentInteraction.itemTyp) //Use item from left hand
        {
            Level.Instance.PlayerData.leftCurrentItemUse--;
            if (Level.Instance.PlayerData.leftCurrentItemUse <= 0) 
            {
                Level.Instance.PlayerData.itemInLeftHand = null;
                Level.Instance.PlayerData.inLeftHand = EItemTyp.none;
                Level.Instance.PlayerData.leftCurrentItemUse = 0;
                leftHandIcon.dataSource = null;
                leftHandIcon.visible = false;
                leftCurrentUse.visible = false;
            }

            itemPopupWindow.visible = false;
        }
        else if (Level.Instance.PlayerData.inRightHand == currentInteraction.itemTyp) //Use item from right hand
        {
            Level.Instance.PlayerData.rightCurrentItemUse--;
            if(Level.Instance.PlayerData.rightCurrentItemUse <= 0)
            {
                Level.Instance.PlayerData.itemInRightHand = null;
                Level.Instance.PlayerData.inRightHand = EItemTyp.none;
                Level.Instance.PlayerData.rightCurrentItemUse = 0;
                rightHandIcon.dataSource = null;
                rightHandIcon.visible = false;
                rightCurrentUse.visible = false;
            }

            itemPopupWindow.visible = false;
        }
        acceptButton.clicked -= UseItem;
        cancelButton.clicked -= DealDamage;
    }

    private void DealDamage()
    { 
        Level.Instance.PlayerData.DealDamage(currentInteraction.damage);
        itemPopupWindow.visible = false;
        acceptButton.clicked -= UseItem;
        cancelButton.clicked -= DealDamage;
    }
    private void DropItem()
    {
        itemPopupWindow.visible = false;
        acceptButton.clicked -= PickUpItem;
        cancelButton.clicked -= DropItem;
    }

    public void PickUpItem()
    {
        acceptButton.clicked -= PickUpItem;
        cancelButton.clicked -= DropItem;
        if (Level.Instance.PlayerData.itemInLeftHand != null && Level.Instance.PlayerData.itemInRightHand != null)
        {
            itemPopupWindow.visible = false;
            questionPopupWindow.visible = true;
            leftHandButton.clicked += SetItemToLeftHend;
            rightHandButton.clicked += SetItemToRightHend;

        }
        else if (Level.Instance.PlayerData.itemInLeftHand == null)
        {
            SetItemToLeftHend();
           
        }
        else
        {
            SetItemToRightHend();
            
        }

    }


}

