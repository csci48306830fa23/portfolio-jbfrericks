using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using VelUtils;

using UnityEngine.UI;
using System.Linq;
using VelUtils.VRInteraction;

public class PaintbrushController : MonoBehaviour
{
    public GameObject paintPrefab;
    public GameObject paintPrefabFlat;
    public GameObject paintPrefabSphere;
    public List<GameObject> paints = new List<GameObject>();
    public GameObject[] additionalButtons;
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
    public VRMoveable moveable;
    public Rigidbody rb;
    public Vector3 initPos;
    public Vector3 initRot;
    public Vector3 pos;
    public Vector3 rot;

    public Transform controllerTransform;
    public Vector3 initialHandPosition;
    public Vector3 initialScale;
    private bool isStretched = false;


    void Start()
    {
        //Camera uiCamera = GameObject.Find(camName).GetComponent<Camera>();
        //canvas.worldCamera = uiCamera;
        paintPrefab = paintPrefabSphere;
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
    private void FixedUpdate()
    {
       
        foreach (GameObject paint in paints)
        {
            VRMoveable moveable = paint.GetComponent<VRMoveable>();
            if (moveable.GrabbedBy != null)
            {
                if (InputMan.Button1Down(side))
                {
                    isStretched = !isStretched;
                    if (isStretched)
                    {
                        initialHandPosition = controllerTransform.position;
                        initialScale = transform.localScale;
                    }
                }
                if (isStretched)
                {
                    StretchPaint(paint);
                }
                else
                {
                    Debug.Log("grabbed");
                    paint.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                }
            }
            else
            {
                paint.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            }
        }
    }

    void StretchPaint(GameObject paint)
    {
        if (paint == null) return;
        float scaleFactor = (controllerTransform.position.y - initialHandPosition.y) + 3;
        paint.transform.localScale = new Vector3(initialScale.x, initialScale.y * scaleFactor, initialScale.z);
    }
    void Draw()
    {
        
        GameObject paint = Instantiate(paintPrefab, brushTip.position, brushTip.rotation);
        paint.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        Renderer paintRenderer = paint.GetComponent<Renderer>();
        paintRenderer.material = new Material(brushMaterial);
        paintRenderer.material.color = currentBrushColor;
        paint.transform.localScale = Vector3.one * brushSize;
        paints.Add(paint);
    }
    public void ChangeBrushSize(float change)
    {
        brushSize += change;
        brushSize = Mathf.Max(0.01f, brushSize);
    }
    public void SetBrushColorFromButton()
    {
        Image buttonImage = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.GetComponent<Image>();
        if (paintPrefab.transform.childCount > 0)
        {
            foreach (Transform child in paintPrefab.transform)
            {
                ChangeBrushColor(buttonImage.color);
            }
        }
        else
        {
            ChangeBrushColor(buttonImage.color);
        }
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

    public void SphereBrush()
    {
        paintPrefab = paintPrefabSphere;
    }
    public void FlatBrush()
    {
        paintPrefab = paintPrefabFlat;
    }
    public void ChangePaintPrefab()
    {
        Debug.Log("change");
    }
    private Coroutine hideOptionsCoroutine;

    public void ShowOptions()
    {
        foreach (var button in additionalButtons)
        {
            button.SetActive(true);
        }
        if (hideOptionsCoroutine != null)
        {
            StopCoroutine(hideOptionsCoroutine);
        }
    }

    public void StartHidingOptions()
    {
        if (hideOptionsCoroutine != null)
        {
            StopCoroutine(hideOptionsCoroutine);
        }
        hideOptionsCoroutine = StartCoroutine(HideOptionsWithDelay());
    }

    private IEnumerator HideOptionsWithDelay()
    {
        yield return new WaitForSeconds(2f);
        foreach (var button in additionalButtons)
        {
            button.SetActive(false);
        }
    }
}