using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Object : MonoBehaviour
{
    public bool isClicked;

    public Vector3 dir;

    public GameObject vfxCompleted;

    private void Awake()
    {
        isClicked = false;
    }

    private void OnMouseDown()
    {
        if (isClicked) return;

        isClicked = true;

        transform.DOMove(dir, 1f).OnComplete(() => {
            PlayVFX();
            GameManager.Instance.levels[GameManager.Instance.GetCurrentIndex()].objects.Remove(gameObject);
            GameManager.Instance.levels[GameManager.Instance.GetCurrentIndex()].CheckAll();
        });
    }

    public void PlayVFX()
    {
        GameObject vfx = Instantiate(vfxCompleted, transform.position, Quaternion.identity) as GameObject;
        Destroy(vfx, 1f);
    }
}