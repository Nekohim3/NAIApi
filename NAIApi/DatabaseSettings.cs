﻿namespace NAIApi
{
    public class DatabaseSettings
    {
        public string DatabaseHost     { get; set; } = "localhost";
        public string DatabasePort     { get; set; } = "5432";
        public string DatabaseName     { get; set; } = "NovelAIHelper";
        public string DatabaseUsername { get; set; } = "postgress";
        public string DatabasePassword { get; set; } = "KuroNeko2112@";

        public DatabaseSettings(string databaseHost, string databasePort, string databaseName, string databaseUsername, string databasePassword)
        {
            DatabaseHost     = databaseHost;
            DatabasePort     = databasePort;
            DatabaseName     = databaseName;
            DatabaseUsername = databaseUsername;
            DatabasePassword = databasePassword;
        }
    }
}
