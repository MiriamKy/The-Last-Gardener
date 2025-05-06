using UnityEngine;

public class NPCDetect : MonoBehaviour
{
    // Variabel som forteller om spilleren er innenfor collideren
    private bool playerClose = false;

    private void OnTriggerEnter(Collider other)
    {
        //Hvis spilleren vår går inn i triggeren, sett playerClose til true
        if (other.CompareTag("Player")) //"Player" er navnet på taggen, husk å tagge
        {
            playerClose = true;
        }
    }

    // Setter boolen til false når spilleren går ut av collideren
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerClose = false;
        }
    }

    // Gjøre informasjonen i variabelen tilgjengelig for andre scripts
    public bool PlayerClose()
    {
        return playerClose;
    }

}
