using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Animator animator;
    private Vector2 moveInput;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();   // Pega referencia para o rb
        animator = GetComponent<Animator>(); // Mesma coisa para animação
    }


    void Update()
    {
        rb.linearVelocity = moveInput * moveSpeed;  // MovimentoPlayer = Direção * Velocidade
    }

    public void Move(InputAction.CallbackContext context)
    {
        animator.SetBool("isWalking", true);

        if (context.canceled) // Para de andar, isWalking = false
        {
            animator.SetBool("isWalking", false);
        }
        
        moveInput = context.ReadValue<Vector2>(); // Lê o Valor
        animator.SetFloat("InputX", moveInput.x); // Atribui o valor de X para InputX no animator
        animator.SetFloat("InputY", moveInput.y); // Atribui o valor de Y para InputY no animator
    }
}
