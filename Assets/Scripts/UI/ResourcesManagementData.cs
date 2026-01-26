using UnityEngine;

[System.Serializable]
public struct ManagementResources
{
    public float energy,food,oxygen;

    public float energyDiffPerDay,foodDiffPerPerson, oxygenDiffPerPerson;
}

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
        managementResources.oxygen -= managementResources.oxygenDiffPerPerson;
        managementResources.energy -= managementResources.energyDiffPerDay;
        managementResources.food -= managementResources.foodDiffPerPerson;
    }

    private void OnDestroy()
    {
        GameManager.Instance.OnDayChange -= OnNextDay;
    }
}
