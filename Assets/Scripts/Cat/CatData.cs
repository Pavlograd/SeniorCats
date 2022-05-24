using UnityEngine;

[CreateAssetMenu(fileName = "CatData", menuName = "Data/CatData")]
public class CatData : ScriptableObject
{
    public StructCat[] cats;
    public Vector2 limitsX;
    public Vector2 limitsY;
}
