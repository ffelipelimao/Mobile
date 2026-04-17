using UnityEngine;
using DG.Tweening;

public class BouncerHelper : MonoBehaviour

{

    public float scaleDuration = 0.2f;
    public float scaleBounce = 0.1f;
    public Ease ease = Ease.OutBack;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Bounce();
        }
    }


    public void Bounce()
    {
        transform.DOScale(scaleBounce, scaleDuration).SetEase(ease).SetLoops(2, LoopType.Yoyo);
    }
}
