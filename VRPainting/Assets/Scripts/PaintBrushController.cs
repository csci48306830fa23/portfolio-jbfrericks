using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VelUtils;

public class PaintbrushController : MonoBehaviour
{
    public GameObject paintPrefab;
    public Transform brushTip;
    public Side side = Side.Right;
    public float brushSize = 0.01f;
    public float sizeChangeRate = 0.01f;

    void Update()
    {
        if (InputMan.Button2Down(side)) // Change to your VR controller's button input
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
}