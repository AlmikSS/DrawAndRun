using System;
using System.Collections;
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
        {
            Destroy(other.gameObject);
            GetBonusEvent?.Invoke();
        }
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

    public IEnumerator Move(Transform point)
    {
        float totalMovementTime = 2f; // количество времени, которое должно занять перемещение
        float currentMovementTime = 0f; // количество времени, которое прошло

        while (Vector3.Distance(transform.localPosition, point.position) > 0)
        {
            currentMovementTime += Time.deltaTime;
            transform.localPosition =
                Vector3.Lerp(transform.position, point.position, currentMovementTime / totalMovementTime);
            yield return null;
        }

        Destroy(point.gameObject);
    }
}