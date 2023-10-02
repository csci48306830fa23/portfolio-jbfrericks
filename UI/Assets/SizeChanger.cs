using UnityEngine;
using UnityEngine.UI;

public class SizeChanger : MonoBehaviour
{
    public Slider sizeSlider;  
    public Transform objectToResize;
    public GameObject cube;
    private Vector3 initialScale; 

    void Start()
    {
        initialScale = objectToResize.localScale; 

        sizeSlider.onValueChanged.AddListener(OnSliderValueChanged);  

     
    }

    void OnSliderValueChanged(float value)
    {
        objectToResize.localScale = initialScale * value; 
    }
}
