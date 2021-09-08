using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Score")]
    public int scoreValue = 100;

    [Header("Movement")]
    [SerializeField] private float _verticalAmplitude = 2.5f;
    [SerializeField] private float _verticalFrequency = 2.5f;

    [Header("Physics")]
    [SerializeField] private Rigidbody _rigidBody = null;
    public EnemySpawner.SpawnNumber MySpawnNumber = EnemySpawner.SpawnNumber.none;

    private Vector3 _startPosition = Vector3.zero;
    bool IsHit = false;
    // Start is called before the first frame update
    void Start()
    {
        _startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(IsHit == false)
        {
            float positionOffset = Mathf.Sin(Time.timeSinceLevelLoad / _verticalFrequency) * _verticalAmplitude;
            transform.position = new Vector3(_startPosition.x, _startPosition.y + positionOffset, _startPosition.z);
        }
    }

    void SetupDeathPhysics()
    {
        _rigidBody.isKinematic = false;
        _rigidBody.useGravity = true;
    }

    void OnCollisionEnter( Collision collision )
    {
        if(IsHit == false)
        {
            if (collision.gameObject.CompareTag("CannonBall"))
            {
                IsHit = true;
                SetupDeathPhysics();
                _rigidBody.AddForceAtPosition(collision.transform.forward, collision.GetContact(0).point, ForceMode.Impulse);
                Destroy(this.gameObject, 4);
                MainGameManager.Instance.OnPumpkinHit(MySpawnNumber);
            }
        }

    }
}
