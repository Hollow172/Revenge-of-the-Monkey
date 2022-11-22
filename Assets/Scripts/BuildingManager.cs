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

        if (Input.GetMouseButtonDown(0) && buildingForPlacement != null && CheckGround())
        {
            Instantiate(buildingForPlacement, mousePosition, Quaternion.identity);
            buildingForPlacement = null;
            towerCursor.gameObject.SetActive(false);
            Cursor.visible = true;
        }
    }

    public void BuyBuilding(Buildings building)
    {
        if (cashManager.cash >= building.Cost)
        {
            towerCursor.gameObject.SetActive(true);
            Cursor.visible = false;
            cashManager.cash -= building.Cost;
            buildingForPlacement = building;
            cashUI.updateText();
        }
    }

    private bool CheckGround() 
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, Mathf.Infinity);
        if(hit.collider.tag.Equals("Path") || hit.collider.tag.Equals("Enemy") || hit.collider.tag.Equals("Player"))
        {
            //Debug.Log("false" + hit.collider.tag);
            return false;
        }
        //Debug.Log("true" + hit.collider.tag);
        return true;
    }

}
