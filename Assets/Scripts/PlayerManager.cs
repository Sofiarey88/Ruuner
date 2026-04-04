using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public GameManager gameManager;

    private InputManager inputManager;

    public float laneDistance = 2f;
    public float laneChangeSpeed = 10f;

    private int currentLane = 0; // -1 izquierda, 0 centro, 1 derecha

    void Start()
    {
        inputManager = GetComponent<InputManager>();
    }

    void Update()
    {
        ChangeLane();
    }

    void ChangeLane()
    {
        // Detecta solo cuando apretás
        if (inputManager.HorizontalMov.WasPressedThisFrame())
        {
            float input = inputManager.HorizontalMov.ReadValue<float>();

            if (input > 0 && currentLane < 1)
                currentLane++;

            if (input < 0 && currentLane > -1)
                currentLane--;
        }

        Vector3 target = new Vector3(
            currentLane * laneDistance,
            transform.position.y,
            transform.position.z // 🔥 no se mueve en Z
        );

        transform.position = Vector3.Lerp(
            transform.position,
            target,
            laneChangeSpeed * Time.deltaTime
        );
    }


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("TOCO ALGO");

        if (other.CompareTag("obstaculo"))
        {
            Debug.Log("CHOQUE CON OBSTACULO");

            Rigidbody rb = other.gameObject.AddComponent<Rigidbody>();
            rb.AddForce(Vector3.up * 300f);

            gameManager.GameOver();
        }
    }
}
