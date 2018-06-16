using UnityEngine;
using UnityEngine.UI;

namespace Assets
{
    public class StatusTextController : MonoBehaviour
    {
        public float Alpha;
        public float Duration;
        public float FadeDuration;
        public Text StatusText;


        public void ShowStatus(string status)
        {
            if (StatusText.text != status)
            {
                StatusText.text = status;
            }

            gameObject.SetActive(true);

            var image = GetComponent<Image>();
            image.canvasRenderer.SetAlpha(0f);
            image.CrossFadeAlpha(Alpha, FadeDuration, true);

            Invoke("TriggerFadeOut", Duration - FadeDuration);
        }

        public void HideStatus()
        {
            gameObject.SetActive(false);
        }

        private void TriggerFadeOut()
        {
            var image = GetComponent<Image>();
            image.CrossFadeAlpha(0f, FadeDuration, true);
            Invoke("HideStatus", FadeDuration);
        }
    }
}
