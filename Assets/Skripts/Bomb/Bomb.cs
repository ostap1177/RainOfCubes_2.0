using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class Bomb : MonoBehaviour
{
    [SerializeField] private BombeDestroyer _bombeDestroyer;

    private void Start()
    {
        _bombeDestroyer.ChangeTransparency();
    }
}
