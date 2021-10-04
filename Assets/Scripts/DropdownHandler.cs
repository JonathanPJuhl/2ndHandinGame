using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropdownHandler : MonoBehaviour
{
    public Dropdown mapSizeDropdown;
    public Dropdown amountOfBoxesDropdown;
    private string mapSize;
    private string amountOfBoxes;
    public Button submitGameMode;
    
    void Start()
    {
        List<string> mapItems = new List<string>();
        mapItems.Add("Choose...");
        mapItems.Add("Small");
        mapItems.Add("Medium");
        mapItems.Add("Large");

        foreach (var item in mapItems)
        {
            mapSizeDropdown.options.Add(new Dropdown.OptionData() { text = item });
        }

        List<string> boxItems = new List<string>();
        boxItems.Add("Choose...");
        boxItems.Add("Few");
        boxItems.Add("Medium");
        boxItems.Add("Many");

        foreach (var item in boxItems)
        {
            amountOfBoxesDropdown.options.Add(new Dropdown.OptionData() { text = item });
        }

        mapSizeDropdown.onValueChanged.AddListener(delegate { MapSizeSelected(mapSizeDropdown); });
        amountOfBoxesDropdown.onValueChanged.AddListener(delegate { AmountOfBoxesSelected(amountOfBoxesDropdown); });
        submitGameMode.onClick.AddListener(delegate { SubmitGameMode(); });
    }

    void MapSizeSelected(Dropdown d)
    {
        int index = d.value;
        mapSize = d.options[index].text;
    }
    
    void AmountOfBoxesSelected(Dropdown d)
    {
        int index = d.value;
        amountOfBoxes = d.options[index].text;
    }

    public void SubmitGameMode()
    {
        if ((mapSize == null && mapSize != "Choose...") || (amountOfBoxes == null && amountOfBoxes != "Choose..."))
        {
            return;
        }
        else
        {
            GroundSpawner groundSpawner = GameObject.FindObjectOfType<GroundSpawner>();
            groundSpawner.SpawnMap(mapSize, amountOfBoxes);
        }

    }
    
}
