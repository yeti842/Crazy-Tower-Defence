using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float speed = 5f;

    void Update()
    {
        // Przesuwanie kamer¹ za pomoc¹ WSAD
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(horizontal, vertical, 0) * speed * Time.deltaTime);

        // Przesuwanie kamer¹ przy trzymaniu klikniêtej rolki myszki
        if (Input.GetMouseButton(2))
        {
            Vector3 delta = Input.mousePosition - Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position -= delta * Time.deltaTime;
        }
    }
}
