using UnityEngine;

public class ItemCollectableBase : MonoBehaviour
{
    public string compareTag = "Player";
    public ParticleSystem particlePrefab;
    public float timeToHide = 6f;
    public GameObject graphicItem;

    [Header("Sound")]
    public AudioSource audioSource;

    void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.CompareTag(compareTag))
        {
            Collect();
        }
    }
    protected virtual void Collect()
    {
        if (graphicItem != null)
        {
            graphicItem.SetActive(false);   
        }
        Invoke("HideObject", timeToHide);
        OnCollect();
    }

    private void HideObject(){
        gameObject.SetActive(false);
    }

    protected virtual void OnCollect()
    {
        if (particlePrefab != null)
        {
        ParticleSystem particle = Instantiate(
            particlePrefab,
            transform.position,
            Quaternion.identity
        );

        particle.Play();
        }

        if (audioSource != null)
        {
            audioSource.Play();
        }
    }
}
