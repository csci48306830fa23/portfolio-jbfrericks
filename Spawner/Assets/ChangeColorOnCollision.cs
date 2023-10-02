using UnityEngine;

public class ChangeColorOnCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        ChangeColor();
    }

    private void ChangeColor()
    {
        Renderer rend = GetComponent<Renderer>();
        if (rend != null)
        {
            rend.material.color = new Color(Random.value, Random.value, Random.value);
        }
    }
}
