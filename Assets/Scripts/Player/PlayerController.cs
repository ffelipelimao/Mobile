using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Lerp")]
    public Transform target;
    public float lerpSpeed = 1f;   
    public float speed = 1f;
    public string enemyTag = "Enemy";
    public string endLineTag = "EndLine";

    public GameObject endScreen;

    private Vector3 _pos;
    private bool _canRun;
    void Update()
    {
        if(!_canRun) return;
        
        _pos = target.position;
        _pos.y = transform.position.y;
        _pos.z = transform.position.z;
                
        transform.position = Vector3.Lerp(transform.position, _pos, lerpSpeed * Time.deltaTime);        
        transform.Translate(transform.forward * speed * Time.deltaTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag(enemyTag))
        {
            EndGame();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag(endLineTag))
        {
            EndGame();
        }
    }

    void EndGame()
    {
        _canRun = false;
        endScreen.SetActive(true);
    }

    public void StartRun()
    {
        _canRun = true;
    }
}
