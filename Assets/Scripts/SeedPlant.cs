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
        // ... hadde v�rt � i tillegg sjekke hvilken type underlag det plantes p�, for � bestemme typen plante
        // Her sjekker vi bare p� om det finnes fr�, fordi det i demoen vil finnes kun det ene eller det andre fr�et
        // ... man har i praksis kun en av typene fr� om gangen i demoen

        if (GameManager.Instance.CurrentClimbSeeds() > 0)
        {
            /*earthOrWater = "Water"; // betyr at vi planter p� vann
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
            // F� child-objektet som er planten til � vokse med en gang?
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
        return earthOrWater; // Gj�r variabelen tilgjengelig
    }*/
}
