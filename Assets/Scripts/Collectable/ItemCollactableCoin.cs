using UnityEngine;

public class ItemCollactableCoin : ItemCollectableBase
{
    public Collider coll;
    public bool collect = false;
    public float lerp = 5f;
    public float minDistance = 1f;

    private void Start()
    {
        //CoinManager.Instance.RegisterCoin(this);
    }

    protected override void OnCollect()
    {
        base.OnCollect();
        coll.enabled = false;
        collect = true;
        //PlayerController.Instance.Bounce();
    }

    protected override void Collect()
    {
        OnCollect();
    }


    // Update is called once per frame
    private void Update()
    {
        if (collect)
        {
            transform.position = Vector3.Lerp(transform.position, PlayerController.Instance.transform.position, lerp * Time.deltaTime);

            if (Vector3.Distance(transform.position, PlayerController.Instance.transform.position) < minDistance)
            {
                HideItens();
                Destroy(gameObject);
            }
        }
    }
}
