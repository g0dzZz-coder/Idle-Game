using UnityEngine;

namespace NavySpade.UI
{
    //using Animation;

    public class UIElement : MonoBehaviour
    {
        public void Show()
        {
            gameObject.SetActive(true);
            //AnimationExtensions.Show(transform);
        }

        public void Hide()
        {
            //AnimationExtensions.Hide(transform, () => gameObject.SetActive(false));
        }
    }
}