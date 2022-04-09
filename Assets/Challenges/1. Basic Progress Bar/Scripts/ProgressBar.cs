using UnityEngine;
using UnityEngine.UI;

namespace Challenges._1._Basic_Progress_Bar.Scripts
{
    /// <summary>
    /// Edit this script for the ProgressBar challenge.
    /// </summary>
    public class ProgressBar : MonoBehaviour, IProgressBar
    {
        GameObject fillBar;
        GameObject percentage;
        float currentValue;
        TMPro.TextMeshProUGUI currentValueText;
        Slider slider;
        private void Awake()
        {
            fillBar = transform.GetChild(1).gameObject;
            percentage = transform.GetChild(2).gameObject;
            currentValueText = percentage.GetComponent<TMPro.TextMeshProUGUI>();
            currentValue = float.Parse(currentValueText.text.Substring(0, 2));
            slider = GetComponent<Slider>();
        }
        /// <summary>
        /// You can add more options
        /// </summary>
        private enum ProgressSnapOptions
        {
            SnapToLowerValue,
            SnapToHigherValue,
            DontSnap
        }
        
        /// <summary>
        /// You can add more options
        /// </summary>
        private enum TextPosition
        {
            BarCenter,
            Progress,
            NoText 
        }

        private void SetFillBarValue()
        {
            if (snapOptions == ProgressSnapOptions.SnapToLowerValue || snapOptions == ProgressSnapOptions.SnapToHigherValue)
            {
                currentValueText.text = expectedValue.ToString() + "%";
                slider.value = expectedValue;
            }
        }

        private void SetTextPosition()
        {
            if(textPosition == TextPosition.NoText)
            {
                percentage.SetActive(false);
            }
        }

        private void Update()
        {
            SetTextPosition();
            SetFillBarValue();
        }
        /// <summary>
        /// These settings below must function
        /// </summary>
        [Header("Options")]
        [SerializeField]
        private float baseSpeed;
        [SerializeField] [Range(0,100)]
        private float expectedValue;
        [SerializeField]
        private ProgressSnapOptions snapOptions;
        [SerializeField]
        private TextPosition textPosition;
        
        
        
        /// <summary>
        /// Sets the progress bar to the given normalized value instantly.
        /// </summary>
        /// <param name="value">Must be in range [0,1]</param>
        public void ForceValue(float value)
        {
            Mathf.Clamp(value, 0, 1);
            percentage.GetComponent<TMPro.TextMeshProUGUI>().text = Mathf.Round(value * 100).ToString() + "%";
        }

        /// <summary>
        /// The progress bar will move to the given value
        /// </summary>
        /// <param name="value">Must be in range [0,1]</param>
        /// <param name="speedOverride">Will override the base speed if one is given</param>
        public void SetTargetValue(float value, float? speedOverride = null)
        {
        }

    }
}
