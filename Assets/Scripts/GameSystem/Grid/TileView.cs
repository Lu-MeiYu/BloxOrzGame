using UnityEngine;
/// <summary>
/// �޲z��ӿj�檺�i���Ƹ��
/// </summary>
[RequireComponent(typeof(MeshRenderer))]
public class TileView : MonoBehaviour, IPoolable
{
    public TileType Type;
    private MeshRenderer _meshRenderer;
    public void OnPoolCreate()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        gameObject.SetActive(false);
    }

    public void OnPoolGet()
    {
        gameObject.SetActive(true);
    }

    public void OnPoolReturn()
    {
        gameObject.SetActive(false);
    }

    public void SetColor(Color color)
    {
        _meshRenderer.material.color = color;
    }
}
