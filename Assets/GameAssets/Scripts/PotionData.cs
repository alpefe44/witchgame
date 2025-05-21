using UnityEngine;



[CreateAssetMenu(fileName = "PosionData", menuName = "PosionData", order = 0)]
public class PotionData : ScriptableObject
{
    public string potionName;
    public string description;
    public Sprite sprite;
}
