using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighlightObject : MonoBehaviour
{

    public Material highlightMaterial;
    public Toggle highlightToggle;
    public Material originalMaterial;
    public Renderer objectRenderer;

    // Start is called before the first frame update
    void Start()
    {
        objectRenderer = GetComponent<Renderer>();
        originalMaterial = objectRenderer.material;

        highlightToggle.onValueChanged.AddListener(OnToggleValueChanged);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnToggleValueChanged(bool isOn)
    {
        objectRenderer.material = isOn ? highlightMaterial : originalMaterial;
    }
}
