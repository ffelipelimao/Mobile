using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public Transform container;
    public List<GameObject> levels;

    [Header("Pieces")]
    public List<LevelPieceBase> levelPieces;
    public List<LevelPieceBase> levelPiecesStart;
    public List<LevelPieceBase> levelPiecesEnd;
    public int piecesNumber = 5;
    public int piecesNumberStart = 2;
    public int piecesNumberEnd = 2;
    public float timeToPieces = 0.3f;

    private List<LevelPieceBase> _spawnedPieces;
    [SerializeField] private int _index;
    private GameObject _currentLevel;

    void Awake()
    {
        //SpawnNextLevel();
        CreateLevel();
    }

    void CreateLevel()
    {
        _spawnedPieces = new List<LevelPieceBase>();
        for (int i = 0; i < piecesNumberStart; i++)
        {
            CreateLevelPiece(levelPiecesStart);
        }

        for (int i = 0; i < piecesNumber; i++)
        {
            CreateLevelPiece(levelPieces);
        }
        for (int i = 0; i < piecesNumberEnd; i++)
        {
            CreateLevelPiece(levelPiecesEnd);
        }

        //StartCoroutine(CreateLevelCoroutine());
    }

    void CreateLevelPiece()
    {
        var piece = levelPieces[Random.Range(0, levelPieces.Count)];
        var spawnedPiece = Instantiate(piece, container);

        if (_spawnedPieces.Count > 0)
        {
            var lastPiece = _spawnedPieces[_spawnedPieces.Count - 1];
            spawnedPiece.transform.position = lastPiece.endPiece.position;
        }

        _spawnedPieces.Add(spawnedPiece);
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

        _spawnedPieces.Add(spawnedPiece);
    }

    IEnumerator CreateLevelCoroutine()
    {
        _spawnedPieces = new List<LevelPieceBase>();
        for (int i = 0; i < piecesNumber; i++)
        {
            CreateLevelPiece();
            yield return new WaitForSeconds(timeToPieces);
        }
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
