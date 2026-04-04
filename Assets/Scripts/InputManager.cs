using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private PlayerControllrs controls;

    public InputAction HorizontalMov;

    private void Awake()
    {
        controls = new PlayerControllrs();
        HorizontalMov = controls.InGame.HorizontalMov;
    }

    private void OnEnable()
    {
        controls.Enable(); // 🔥 activás TODO el mapa
    }

    private void OnDisable()
    {
        controls.Disable();
    }
}