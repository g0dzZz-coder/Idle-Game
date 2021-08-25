namespace IdleGame.Entities.People
{
    public class HumanView : EntityViewBase
    {
        private void Awake()
        {
            FadeOutInstantly();
        }

        private void Start()
        {
            FadeIn();
        }
    }
}