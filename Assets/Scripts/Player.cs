using UnityEngine;
using UnityEngine.InputSystem;


public class Player : MonoBehaviour
{     
    private Rigidbody2D rb;
    public float moveSpeed = 5f;
    private Vector2 moveInput;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Referencia do Player
    }

    void Update()
    {
        rb.linearVelocity = moveInput * moveSpeed;
    }

    public void Movement(InputAction.CallbackContext contexto) 
    {
        moveInput = contexto.ReadValue<Vector2>();
    }
}
