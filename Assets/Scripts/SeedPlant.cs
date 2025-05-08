using System;
using UnityEngine;

public class SeedPlant : MonoBehaviour
{
    // private string earthOrWater = "Nothing";
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    public void Plant()
    {
        // Det optimale for spillet i sin heltet, utenom demoen
        // ... hadde vært å i tillegg sjekke hvilken type underlag det plantes på, for å bestemme typen plante
        // Her sjekker vi bare på om det finnes frø, fordi det i demoen vil finnes kun det ene eller det andre frøet
        // ... man har i praksis kun en av typene frø om gangen i demoen

        if (GameManager.Instance.CurrentClimbSeeds() > 0)
        {
            /*earthOrWater = "Water"; // betyr at vi planter på vann
            Debug.Log("Planting in water");*/

            for (int i = 0; i < transform.childCount; i++)
            {
                Transform childWithTag = transform.GetChild(i);

                if (childWithTag.CompareTag("ClimbPlant"))
                {
                    childWithTag.GetChild(0).gameObject.SetActive(true);
                    break;
                }
            }
            // Få child-objektet som er planten til å vokse med en gang?
            // Kanskje bare en if? Som sier:
            // Legg til child-objekt med tag: Plante :)
        }
        /*if (GameManager.Instance.CurrentWaterSeeds() > 0)
        {
            if(childWithTag.CompareTag("WaterLily"))
                {
                    childWithTag.gameObject.SetActive(true);
                    break;
                }

        }*/
        else
        {
            Debug.Log("You have no seeds to plant");
            // Legge til en beskjed som 
        }
    }
    /*public string EarthOrWater()
    {
        return earthOrWater; // Gjør variabelen tilgjengelig
    }*/
}
