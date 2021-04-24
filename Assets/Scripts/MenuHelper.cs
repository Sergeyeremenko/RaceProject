using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuHelper : MonoBehaviour
{
    public Text PointsText;

    void Start()
    {
        Debug.Log("SettingClass.Points = " + SettingClass.Points);
        PointsText.text = SettingClass.Points.ToString();
    }

    public void StartRace()
    {
        SceneManager.LoadScene("Race");
    }
}
