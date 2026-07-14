using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private Sprite[] projectileAnimation;
    
    private Animate _an;
    
    private void Awake()
    {
        _an = GetComponent<Animate>();
        _an.UpdateState("default", projectileAnimation, false, () => { Destroy(gameObject); });
    }
}