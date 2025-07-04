using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InteractionDetector : MonoBehaviour
{
    private IInteractable interactableInRange = null; // Objeto interativo mais proximo
    public GameObject interactionIcon; // Icone de exclama��o
    void Start()
    {
        interactionIcon.SetActive(false); // Desaparece com o icone de exclama��o
    }

    public void OnInteract(InputAction.CallbackContext contexto)
    {
        if (contexto.performed && interactableInRange != null && interactableInRange.canInteract()) // Tecla pressionada + Interagivel != Nulo + Interagil pode interagir
        {
            interactableInRange?.interact();
        } 
    }

    private void OnTriggerEnter2D(Collider2D collision) // Detecta que entrou em uma hitbox triggerando o codigo
    {
        if (collision.TryGetComponent(out IInteractable interactable))
        {
            interactableInRange = interactable; // Sinaliza que pode interagir
            interactionIcon.SetActive(true); // Faz aparecer o icone de exclama��o
        } 
    }

    private void OnTriggerExit2D(Collider2D collision) // Trigger de saida da hitbox
    {
        if (collision.TryGetComponent(out IInteractable interactable) && interactable == interactableInRange)
        {
            interactableInRange = null; // Seta objeto interagil para n�o interagivel
            interactionIcon.SetActive(false); // Retira o icone de exclama��o
        }
    }
}
