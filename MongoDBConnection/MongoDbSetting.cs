namespace lampadaire.MongoDBConnection
{
    public class MongoDbSetting
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string LampadaireCollectionName { get; set; }
        public string SensorCollectionName { get; set; }
    }

}