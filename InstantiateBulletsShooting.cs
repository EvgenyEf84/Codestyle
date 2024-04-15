using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Shooter : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private GameObject _prefab;
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
            var NewBullet = Instantiate(_prefab, transform.position, Quaternion.identity);

            NewBullet.GetComponent<Rigidbody>().transform.up = direction;
            NewBullet.GetComponent<Rigidbody>().velocity = direction * _speed * Time.deltaTime;

            yield return wait;
        }
    }
}