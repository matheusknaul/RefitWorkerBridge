using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace StudyAPI.Config
{
    public class GeocodeMapsApiKey
    {
        #region Variables
        public string ApiKey { get; set; }
        #endregion
        #region Constructors
        public GeocodeMapsApiKey()
        {
            this.ApiKey = LoadApiFromJson();
        }

        public GeocodeMapsApiKey(string key)
        {
            this.ApiKey = key;
        }
        #endregion
        #region Methods
        private string LoadApiFromJson() 
        {
            var jsonPath = Path.Combine(AppContext.BaseDirectory, "Config", "apiKey.json");

            if (!File.Exists(jsonPath))
                throw new FileNotFoundException($"File not found at directory: {jsonPath}");
            var json = File.ReadAllText(jsonPath);

            var keyObject = JsonSerializer.Deserialize<GeocodeMapsApiKey>(json);
            return keyObject?.ApiKey ?? throw new Exception("ApiKey não encontrada no JSON");

        }
        #endregion

    }
}
