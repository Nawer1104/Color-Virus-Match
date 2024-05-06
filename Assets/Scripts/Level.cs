using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Level : MonoBehaviour
{
    public List<GameObject> gameObjects;

    public List<GameObject> objects;

    public void CheckAll()
    {
        if (objects.Count > 0)
            return;

        foreach (GameObject gameObj in gameObjects)
        {
            gameObj.transform.DOScale(0f, 1f);
        }

        GameManager.Instance.CheckLevelUp();
    }    

    public static List<GameObject> GetAllChilds(GameObject Go)
    {
        List<GameObject> list = new List<GameObject>();
        for (int i = 0; i < Go.transform.childCount; i++)
        {
            list.Add(Go.transform.GetChild(i).gameObject);
        }
        return list;
    }
}
