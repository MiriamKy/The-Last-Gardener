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
