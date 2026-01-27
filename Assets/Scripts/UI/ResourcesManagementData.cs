using UnityEngine;

[System.Serializable]
public struct ManagementResources
{
    public float energy,food,oxygen;

    public float energyDiffPerDay,foodDiffPerPerson, oxygenDiffPerPerson;
}

[DefaultExecutionOrder(-1)]
public class ResourcesManagementData : MonoBehaviour
{
    public static ResourcesManagementData Instance;
    public ManagementResources managementResources = new();
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void OnNextDay(int currDay)
    {
        var bm = BreakerManager.Instance;

        managementResources.food += bm.foodMaker.transform.childCount > 0 ?
            Mathf.Min(managementResources.food, 30) : 0;

        foreach (var item in bm.breackAbleSlot.Keys)
        {
            EnergyLoss("Engine");
        }
        managementResources.oxygen -= managementResources.oxygenDiffPerPerson;
        managementResources.energy -= managementResources.energyDiffPerDay;
        managementResources.food -= managementResources.foodDiffPerPerson;
    }

    private void EnergyLoss(string name)
    {
        var bm = BreakerManager.Instance;
        if (!bm.breackAbleSlot[name].isWorking)
        {
            if (bm.breackAbleSlot[name].transform.childCount == 0)
            {
                managementResources.energy -= managementResources.energyDiffPerDay;
            }
        }
    }

    private void OnDestroy()
    {
        GameManager.Instance.OnDayChange -= OnNextDay;
    }
}
