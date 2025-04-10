using TMPro;
using Tymski;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class LevelCardView : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private TextMeshProUGUI _text;

    private SceneReference _scene;

    private void OnEnable()
    {
        _button.onClick.AddListener(OnCardClick);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnCardClick);
    }

    public void Render(LevelCard card)
    {
        _scene = card.Scene;
        _text.text = card.LevelCount.ToString();
    }

    private void OnCardClick()
    {
        MessageBroker.Default.Publish(new LevelSelectedMessage(_scene));
    }
}
