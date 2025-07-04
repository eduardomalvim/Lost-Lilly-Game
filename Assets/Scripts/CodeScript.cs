using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class CodeScript : MonoBehaviour, IInteractable
{
    public string sceneToLoad;

    public GameObject codePanel;
    public TMP_Text codeText;
    public TMP_InputField code;
    private string playerCode;
    private bool isCodeActive;
    private string password = "Luz";
    private string password2 = "luz";

    public bool canInteract()
    {
        return !isCodeActive;
    }

    public void interact()
    {
        if (!isCodeActive)  // Verifica e inicia o painel do codigo
        {
            CodeStart();
            return;
        }
    }

    public void ReadStringInput() // Transforma o texto do TM para string
    {
        playerCode = code.text;
    }

    private void CodeStart()
    {
        isCodeActive = true;
        codePanel.SetActive(true);
        codeText.SetText("Insira o código aqui:");
    }

    public void ConfirmCode()
    {
        ReadStringInput();

        if (playerCode == password || playerCode == password2)
        {

            EndGame();
        }
        else
        {
            codeText.SetText("Errado!\nTente novamente.");
        }
    }


    public void CodeExit()
    {
        isCodeActive = false;
        codePanel.SetActive(false);
    }
    
    private void EndGame()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
