using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BuildingManager : MonoBehaviour
{
    [SerializeField] private CashManager cashManager;
    [SerializeField] private CashUI cashUI;
    [SerializeField] private Game game;
    private Buildings buildingForPlacement;

    //Cursors:
    [SerializeField] private TowerCursor gorillaCursor;
    [SerializeField] private TowerCursor elephantCursor;
    [SerializeField] private TowerCursor snakeCursor;

    private void Update()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (game.CheckStart() && Input.GetMouseButtonDown(0) && buildingForPlacement != null && CheckGround())
        {
            Instantiate(buildingForPlacement, mousePosition, Quaternion.identity);
            buildingForPlacement = null;
            DeactivateCursors();
            Cursor.visible = true;
        }
    }

    public void BuyGorillaTower(Buildings building)
    {
        if (cashManager.cash >= building.Cost && game.CheckStart() && Cursor.visible)
        {   
            gorillaCursor.gameObject.SetActive(true);
            Cursor.visible = false;
            cashManager.cash -= building.Cost;
            buildingForPlacement = building;
            cashUI.updateText();
        }
    }

    public void BuyElephantTower(Buildings building)
    {
        if (cashManager.cash >= building.Cost && game.CheckStart() && Cursor.visible)
        {
            elephantCursor.gameObject.SetActive(true);
            Cursor.visible = false;
            cashManager.cash -= building.Cost;
            buildingForPlacement = building;
            cashUI.updateText();
        }
    }

    public void BuySnakeTower(Buildings building)
    {
        if (cashManager.cash >= building.Cost && game.CheckStart() && Cursor.visible)
        {
            snakeCursor.gameObject.SetActive(true);
            Cursor.visible = false;
            cashManager.cash -= building.Cost;
            buildingForPlacement = building;
            cashUI.updateText();
        }
    }

    private bool CheckGround() 
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, Mathf.Infinity);
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return false; //checking for UI
        }
        if (hit.collider.tag.Equals("Path") || hit.collider.tag.Equals("Enemy") || hit.collider.tag.Equals("Player"))
        {
            //Debug.Log("false" + hit.collider.tag);
            return false;
        }
        //Debug.Log("true" + hit.collider.tag);
        return true;
    }

    private void DeactivateCursors()
    {
        gorillaCursor.gameObject.SetActive(false);
        elephantCursor.gameObject.SetActive(false);
        snakeCursor.gameObject.SetActive(false);
    }
}
