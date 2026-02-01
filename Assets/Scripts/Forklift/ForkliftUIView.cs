using UnityEngine;
using UnityEngine.UIElements;

namespace Forklift
{
    public class ForkliftUIView : MonoBehaviour
    {
        [SerializeField] private UIDocument _document;

        private Label _speedLabel;
        private Label _engineLabel;
        private VisualElement _engineLight;
        private VisualElement _fuelEmptyMask;
        private Label _fuelText;

        private void Awake()
        {
            var root = _document.rootVisualElement;
            _speedLabel = root.Q<Label>(className: "speed-text");
            _engineLabel = root.Q<Label>(className: "engine-text");
            _engineLight = root.Q<VisualElement>(className: "engine-light");
        
            _fuelEmptyMask = root.Q<VisualElement>(className: "fuel-empty-mask");
            _fuelText = root.Q<Label>(className:"fuel-text");
        }

        public void SetSpeed(float speed)
        {
            _speedLabel.text = Mathf.Abs(speed).ToString("0");
        }

        public void SetEngineState(bool isRunning)
        {
            _engineLight.EnableInClassList("on", isRunning);
            _engineLight.EnableInClassList("off", !isRunning);

            _engineLabel.text = isRunning ? "ВКЛ" : "ВЫКЛ";
        }

        public void SetFuel(float normalized)
        {
            normalized = Mathf.Clamp01(normalized);

            const float circleSize = 60f;

            float visibleHeight = circleSize * (1f - normalized);

            _fuelEmptyMask.style.height = visibleHeight;
            _fuelEmptyMask.style.top = 0;

            _fuelText.text = Mathf.RoundToInt(normalized * 100f) + "%";
        }

    }
}