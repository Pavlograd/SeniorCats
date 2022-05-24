using UnityEngine;

[CreateAssetMenu(fileName = "ParralaxData", menuName = "FlappyCats/ParralaxData")]
public class ParralaxData : ScriptableObject
{
    public ParralaxElement[] elements; // All paralax elements, be careful to place in layer order
    public Vector3 offset; // size between elements
}
