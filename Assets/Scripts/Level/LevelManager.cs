using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public Transform container;
    public List<GameObject> levels;

    [SerializeField] private int _index;
    private GameObject _currentLevel;

    void Awake()
    {
        SpawnNextLevel();
    }

    void SpawnNextLevel()
    {
        if (_currentLevel != null)
        {
            Destroy(_currentLevel);
            _index++;
            if (_index > levels.Count)
            {
                _index = 0;
            }
        }
        _currentLevel = Instantiate(levels[_index], container);
        _currentLevel.transform.localPosition = Vector3.zero;
    }
}
