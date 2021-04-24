using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameHelper : MonoBehaviour
{
    const float TimeLimit = 30;

    const float Distance = 20;
    const int PointCount = 10;

    public GameObject[] MissionPoints;

    public Transform StartPosition;
    public GameObject RacePrefab;
    public Text TimeText;

    int _currentIndex;

    int _currentPoints;
    float _lastTime;

    GameObject _playerCar;
    GameObject _car;
    // Use this for initialization
    void Start()
    {

        _playerCar = Instantiate(RacePrefab) as
            GameObject;
        _playerCar.transform.position = new Vector3(-6.64f, -20.9f, -25.3f);
        _playerCar.transform.rotation = Quaternion.identity;
        _playerCar.transform.SetParent(StartPosition, false);

        _playerCar.GetComponentInChildren<ChangeColorHelper>().LoadCar(SettingClass.PlayerCar);
        _car = _playerCar.GetComponentInChildren<ChangeColorHelper>().gameObject;

        foreach (var item in MissionPoints)
            item.SetActive(false);
        MissionPoints[_currentIndex].SetActive(true);

        _lastTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(_car.transform.position, MissionPoints[_currentIndex].transform.position) < Distance)
        {
            _currentPoints += PointCount;
            MissionPoints[_currentIndex].SetActive(false);
            _currentIndex++;

            float time = Time.time - _lastTime;

            if (TimeLimit < time)
            {
                SceneManager.LoadScene("Main");
            }

            TimeText.text = time.ToString();

            if (_currentIndex >= MissionPoints.Length)
            {
                SettingClass.Points += _currentPoints;
                SceneManager.LoadScene("Main");
            }
            else
            {
                MissionPoints[_currentIndex].SetActive(true);
            }
            _lastTime = Time.time;
        }
    }
}
