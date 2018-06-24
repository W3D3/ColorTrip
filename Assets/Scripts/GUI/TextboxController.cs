using UnityEngine;
using UnityEngine.UI;

namespace Assets
{
    public class TextboxController : MonoBehaviour
    {
        public float Alpha;
        public float Duration;
        public float FadeDuration;
        public Text Text;

        public void Show(string text)
        {
            Text.text = text;
            gameObject.SetActive(true);

            var image = GetComponent<Image>();
            image.canvasRenderer.SetAlpha(0f);
            image.CrossFadeAlpha(Alpha, FadeDuration, true);
        }

        public void ShowAndHide(string text)
        {
            Text.text = text;

            gameObject.SetActive(true);

            var image = GetComponent<Image>();
            image.canvasRenderer.SetAlpha(0f);
            image.CrossFadeAlpha(Alpha, FadeDuration, true);

            Invoke("TriggerFadeOut", Duration - FadeDuration);
        }

        public void HideTrigger()
        {
            gameObject.SetActive(false);
        }

        public void TriggerFadeOut()
        {
            var image = GetComponent<Image>();
            image.CrossFadeAlpha(0f, FadeDuration, true);
            Invoke("HideTrigger", FadeDuration);
        }
    }
}
