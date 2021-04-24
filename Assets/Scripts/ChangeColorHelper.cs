using UnityEngine;
using System.Collections;

public class ChangeColorHelper : MonoBehaviour
{

    public GameObject[] CarParts;

    public GameObject[] CarSpoils;

    CarModel _carModel = new CarModel();
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LoadCar(CarModel model)
    {
        if (model == null)
            return;

        ChangeSpoil(model.Spoil);
        ChangeColor(model.Color);
    }

    public void SaveCar()
    {
        SettingClass.PlayerCar = _carModel;
    }

    public void ChangeSpoil(int id)
    {
        foreach (var item in CarSpoils)
            item.SetActive(false);

        CarSpoils[id].SetActive(true);

        _carModel.Spoil = id;

        SaveCar();
    }


    public void ChangeColor(int color)
    {
        Color newColor = Color.blue;

        if (color == 1)
            newColor = Color.green;
        else if (color == 2)
            newColor = Color.magenta;

        foreach (var item in CarParts)
        {
            item.GetComponent<MeshRenderer>().material.color = newColor;
        }

        _carModel.Color = color;

        SaveCar();
    }
}
