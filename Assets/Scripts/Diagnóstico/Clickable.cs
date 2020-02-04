using System;
using UnityEngine;

public class Clickable : MonoBehaviour
{
    [SerializeField]
    public NotifyInformation notifyInformation;
    public Texture2D mouseOverTexture2D;
    private Texture2D normalCursor;

    void OnMouseDown()
    {
        if (IsLeftMousePressed())
        {
            if (!OptionsToolController.IsMouseOver())
            {
                if (IsGameMakingDiagnostic() && !DiagnosticSceneController.ThereIsDialogToShow())
                {
                    OptionsToolController.Show(this, notifyInformation);
                }
            }
        }
    }

    private bool IsGameMakingDiagnostic()
    {
        return DiagnosticSceneController.diagnosticState == DiagnosticState.MakingDiagnostic;
    }

    private void OnMouseEnter()
    {
        UpdateCursorToMouseOver(true);
    }

    private void OnMouseExit()
    {
        UpdateCursorToMouseOver(false);
    }

    private void UpdateCursorToMouseOver(bool isMouseOver)
    {
        if (isMouseOver)
        {
            if (notifyInformation.isClickable)
            {
                Cursor.SetCursor(mouseOverTexture2D, new Vector2(0, 0), CursorMode.Auto);
            }
        }
        else
        {
            Cursor.SetCursor(normalCursor, new Vector2(0, 0), CursorMode.Auto);
        }
    }

    private bool IsLeftMousePressed()
    {
        int LEFT_MOUSE_BUTTON = 0;
        return Input.GetMouseButton(LEFT_MOUSE_BUTTON);
    }
}

[Serializable]
public struct NotifyInformation
{
    public bool isClickable;
    public string textOnWandClick;
    public string textOnExaminateClick;
    public string textOnLookClick;
}