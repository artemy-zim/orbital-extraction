using AYellowpaper;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

internal class Tutorial : MonoBehaviour
{
    [SerializeField] private List<TutorialCard> _cards;
    [SerializeField] private TutorialCardView _cardView;

    [SerializeField] private InterfaceReference<IAnimator> _animator;
    [SerializeField] private Window _window;

    [SerializeField] private Button _actionButton;
    [SerializeField] private Sprite _exitIcon;
    [SerializeField] private Image _actionButtonIcon;

    private int _pageCounter = 0;

    private void Awake()
    {
        _cards.OrderBy(card => card.Order);
    }

    private void OnEnable()
    {
        _actionButton.onClick.AddListener(RenderNext);
    }

    private void OnDisable()
    {
        _actionButton.onClick.RemoveListener(RenderNext);
    }

    public void Init(AudioSource uiSound)
    {
        _actionButton.onClick.AddListener(uiSound.Play);
        _window.Show();
        _animator.Value.Play();
        RenderNext();
    }

    private void RenderNext()
    {
        if(_pageCounter >= _cards.Count)
        {
            Destroy(gameObject);
            
            return;
        }
        
        if(_pageCounter == _cards.Count - 1)
        {
            _actionButtonIcon.sprite = _exitIcon;
        }

        _cardView.Render(_cards[_pageCounter]);
        _pageCounter++;
    }

    private void OnDestroy()
    {
        _actionButton.onClick.RemoveAllListeners();
    }
}
