using UnityEngine;
using System.Collections;
using UnityStandardAssets.Vehicles.Car;

public class PoliceHelper : MonoBehaviour
{
    public float Radius = 200;

    GameObject _target;

    CarAIControl _carAIControl;
    // Use this for initialization
    void Start()
    {
        _carAIControl = GetComponent<CarAIControl>();
    }

    // Update is called once per frame
    void Update()
    {

        if (_target)
            return;

        Collider[] cooliders = Physics.OverlapSphere(transform.position, Radius);

        foreach (var item in cooliders)
        {
            if (item.GetComponent<PlayerHelper>())
            {
                _target = item.gameObject;
                _carAIControl.SetTarget(_target.transform);
            }
        }

    }
}
