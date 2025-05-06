using UnityEngine;

public class NPCDetect : MonoBehaviour
{
    // Variabel som forteller om spilleren er innenfor collideren
    private bool playerClose = false;

    private void OnTriggerEnter(Collider other)
    {
        //Hvis spilleren v�r g�r inn i triggeren, sett playerClose til true
        if (other.CompareTag("Player")) //"Player" er navnet p� taggen, husk � tagge
        {
            playerClose = true;
        }
    }

    // Setter boolen til false n�r spilleren g�r ut av collideren
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerClose = false;
        }
    }

    // Gj�re informasjonen i variabelen tilgjengelig for andre scripts
    public bool PlayerClose()
    {
        return playerClose;
    }

}
