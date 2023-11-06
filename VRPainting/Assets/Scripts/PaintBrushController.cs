using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using VelUtils;

using UnityEngine.UI;

public class PaintbrushController : MonoBehaviour
{
    public GameObject paintPrefab;
    public Transform brushTip;
    public Side side = Side.Right;
    public float brushSize = 0.01f;
    public float sizeChangeRate = 0.01f;

    public Color currentBrushColor;

    public TextMeshProUGUI brushSizeText;
    public Image brushColorImage;

    void Update()
    {
        if (InputMan.Button2Down(side)) 
        {
            Draw();
        }
        if (InputMan.Button1Down(Side.Left))
        {
            ChangeBrushSize(sizeChangeRate);
        }
        if (InputMan.Button2Down(Side.Left))
        {
            ChangeBrushSize(-sizeChangeRate);
        }
        UpdateBrushUI();
    }

    void Draw()
    {
        GameObject paint = Instantiate(paintPrefab, brushTip.position, Quaternion.identity);
        paint.transform.localScale = Vector3.one * brushSize;
    }
    public void ChangeBrushSize(float change)
    {
        brushSize += change;
        brushSize = Mathf.Max(0.01f, brushSize); 
    }

    void UpdateBrushUI()
    {
        brushSizeText.text = "Size: " + brushSize.ToString("F2"); // F2 to format the size with 2 decimal places
        brushColorImage.color = currentBrushColor; // Assuming you have a variable for the current color
    }

}