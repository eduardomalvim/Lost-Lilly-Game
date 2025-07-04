using UnityEngine;

[CreateAssetMenu(fileName ="NewNPCDialogue", menuName ="NPC Dialogue")]
public class NPCDialogue : ScriptableObject
{
    public string npcName; 
    public string[] dialogueLines;
    public float typingSpeed = 0.05f;   // Interface para facilitar a criação de NPCs
    public bool[] autoProgressLines;
    public float autoProgressDelay = 1.5f;
}
