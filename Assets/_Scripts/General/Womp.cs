using System;
using Dreamteck.Splines;
using UnityEngine;

public class Womp : MonoBehaviour
{
    [SerializeField] private GameObject _wompDeathParticleSystem;
    
    public delegate void OnDeath(Womp womp);
    public event OnDeath DeathEvent;
    public event Action GetBonusEvent; 
    
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
            Death();
        if (other.gameObject.CompareTag("Bonus"))
            GetBonusEvent?.Invoke();
    }

    private void Death()
    {
        GetComponent<SplineFollower>().enabled = false;
        DeathEvent?.Invoke(this);
        Vector3 pos = new Vector3(transform.position.x,
            transform.position.y + 0.3f,
            transform.position.z);
        GameObject ps = Instantiate(_wompDeathParticleSystem, pos, Quaternion.identity);
        Destroy(ps, 1f);
        Destroy(gameObject);
    }
}