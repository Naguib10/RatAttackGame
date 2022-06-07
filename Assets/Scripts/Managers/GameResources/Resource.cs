using UnityEngine;

[CreateAssetMenu(menuName = "Resource", fileName = "New Resource")]
public class Resource : ScriptableObject
{
    public string resourceName;
    public Sprite resourceSprite;
}