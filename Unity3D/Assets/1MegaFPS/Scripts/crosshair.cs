using UnityEngine;
using System.Collections;

public class crosshair : MonoBehaviour
{
    public Texture2D crosshairTexture;
    public Rect position;
    public bool visible;

    // Use this for initialization
    void Start()
    {
        position = new Rect((Screen.width - crosshairTexture.width) / 2, (Screen.height - crosshairTexture.height) / 2, crosshairTexture.width, crosshairTexture.height);
    }

    void OnGUI()
    {
        if (visible)
            GUI.DrawTexture(position, crosshairTexture);
    }
}
