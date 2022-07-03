using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameBoard : MonoBehaviour
{
    public Sprite[] images;
    public int xCount = 3;
    public int yCount = 4;
    public Transform boardParentTr;

    [ContextMenu("SetImage")]
    void SetImage()
    {
        DeleteOldImage(boardParentTr);

        for (int y = 0; y < yCount; y++)
        {
            for (int x = 0; x < xCount; x++)
            {
                string name = $"x:{x}_y:{y}";
                var newGo = new GameObject(name);
                newGo.transform.SetParent(boardParentTr);
                newGo.transform.localScale = Vector3.one;
                Image image = newGo.AddComponent<Image>();
                int imageIndex = y * xCount + x;
                image.sprite = images[imageIndex];
            }
        }
    }

    private void DeleteOldImage(Transform deleteChildTr)
    {
        var allChildImages = deleteChildTr.GetComponentsInChildren<Image>(true);
        foreach (var item in allChildImages)
        {
            if(Application.isPlaying)
                Destroy(item.gameObject);
            else
                DestroyImmediate(item.gameObject, true);
        }
    }
}
