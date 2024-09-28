using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float moveSpeed = 10f; // Prêdkoœæ poruszania kamery
    public float fastMoveMultiplier = 3f; // Mno¿nik szybszego ruchu kamery przy naciœniêciu Shifta
    public float zoomSpeed = 10f; // Prêdkoœæ przybli¿ania/oddalania kamery
    public float minZoom = 5f; // Minimalny zoom
    public float maxZoom = 20f; // Maksymalny zoom

    private Camera cam;

    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        // Ustalanie prêdkoœci poruszania siê
        float currentMoveSpeed = moveSpeed;

        // Sprawdzanie czy Shift jest wciœniêty, aby zwiêkszyæ prêdkoœæ poruszania siê
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            currentMoveSpeed *= fastMoveMultiplier;
        }

        // Poruszanie kamer¹ za pomoc¹ WSAD
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        transform.Translate(move * currentMoveSpeed * Time.deltaTime, Space.World);

        // Zoomowanie za pomoc¹ rolki myszki
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        float newZoom = cam.orthographicSize - scroll * zoomSpeed;

        // Ograniczanie zoomu
        cam.orthographicSize = Mathf.Clamp(newZoom, minZoom, maxZoom);
    }
}
