using System;
using UnityEngine;

public class SeedPlant : MonoBehaviour
{
    public void PlantGrow()
    {
        if (GameManager.Instance.CurrentClimbSeeds() > 0)
        {
            gameObject.tag = "Planted";
            Debug.Log("Tag = planted");
            GameManager.Instance.RemoveClimbSeed();

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
        else if (GameManager.Instance.CurrentWaterSeeds() > 0)
        {
            gameObject.tag = "Planted";
            Debug.Log("Tag = planted");
            GameManager.Instance.RemoveWaterSeed();

            for (int i = 0; i < transform.childCount; i++)
            {
                Transform lilyVisualChild = transform.GetChild(i);
                Debug.Log("Før endring");

                if (lilyVisualChild.CompareTag("WaterLily"))
                {
                    Debug.Log("Etter funn av WaterLily");
                    lilyVisualChild.GetChild(0).gameObject.SetActive(true);
                    Debug.Log("Etter endring av barn til WaterLily");
                    break;
                }
            }
        }
        else
        {
            Debug.Log("You have no seeds to plant");
            // Legge til en beskjed i UI
        }
    }
}
