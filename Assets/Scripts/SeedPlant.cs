using System;
using UnityEngine;

public class SeedPlant : MonoBehaviour
{
    public void Plant()
    {
        // Det optimale for spillet i sin heltet, utenom demoen
        // ... hadde v�rt � i tillegg sjekke hvilken type underlag det plantes p�, for � bestemme typen plante
        // Her sjekker vi bare p� om det finnes fr�, fordi det i demoen vil finnes kun det ene eller det andre fr�et
        // ... man har i praksis kun en av typene fr� om gangen i demoen

        if (GameManager.Instance.CurrentClimbSeeds() > 0)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                Transform plantVisualChild = transform.GetChild(i);

                if (plantVisualChild.CompareTag("ClimbPlant"))
                {
                    plantVisualChild.GetChild(0).gameObject.SetActive(true);
                    break;
                }
            }
        }
        /*if (GameManager.Instance.CurrentWaterSeeds() > 0)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                Transform plantVisualChild = transform.GetChild(i);

                if (plantVisualChild.CompareTag("WaterLily"))
                {
                    plantVisualChild.GetChild(0).gameObject.SetActive(true);
                    break;
                }
            }
        }*/ // Kode til senere
        else
        {
            Debug.Log("You have no seeds to plant");
            // Legge til en beskjed i UI
        }
    }
}
