using System.Collections.Generic;
using Core;
using UnityEngine;
using DG.Tweening;
using System.Linq;
using System.Collections;

public class CoinAnimationManager : Singleton<CoinAnimationManager>
{
    public List<ItemCollactableCoin> items;

    public float scaleDuration = 0.2f;
    public float timeBetweenPieces = 0.1f;
    public Ease ease = Ease.OutBack;

    void Start()
    {
        items = new List<ItemCollactableCoin>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            StartAnimations();
        }
    }

    public void RegisterCoin(ItemCollactableCoin i)
    {
        if (!items.Contains(i))
        {
            items.Add(i);
            i.transform.localScale = Vector3.zero;
        }
    }

    public void StartAnimations()
    {
        StartCoroutine(ScalePiecesByTime());
    }

    IEnumerator ScalePiecesByTime()
    {
        foreach (var p in items)
        {
            p.transform.localScale = Vector3.zero;
        }

        Sort();
        // wait a frame
        yield return null;

        for (int i = 0; i < items.Count; i++)
        {
            items[i].transform.DOScale(1, scaleDuration).SetEase(ease);
            yield return new WaitForSeconds(timeBetweenPieces);
        }
    }

    void Sort()
    {
        items = items.OrderBy(x => Vector3.Distance(this.transform.position, x.transform.position)).ToList(); ;
    }
}
