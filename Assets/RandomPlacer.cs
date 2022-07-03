using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPlacer : MonoBehaviour
{
    public Transform[] items;
    
    [ContextMenu("랜덤하게 배치")]
    void SetRandomPlace()
    {
        foreach(var item in items)
        {
            item.transform.position =
                new Vector3(Random.Range(0, Camera.main.pixelWidth),
                            Random.Range(0, Camera.main.pixelHeight));
        }
    }
}
