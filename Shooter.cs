using System.Collections;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Rigidbody _prefab;
    [SerializeField] private Transform _target;
    [SerializeField] float _delay;

    private void Start()
    {
        StartCoroutine(Shooting());
    }

    private IEnumerator Shooting()
    {
        var wait = new WaitForSeconds(_delay);

        while (enabled)
        {
            var direction = (_target.position - transform.position).normalized;
            Rigidbody newBullet = Instantiate(_prefab, transform.position , Quaternion.identity);

            newBullet.transform.up = direction;
            newBullet.velocity = direction * _speed*Time.deltaTime;

            yield return wait;            
        }       
    }
}