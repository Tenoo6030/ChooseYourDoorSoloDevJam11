using UnityEngine;
using UnityEngine.UIElements;

public class PopupControler : MonoBehaviour
{
    [SerializeField] private UIDocument uiDocument;
    [SerializeField] private VisualElement leftHendIcon, rightHendIcon, icon;
    [SerializeField] private Label heder, description, leftCurrentUse,rightCurrentUse;

    private void Awake()
    {
        leftHendIcon = uiDocument.rootVisualElement.Q<VisualElement>("ItemInLeftHend");
        rightHendIcon = uiDocument.rootVisualElement.Q<VisualElement>("ItemInRightHend");
        icon = uiDocument.rootVisualElement.Q<VisualElement>("Icon");
        
        heder = uiDocument.rootVisualElement.Q<Label>("Header");
        description = uiDocument.rootVisualElement.Q<Label>("Description");
        leftCurrentUse = uiDocument.rootVisualElement.Q<Label>("LeftUseNumber");
        rightCurrentUse = uiDocument.rootVisualElement.Q<Label>("RightUseNumber");
       
    }
}

