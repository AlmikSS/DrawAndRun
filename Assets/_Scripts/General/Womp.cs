using UnityEngine;

public class Womp : MonoBehaviour
{
    [SerializeField] private GameObject _wompDeathParticleSystem;

    public delegate void OnDeath(Womp womp);
    public event OnDeath DeathEvent;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
            Death();
    }

    private void Death()
    {
        DeathEvent?.Invoke(this);
        Vector3 pos = new Vector3(transform.position.x,
            transform.position.y + 0.3f,
            transform.position.z);
        GameObject ps = Instantiate(_wompDeathParticleSystem, pos, Quaternion.identity);
        Destroy(ps, 1f);
        Destroy(gameObject);
    }
}