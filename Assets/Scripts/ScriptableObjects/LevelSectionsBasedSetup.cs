using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "LevelSectionsBasedSetup", menuName = "Scriptable Objects/LevelSectionsBasedSetup")]
public class LevelSectionsBasedSetup : ScriptableObject
{
    public ArtManager.ArtType artType;
    public List<LevelPieceBase> levelPieces;
    public List<LevelPieceBase> levelPiecesStart;
    public List<LevelPieceBase> levelPiecesEnd;
    public int piecesNumber = 5;
    public int piecesNumberStart = 2;
    public int piecesNumberEnd = 2;

}
