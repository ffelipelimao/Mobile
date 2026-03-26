using Core;
using UnityEngine;

public class PlayerController : Singleton<PlayerController>
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
    private float _currentSpeed;
    private Vector3 _startPosition;

    public bool invincible = false;

    private void Start()
    {
        _startPosition = transform.position;
        ResetSpeed();
    }

    void Update()
    {
        if (!_canRun) return;

        _pos = target.position;
        _pos.y = transform.position.y;
        _pos.z = transform.position.z;

        transform.position = Vector3.Lerp(transform.position, _pos, lerpSpeed * Time.deltaTime);
        transform.Translate(transform.forward * _currentSpeed * Time.deltaTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag(enemyTag))
        {
            if (!invincible) EndGame();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag(endLineTag))
        {
            if (!invincible) EndGame();
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

    public void SetPowerUpText(string s)
    {
        //uiTextPowerUp.text = s;
    }
    public void PowerUpSpeedUp(float f)
    {
        _currentSpeed = f;
    }
    public void ResetSpeed()
    {
        _currentSpeed = speed;
    }

    public void SetInvincible(bool b)
    {
        invincible = b;
    }
}
