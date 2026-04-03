using Core;
using TMPro;
using UnityEngine;
using DG.Tweening;

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

    public TextMeshPro uiPowerUpText;
    [Header("Coin Collector")]
    public GameObject coinCollector;

    public AnimationManager animationManager;

    private float baseSpeedAnimation = 7;

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
            if (!invincible)
            {
                EndGame(AnimationManager.AnimationType.DEATH);
                MoveBack();
            }
        }
    }

    void MoveBack()
    {
        // will set -1 position behind
        transform.DOMoveZ(-1f, .3f).SetRelative();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag(endLineTag))
        {
            if (!invincible) EndGame();
        }
    }

    void EndGame(AnimationManager.AnimationType at = AnimationManager.AnimationType.IDLE)
    {
        _canRun = false;
        endScreen.SetActive(true);
        animationManager.Play(at);
    }

    public void StartRun()
    {
        _canRun = true;
        animationManager.Play(AnimationManager.AnimationType.RUN, _currentSpeed / baseSpeedAnimation);
    }

    public void SetPowerUpText(string s)
    {
        uiPowerUpText.text = s;
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

    public void ChangeHeight(float amount, float duration, float animationDuration, Ease ease)
    {
        transform.DOMoveY(_startPosition.y + amount, animationDuration).SetEase(ease);
    }

    public void ResetHeight()
    {
        transform.DOMoveY(_startPosition.y, .1f);
    }

    public void ChangeCoinCollectorSize(float amount)
    {
        coinCollector.transform.localScale = Vector3.one * amount;
    }
}
