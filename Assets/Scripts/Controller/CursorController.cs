using UnityEngine.UIElements;
using UnityEngine;
using Cursor = UnityEngine.Cursor;

public class CursorController : MonoBehaviour
{
    [SerializeField] private Texture2D cursor;
    [SerializeField] private Texture2D cursorClicked;
    [SerializeField] private UIDocument uiDocument;

    private CursorActions controls;
    private Camera mainCamrra;



    private void Awake()
    {
        controls = new CursorActions();
        ChangeCursor(cursor);
        Cursor.lockState = CursorLockMode.Confined;

        mainCamrra = Camera.main;

    }

    private void OnEnable()
    {
        controls.Enable();
    }


    private void OnDisable()
    {
        controls.Disable();

    }

    private void Start()
    {
        controls.Mouse.Click.started += _ => StartedClick();
        controls.Mouse.Click.performed += _ => EndedClick();
    }
    private void Update()
    {

        Ray ray = mainCamrra.ScreenPointToRay(controls.Mouse.Position.ReadValue<Vector2>());
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (hit.collider != null && hit.collider.gameObject.CompareTag("Door"))
            {

                Door doorData = hit.collider.GetComponent<Door>();
                VisualElement doorContener = uiDocument.rootVisualElement.Q<VisualElement>("DoorCostContener");
                doorContener.visible = true;
                Label doorCost = uiDocument.rootVisualElement.Q<Label>("Cost");
                doorCost.text = doorData.EntryCost.ToString();
            }
        }
        else
        {
            VisualElement doorContener = uiDocument.rootVisualElement.Q<VisualElement>("DoorCostContener");
            doorContener.visible = false;
        }
    }

    private void StartedClick()
    {
        ChangeCursor(cursorClicked);
    }

    private void EndedClick()
    {
        ChangeCursor(cursor);
        DetectObject();

    }

    private void ChangeCursor(Texture2D cursorType)
    {
        Cursor.SetCursor(cursorType, Vector2.zero, CursorMode.Auto);
    }

    private Transform DetectObject()
    {
        Ray ray = mainCamrra.ScreenPointToRay(controls.Mouse.Position.ReadValue<Vector2>());

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (hit.collider != null)
            {
                IClicked obj = hit.collider.GetComponent<IClicked>();
                obj.OnClickAction();

            }

        }
        return null;
    }

}