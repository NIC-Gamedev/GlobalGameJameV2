using Sirenix.OdinInspector;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
[DefaultExecutionOrder(10)]
public class BreakerManager : SerializedMonoBehaviour
{
    public static BreakerManager Instance;

    public Dictionary<string,SlorOne> breackAbleSlot;

    public SlorOne foodMaker;

    private void Awake()
    {
        if(Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        GameManager.Instance.OnDayChange += OnNextDay;
        OnNextDay(GameManager.Instance.currDay);
    }

    public void OnNextDay(int day)
    {
        if(day == 0)
        {
            for (int i = 0; i < 4; i++)
                DestroyRandom();
        }

        for (int i = 0; i < 2; i++)
            DestroyRandom();

        foodMaker.isWorking = false;
    }

    public void DestroyRandom()
    {
        int rand = Random.Range(0,breackAbleSlot.Count);
        var element = breackAbleSlot.ElementAt(rand);
        element.Value.isWorking = false;
    }

    private void OnDestroy()
    {
        GameManager.Instance.OnDayChange -= OnNextDay;
    }
}
