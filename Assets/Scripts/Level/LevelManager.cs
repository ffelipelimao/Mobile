using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LevelManager : MonoBehaviour
{
    public Transform container;


    public List<LevelSectionsBasedSetup> levelSectionsBasedSetups;
    private LevelSectionsBasedSetup _currSetup;
    public float timeToPieces = 0.3f;


    private List<LevelPieceBase> _spawnedPieces = new();
    [SerializeField] private int _index;
    private GameObject _currentLevel;


    public float scaleDuration = 0.2f;
    public float timeBetweenPieces = 0.1f;
    public Ease ease = Ease.OutBack;

    void Awake()
    {
        //SpawnNextLevel();
        CreateLevel();
    }

    // Update to Debug
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            CreateLevel();

        }
    }

    void CreateLevel()
    {
        ClearSpawnedPieces();

        if (_currSetup != null)
        {
            _index++;
            if (_index >= levelSectionsBasedSetups.Count)
            {
                _index = 0;
            }
        }

        Debug.Log(_index);

        _currSetup = levelSectionsBasedSetups[_index];

        for (int i = 0; i < _currSetup.piecesNumberStart; i++)
        {
            CreateLevelPiece(_currSetup.levelPiecesStart);
        }

        for (int i = 0; i < _currSetup.piecesNumber; i++)
        {
            CreateLevelPiece(_currSetup.levelPieces);
        }
        for (int i = 0; i < _currSetup.piecesNumberEnd; i++)
        {
            CreateLevelPiece(_currSetup.levelPiecesEnd);
        }

        ColorManager.Instance.ChangeColorByType(_currSetup.artType);
        StartCoroutine(ScalePiecesByTime());
        //StartCoroutine(CreateLevelCoroutine());
    }

    void CreateLevelPiece(List<LevelPieceBase> list)
    {
        var piece = list[Random.Range(0, list.Count)];
        var spawnedPiece = Instantiate(piece, container);

        if (_spawnedPieces.Count > 0)
        {
            var lastPiece = _spawnedPieces[_spawnedPieces.Count - 1];
            spawnedPiece.transform.position = lastPiece.endPiece.position;
        }

        foreach (var p in spawnedPiece.GetComponentsInChildren<ArtPiece>())
        {
            p.ChangePiece(ArtManager.Instance.GetSetupByType(_currSetup.artType).gameObject);
        }

        _spawnedPieces.Add(spawnedPiece);
    }


    private void ClearSpawnedPieces()
    {
        // TODO try use while
        for (int i = _spawnedPieces.Count - 1; i >= 0; i--)
        {
            Destroy(_spawnedPieces[i].gameObject);
        }

        _spawnedPieces.Clear();
    }

    IEnumerator CreateLevelCoroutine()
    {
        _spawnedPieces = new List<LevelPieceBase>();
        for (int i = 0; i < _currSetup.piecesNumber; i++)
        {
            CreateLevelPiece(_currSetup.levelPieces);
            yield return new WaitForSeconds(timeToPieces);
        }
    }
    IEnumerator ScalePiecesByTime()
    {
        foreach (var p in _spawnedPieces)
        {
            p.transform.localScale = Vector3.zero;
        }

        // wait a frame
        yield return null;

        for (int i = 0; i < _spawnedPieces.Count; i++)
        {
            _spawnedPieces[i].transform.DOScale(1, scaleDuration).SetEase(ease);
            yield return new WaitForSeconds(timeBetweenPieces);
        }

        CoinAnimationManager.Instance.StartAnimations();
    }

    /*void SpawnNextLevel()
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
    */
}
