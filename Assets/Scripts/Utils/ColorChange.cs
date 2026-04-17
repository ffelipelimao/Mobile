using UnityEngine;
using DG.Tweening;


[RequireComponent(typeof(MeshRenderer))]
public class ColorChange : MonoBehaviour
{

    public float duration = 0.2f;
    public MeshRenderer mesh;

    public Color startColor = Color.white;
    private Color _correctColor;

    void OnValidate()
    {
        mesh = GetComponent<MeshRenderer>();
    }

    void Start()
    {
        _correctColor = mesh.materials[0].GetColor("_BaseColor");
        LerpColor();
    }

    void LerpColor()
    {
        mesh.materials[0].SetColor("_BaseColor", startColor);
        mesh.materials[0].DOColor(_correctColor, duration).SetDelay(0.5f);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            LerpColor();
        }
    }

}
