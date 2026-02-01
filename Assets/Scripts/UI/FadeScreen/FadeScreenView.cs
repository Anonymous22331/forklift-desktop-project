using DG.Tweening;
using UnityEngine;
using UnityEngine.UIElements;

namespace UI.FadeScreen
{
    public class FadeScreenView : MonoBehaviour
    {
        [SerializeField] private UIDocument _uiDocument;
        [SerializeField] private float _fadeInDuration;

        private VisualElement _overlay;

        public void Initialize()
        {
            _overlay = _uiDocument.rootVisualElement.Q<VisualElement>("fadeOverlay");
            _overlay.style.opacity = 1f;
        }

        public void FadeIn()
        {
            DOTween
                .To(
                    () => _overlay.style.opacity.value,
                    value => _overlay.style.opacity = value,
                    0f,
                    _fadeInDuration)
                .SetUpdate(true);
        }
    }
}