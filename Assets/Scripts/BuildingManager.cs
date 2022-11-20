using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingManager : MonoBehaviour
{
    [SerializeField] private CashManager cashManager;
    [SerializeField] private CashUI cashUI;
    [SerializeField] private TowerCursor towerCursor;
    private Buildings buildingForPlacement;

    private void Update()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0) && buildingForPlacement != null)
        {
            Instantiate(buildingForPlacement, mousePosition, Quaternion.identity);
            buildingForPlacement = null;
            towerCursor.gameObject.SetActive(false);
            Cursor.visible = true;
        }
    }

    public void BuyBuilding(Buildings building)
    {
        if(cashManager.cash >= building.Cost)
        {
            towerCursor.gameObject.SetActive(true);
            towerCursor.GetComponent<SpriteRenderer>().sprite = building.GetComponent<SpriteRenderer>().sprite;
            Cursor.visible = false;
            cashManager.cash -= building.Cost;
            buildingForPlacement = building;
            cashUI.updateText();
        }
    }
}
