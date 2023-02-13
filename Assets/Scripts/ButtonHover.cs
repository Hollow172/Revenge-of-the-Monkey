using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private EnemySpawn1 gameActiveCheck;
    [SerializeField] private Button buttonToHover;
    [SerializeField] private GameObject unhoverObject;
    [SerializeField] private Text hoverObject;
    [SerializeField] private float fadeSpeed;

    private void Start()
    {
        hoverObject.gameObject.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (!gameActiveCheck.gameInactive)
        {
            StartCoroutine(FadeTo(unhoverObject, 0.0f, fadeSpeed));
            hoverObject.gameObject.SetActive(true);
            hoverObject.CrossFadeAlpha(1, fadeSpeed, false);
        }

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (!gameActiveCheck.gameInactive)
        {
            StartCoroutine(FadeTo(unhoverObject, 1.0f, fadeSpeed));
            hoverObject.CrossFadeAlpha(0, fadeSpeed, false);
        }
    }

    IEnumerator FadeTo(GameObject gameObject, float aValue, float aTime)
    {
        float alpha = gameObject.GetComponent<Renderer>().material.color.a;
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime)
        {
            Color newColor = new Color(1, 1, 1, Mathf.Lerp(alpha, aValue, t));
            gameObject.GetComponent<Renderer>().material.color = newColor;
            yield return null;
        }
    }




}
