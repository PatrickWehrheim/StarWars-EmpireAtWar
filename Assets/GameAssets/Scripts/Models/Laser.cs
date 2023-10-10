using System.Collections;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 500f;
    [SerializeField] private GameObject _hitPrefab;
    private Rigidbody _rigidbody;
    private Collider _collider;

    public LayerMask LayerToHit;
    public int Demage;

    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _collider = GetComponent<Collider>();
    }

    private void Start()
    {
        _rigidbody.AddForce(transform.forward * _moveSpeed, ForceMode.Impulse);
        StartCoroutine(DestroyAfterSeconds(2));
    }


    private IEnumerator DestroyAfterSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);

        Destroy(this.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        //Bitshifting
        // 0b0000_0001   << 3
        // 0b0000_1000

        // 0b0001_0010 
        // 0b0000_1000
        // 0b0000_0000

        if (((1 << other.transform.gameObject.layer) & LayerToHit) != 0)
        {
            _collider.isTrigger = false;

            Vector3 collisionPoint = other.ClosestPointOnBounds(transform.position);
            Quaternion rotation = Quaternion.FromToRotation(Vector3.up, collisionPoint.normalized);

            if(_hitPrefab != null)
            {
                Instantiate(_hitPrefab, collisionPoint, rotation);
            }

            IDamagable damagable = other.GetComponent<IDamagable>();
            if(damagable != null)
            {
                damagable.GetDemage(Demage);
            }
            StartCoroutine(DestroyAfterSeconds(0.1f));
        }
    }
}
