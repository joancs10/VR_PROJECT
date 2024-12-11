using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseScreenMapping : MonoBehaviour
{

    public Canvas canvas;                // Reference to the Canvas (must be World Space)
    public RectTransform backgroundRect; // The background RectTransform
    public RectTransform redDotRect;     // The red dot RectTransform

    void Update()
    {
        // Get the mouse position in screen space
        Vector2 mouseScreenPos = Input.mousePosition;

        // Check if the mouse is within the Game Window bounds
        mouseCheckPosition(mouseScreenPos);

        // Convert screen position to local position in the background RectTransform
        Vector2 localPoint;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            backgroundRect,
            mouseScreenPos,
            canvas.worldCamera, // Use the Canvas's camera for World Space
            out localPoint
        );

        // Clamp the local position to stay within the bounds of the background rect
        Vector2 clampedPosition = new Vector2(
            Mathf.Clamp(localPoint.x, backgroundRect.rect.xMin, backgroundRect.rect.xMax),
            Mathf.Clamp(localPoint.y, backgroundRect.rect.yMin, backgroundRect.rect.yMax)
        );

        // Update the red dot's position with the clamped value
        redDotRect.anchoredPosition = clampedPosition;
    }
    void mouseCheckPosition( Vector2 vec )
    {
        if (vec.x < 0 || vec.y < 0 ||
            vec.x > Screen.width || vec.y > Screen.height)
        {
            return; // Exit if the mouse is outside the Game Window
        }
    }
}
