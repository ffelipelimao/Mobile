using Core;
using UnityEngine;

public class CollectableManager : Singleton<CollectableManager>
{
    public ScriptableObjectInt coins;

    void Start()
    {
        Reset();
    }
    void Reset()
    {
        coins.value = 0;
    }

    public void AddCoins(int amount=1)
    {
        coins.value+= amount;
        UpdateUI();
    }

    void UpdateUI()
    {
        //UIInGameManager.UpdateTextCoins(coins.value.ToString());
    }
}
