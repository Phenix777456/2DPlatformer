using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class VampirizmView : MonoBehaviour
{
    [SerializeField] private VampireAbility _vampireAbility;
    [SerializeField] private Button _button;
    [SerializeField] private TextMeshProUGUI _buttonLabel;
    [SerializeField] private UnityEngine.UI.Slider _progressSlider;

    private void OnEnable()
    {
        _progressSlider.value = 1f;
        _vampireAbility.AbilityStarted += OnAbilityStarted;
        _vampireAbility.AbilityEnded += OnAbilityEnded;
        _vampireAbility.CooldownEnded += OnCooldownEnded;
        _vampireAbility.AbilityProgressChanged += OnAbilityProgressChanged;
        _vampireAbility.CooldownProgressChanged += OnCooldownProgressChanged;
        _button.onClick.AddListener(OnButtonClicked);
    }

    private void OnDisable()
    {
        _vampireAbility.AbilityStarted -= OnAbilityStarted;
        _vampireAbility.AbilityEnded -= OnAbilityEnded;
        _vampireAbility.CooldownEnded -= OnCooldownEnded;
        _vampireAbility.AbilityProgressChanged -= OnAbilityProgressChanged;
        _vampireAbility.CooldownProgressChanged -= OnCooldownProgressChanged;
        _button.onClick.RemoveListener(OnButtonClicked);
    }

    private void OnButtonClicked() => _vampireAbility.TryActivate();

    private void OnAbilityStarted()
    {
        _buttonLabel.text = "In process";
        _progressSlider.value = 0f;
    }

    private void OnAbilityEnded() => _buttonLabel.text = "Reloading";

    private void OnCooldownEnded()
    {
        _buttonLabel.text = "Ready";
        _progressSlider.value = 1f;
    }

    private void OnAbilityProgressChanged(float progress) => _progressSlider.value = progress;

    private void OnCooldownProgressChanged(float progress) => _progressSlider.value = progress;
}