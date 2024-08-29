namespace lampadaire.MongoDBConnection
{
    public class MongoDbSetting
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string LampadaireCollectionName { get; set; }
        public string CapteurCollectionName { get; set; }
        public string HoraireCollectionName { get; set; }
        public string UtilisateurCollectionName { get; set; }
    }

}