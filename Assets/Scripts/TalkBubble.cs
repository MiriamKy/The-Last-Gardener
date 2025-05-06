using UnityEngine;

public class TalkBubble : MonoBehaviour
{
    // Referanse til Canvaset
    [SerializeField] private GameObject talkBubble;

    // Referanse til PlayerMovement for � f� tak i Eventet
    [SerializeField] private PlayerMovement player;

    // Referanse til NPC collideren for � se om vi er n�re nok til � interagere
    [SerializeField] private NPCDetect NPC;

    // Sjekke om canvaset er �pent eller ikke
    private bool isTalkBubbleActive = false;

    private void Start()
    {
        // Lytter etter event Interact
        player.OnInteractAction += Player_OnInteractAction;
    }

    private void Player_OnInteractAction()
    {
        // Alt inni her skjer hver gang Interact action blir trigget

        // Hvis spilleren er n�re NPC og menyen ikke er aktiv
        if(NPC.PlayerClose() && isTalkBubbleActive == false)
        {
            // Aktivere TalkBubble
            talkBubble.SetActive(true);
            // Stoppe tiden
            Time.timeScale = 0;
            // Sette isTalkBubbleActive til true
            isTalkBubbleActive = true;
        } else
        {
            // Deaktivere TalkBubble
            talkBubble.SetActive(false);
            // Starte tiden
            Time.timeScale = 1;
            // Sette isTalkBubbleActive til false
            isTalkBubbleActive = false;
        }
    }
}
