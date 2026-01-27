using System.Collections.Generic;
using UnityEngine;

public class BreakerManager : MonoBehaviour
{
    public static BreakerManager Instance;

    [SerializeReference]
    public Dictionary<string,SlorOne> breackAbleSlot = new Dictionary<string,SlorOne>();

    private void Awake()
    {
        if(Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }
}
