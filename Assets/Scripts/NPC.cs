using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour, IInteractable
{
    public NPCDialogue dialogueData;
    public GameObject dialoguePanel;
    public TMP_Text dialogueText, nameText;

    private int dialogueIndex;
    private bool isTyping, isDialogueActive;

    public bool canInteract()
    {
        return !isDialogueActive;
    }

    public void interact()
    {
        if(dialogueData == null) // Verifica se a data não está vazia
        {
            return;
        }
        else if (isDialogueActive == true) // Se for true (não vai ser no inicio) chama o proximo dialogo
        {
            NextLine();
        }
        else
        {
            StartDialogue(); // Começa o dialogo
        }
    }

    void StartDialogue()
    {
        isDialogueActive = true;
        dialogueIndex = 0;

        nameText.SetText(dialogueData.npcName);

        dialoguePanel.SetActive(true); // Faz o painel de dialogo aparecer

        StartCoroutine(TypeLine());
    }

    void NextLine() // Passa para o proximo dialogo
    {
        if (isTyping == true)
        {
            StopAllCoroutines();
            dialogueText.SetText(dialogueData.dialogueLines[dialogueIndex]);
            isTyping = false;
            return;
        }
        else if(dialogueIndex + 1 < dialogueData.dialogueLines.Length)
        {
            dialogueIndex++;
            StartCoroutine(TypeLine()); // Se tiver uma nova linha, escreva nova linha
        }
        else
        {
            EndDialogue();
        }
    }

    IEnumerator TypeLine()
    {
        isTyping = true;
        dialogueText.SetText("");

        foreach (char letter in dialogueData.dialogueLines[dialogueIndex]) // Primeira linha do dialogo
        {
            dialogueText.text += letter; // Passa por todas os caracteres do dialogo.
            yield return new WaitForSeconds(dialogueData.typingSpeed); // Adiciona um delay apos cada letra com base na variavel typingSpeed
        }

        isTyping = false;

        if(dialogueData.autoProgressLines.Length > dialogueIndex && dialogueData.autoProgressLines[dialogueIndex])
        {
            yield return new WaitForSeconds(dialogueData.autoProgressDelay); // Adiciona um delay na troca de dialogos
            NextLine(); 
        }
    }

    public void EndDialogue() // Acaba o dialogo (COMEÇA A PORRADARIA)
    {
        StopAllCoroutines();
        isDialogueActive = false;
        dialogueText.SetText("");
        dialoguePanel.SetActive(false);
    }
}
