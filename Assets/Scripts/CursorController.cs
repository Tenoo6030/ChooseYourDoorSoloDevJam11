using System;
using Unity.VisualScripting;
using UnityEditor.ShaderGraph;
using UnityEngine;

public class CursorController : MonoBehaviour
{
    [SerializeField] private Texture2D cursor;
    [SerializeField] private Texture2D cursorClicked;

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

                switch (hit.collider.tag)
                {
                    case "Door":
                        Door objD = hit.collider.GetComponent<Door>();
                        objD.OnClickAction();
                        break;

                    case "Monster":
                        Monster objM = hit.collider.GetComponent<Monster>();
                        objM.OnClickAction();
                        break;

                    case "Item":
                        Item objI = hit.collider.GetComponent<Item>();
                        objI.OnClickAction();
                        break;

                    case "Trap":
                        Trap objT = hit.collider.GetComponent<Trap>();
                        objT.OnClickAction();
                        break;

                    default:
                        break;
                }
        }
        return null;
    }




}
