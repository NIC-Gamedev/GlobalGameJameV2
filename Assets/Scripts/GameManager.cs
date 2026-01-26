using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int currDay;
    public Action<int> OnDayChange;

    public static GameManager Instance;

    private void Awake()
    {
        if(Instance == null) 
            Instance = this;
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        VariableStore.CreateVariable("currDay", currDay, () => currDay, value => 
        { 
            currDay = value;
            OnDayChange?.Invoke(currDay);
        });
    }

    public void NextDay()
    {
        currDay++;
    }
}
