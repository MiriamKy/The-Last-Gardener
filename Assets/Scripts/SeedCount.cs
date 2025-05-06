using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SeedCount : MonoBehaviour
{
    [SerializeField] private TMP_Text climbSeedCount;
    [SerializeField] private TMP_Text waterSeedCount;

    void Update()
    {
        climbSeedCount.text = GameManager.Instance.CurrentClimbSeeds().ToString();
        waterSeedCount.text = GameManager.Instance.CurrentWaterSeeds().ToString();
    }
}
