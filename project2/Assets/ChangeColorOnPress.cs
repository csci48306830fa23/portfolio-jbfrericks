using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeColorOnPress : MonoBehaviour
{

    public GameObject cube;
    public Button button;
    public Renderer rend;

    // Start is called before the first frame update
    void Start()
    {
        rend = cube.GetComponent<Renderer>();
        button = GetComponent<Button>();
        button.onClick.AddListener(changeColor);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void changeColor()
    {
        Color randomColor = new Color(
            Random.Range(0f, 1f),
            Random.Range(0f, 1f),
            Random.Range(0f, 1f)
        );
        rend.sharedMaterial.color = randomColor;
    }

}
