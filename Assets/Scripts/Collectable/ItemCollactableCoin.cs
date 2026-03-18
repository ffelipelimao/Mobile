using UnityEngine;

public class ItemCollactableCoin : ItemCollectableBase
{
    public Collider2D coll;
    protected override void OnCollect()
    {
        base.OnCollect();
        CollectableManager.Instance.AddCoins();
        coll.enabled = false;
    }
}
