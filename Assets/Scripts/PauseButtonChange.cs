using UnityEngine;
using UnityEngine.UI;

public class PauseButtonChange : MonoBehaviour
{
    public Image image;

    [SerializeField]
    private Sprite pauseSprite;

    [SerializeField]
    private Sprite playSprite;

    [SerializeField]
    private Image grayImage;

    public void changeSpritetoPlay()
    {
        image.sprite = playSprite;
        grayImage.enabled = true;
    }

    public void changeSpritetoPause()
    {
        image.sprite = pauseSprite;
        grayImage.enabled = false;
    }
}
