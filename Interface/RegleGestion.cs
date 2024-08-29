namespace lampadaire.Interface
{
    public interface IRegleGestion
    {
        void ActivationCapteur();
        void RegleAllumageLampadaire();
        void IfMeteoHard();
        void Urgence();
    }

}