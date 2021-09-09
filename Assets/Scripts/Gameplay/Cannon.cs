using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    [Header("Cannon Motion")]
    [SerializeField] private Transform _cannonTransform = null;
    [SerializeField] private Transform _cannonballSpawnPoint = null;
    [SerializeField] private float _rotationRate = 45.0f;
    [Header("Cannon Firing")]
    [SerializeField] private GameObject _cannonballPrefab = null;
    [SerializeField] private float _cannonballFireVelocity = 50.0f;
    [SerializeField] private float _rateOfFire = 0.33f;
    [SerializeField] private Transform Spawner_1;
    [SerializeField] private Transform Spawner_2;
    [SerializeField] private Transform Spawner_3;
    [SerializeField] private float AimSpeed = 10;//how many degrees persecond


    private float _timeOfLastFire = 0.0f;
    

    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<GameSession>().OnSessionEnd += () => { enabled = false; };
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.anyKeyDown)
        {
            StopAllCoroutines();
        }

        if( Input.GetKeyDown( KeyCode.Space ) )
        {
            FireCannon();
        }

        if( Input.GetKey( KeyCode.LeftArrow ) )
        {
            _cannonTransform.Rotate( 0.0f, -(Time.deltaTime * _rotationRate), 0.0f, Space.World );
        }

        if( Input.GetKey( KeyCode.RightArrow ) )
        {
            _cannonTransform.Rotate( 0.0f, Time.deltaTime * _rotationRate, 0.0f, Space.World );
        }

        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            StartCoroutine(AutoAim2(Spawner_1));
        }

        if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            StartCoroutine(AutoAim2(Spawner_2));
        }

        if (Input.GetKeyDown(KeyCode.Keypad3))
        {
            StartCoroutine(AutoAim2(Spawner_3));
        }
    }


    IEnumerator AutoAim2(Transform SpawnerTarget)
    {
        //prepare data to do math for aiming
        Vector3 SpawnerPosGrounded = SpawnerTarget.position;
        SpawnerPosGrounded.y = 0;
        Vector3 MyPosGrounded = _cannonTransform.position;
        MyPosGrounded.y = 0;
        Vector3 targetDir = (SpawnerPosGrounded - MyPosGrounded).normalized;
        Vector3 forward = _cannonTransform.forward;
        Vector3 FlatForward = forward;
        FlatForward.y = 0;
        FlatForward.Normalize();
        float AngleToTravel = Vector3.SignedAngle(FlatForward, targetDir, Vector3.up);
        if (Mathf.Abs(AngleToTravel) < 1)
        {
            //already aimed at target
            yield break;
        }

        float StartY = _cannonTransform.rotation.eulerAngles.y;

        float FrameAngleTrack = 0;
        float EntireAngleTrack = 0;
        while (true)
        {
            Vector3 CurrentRot = _cannonTransform.rotation.eulerAngles;
            if(AngleToTravel > 0)
            {
                FrameAngleTrack += AimSpeed * Time.deltaTime;
                EntireAngleTrack += FrameAngleTrack;

                if (EntireAngleTrack > AngleToTravel)
                {
                    CurrentRot.y = AngleToTravel + StartY;
                    _cannonTransform.eulerAngles = CurrentRot;
                    yield break;

                }
            }
            else
            {
                FrameAngleTrack -= AimSpeed * Time.deltaTime;
                EntireAngleTrack += FrameAngleTrack;

                if(EntireAngleTrack < AngleToTravel)
                {
                    CurrentRot.y = AngleToTravel + StartY;
                    _cannonTransform.eulerAngles = CurrentRot;
                    yield break;

                }
            }

            CurrentRot.y += FrameAngleTrack;
            _cannonTransform.eulerAngles = CurrentRot;
            FrameAngleTrack = 0;

            yield return null;
        }
    }

    public void FireCannon()
    {
        if( Time.timeSinceLevelLoad > _timeOfLastFire + _rateOfFire )
        {
            var spawnedBall = GameObject.Instantiate( _cannonballPrefab, _cannonballSpawnPoint.transform.position, _cannonTransform.rotation);

            spawnedBall.GetComponent<Rigidbody>().AddForce( _cannonTransform.forward * _cannonballFireVelocity, ForceMode.Impulse );
            _timeOfLastFire = Time.timeSinceLevelLoad;
        }
    }
}
