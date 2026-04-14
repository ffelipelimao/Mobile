using UnityEngine;
using System.Collections.Generic;
using Core;

public class ColorManager : Singleton<ColorManager>
{
    public List<Material> materials;
    public List<ColorSetup> colorsSetup;

    public void ChangeColorByType(ArtManager.ArtType artType)
    {
        var setup = colorsSetup.Find(i => i.artType == artType);
        for (int i = 0; i < materials.Count; i++)
        {
            materials[i].SetColor("_BaseColor", setup.colors[i]);
        }
    }
}


[System.Serializable]
public class ColorSetup
{
    public ArtManager.ArtType artType;
    public List<Color> colors;
}
