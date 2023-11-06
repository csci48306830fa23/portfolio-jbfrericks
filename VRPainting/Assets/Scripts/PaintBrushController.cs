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
    public Material brushMaterial;

    public TextMeshProUGUI brushSizeText;
    public Image brushColorImage;

    public string camName = "World Mouse UI Camera";
    public Canvas canvas;

    void Start()
    {
        Camera uiCamera = GameObject.Find(camName).GetComponent<Camera>();
        canvas.worldCamera = uiCamera;
    }
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
        Renderer paintRenderer = paint.GetComponent<Renderer>();
        paintRenderer.material = new Material(brushMaterial); 
        paintRenderer.material.color = currentBrushColor;
        paint.transform.localScale = Vector3.one * brushSize;
    }
    public void ChangeBrushSize(float change)
    {
        brushSize += change;
        brushSize = Mathf.Max(0.01f, brushSize); 
    }
    public void SetBrushColorFromButton()
    {
        Image buttonImage = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.GetComponent<Image>();
        ChangeBrushColor(buttonImage.color);
    }
    public void ChangeBrushColor(Color newColor)
    {
        currentBrushColor = newColor;
        brushMaterial.color = newColor; 
        UpdateBrushUI(); 
    }

    void UpdateBrushUI()
    {
        brushSizeText.text = "Size: " + brushSize.ToString("F2"); 
        brushColorImage.color = currentBrushColor; 
    }

}