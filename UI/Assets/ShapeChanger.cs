using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShapeChanger : MonoBehaviour
{

    public Dropdown shapeDropdown;
    public GameObject[] shapes;
    public Transform spawnPoint;
    public GameObject currentShape;
    // Start is called before the first frame update
    void Start()
    {
        shapeDropdown.onValueChanged.AddListener(OnDropdownValueChanged);

        currentShape = Instantiate(shapes[0], spawnPoint.position, spawnPoint.rotation);
    }



    // Update is called once per frame
    void Update()
    {
        
    }

    void OnDropdownValueChanged(int index)
    {
        if (currentShape != null)
        {
            Destroy(currentShape);
        }
        currentShape = Instantiate(shapes[index], spawnPoint.position, spawnPoint.rotation);
        
    }
}
