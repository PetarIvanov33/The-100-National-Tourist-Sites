using TouristGuideBulgaria.Models;

namespace TouristGuideBulgaria.Data
{
    public static class PlaceData
    {
        public static List<Place> GetPlaces()
        {
            return new List<Place>
            {
                new Place { Id = 1, Name = "Рилски манастир", Category = "Манастир", Region = "Кюстендил",
                    ShortDescription = "Най-големият манастир в България",
                    Description = "Основан през 10 век, част от ЮНЕСКО.",
                    InterestingFact = "Св. Иван Рилски",
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/6/6e/Rila_Monastery.jpg",
                    Latitude = 42.1334, Longitude = 23.3400,
                    GoogleMapsUrl = "https://maps.google.com/?q=42.1334,23.3400" },

                new Place { Id = 2, Name = "Царевец", Category = "Крепост", Region = "Велико Търново",
                    ShortDescription = "Средновековна столица",
                    Description = "Главната крепост на Второто българско царство.",
                    InterestingFact = "Дом на българските царе",
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/1/1a/Tsarevets.jpg",
                    Latitude = 43.0757, Longitude = 25.6515,
                    GoogleMapsUrl = "https://maps.google.com/?q=43.0757,25.6515" },

                new Place { Id = 3, Name = "Белоградчишки скали", Category = "Природа", Region = "Белоградчик",
                    ShortDescription = "Скални феномени",
                    Description = "Уникални природни образувания.",
                    InterestingFact = "Сред най-красивите в Европа",
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/3/3f/Belogradchik_Rocks.jpg",
                    Latitude = 43.6270, Longitude = 22.6830,
                    GoogleMapsUrl = "https://maps.google.com/?q=43.6270,22.6830" },

                new Place { Id = 4, Name = "Плиска", Category = "История", Region = "Шумен",
                    ShortDescription = "Първата столица",
                    Description = "Създадена от хан Аспарух.",
                    InterestingFact = "Начало на България",
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/9/9e/Pliska.jpg",
                    Latitude = 43.3640, Longitude = 27.1220,
                    GoogleMapsUrl = "https://maps.google.com/?q=43.3640,27.1220" },

                new Place { Id = 5, Name = "Преслав", Category = "История", Region = "Шумен",
                    ShortDescription = "Втора столица",
                    Description = "Столица при Симеон Велики.",
                    InterestingFact = "Златен век",
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/6/65/Preslav.jpg",
                    Latitude = 43.1667, Longitude = 26.8167,
                    GoogleMapsUrl = "https://maps.google.com/?q=43.1667,26.8167" },

                new Place { Id = 6, Name = "Мадарски конник", Category = "История", Region = "Шумен",
                    ShortDescription = "Скален релеф",
                    Description = "Уникален барелеф от 8 век.",
                    InterestingFact = "ЮНЕСКО обект",
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/4/4b/Madara_Rider.jpg",
                    Latitude = 43.2760, Longitude = 27.1200,
                    GoogleMapsUrl = "https://maps.google.com/?q=43.2760,27.1200" },

                new Place { Id = 7, Name = "Перперикон", Category = "История", Region = "Кърджали",
                    ShortDescription = "Древен град",
                    Description = "Тракийско светилище.",
                    InterestingFact = "Оракул на Дионис",
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/8/8f/Perperikon.jpg",
                    Latitude = 41.7340, Longitude = 25.4650,
                    GoogleMapsUrl = "https://maps.google.com/?q=41.7340,25.4650" },

                new Place { Id = 8, Name = "Бачковски манастир", Category = "Манастир", Region = "Пловдив",
                    ShortDescription = "Втори по големина",
                    Description = "Основан през 1083 г.",
                    InterestingFact = "Чудотворна икона",
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/5/5d/Bachkovo.jpg",
                    Latitude = 41.9440, Longitude = 24.8500,
                    GoogleMapsUrl = "https://maps.google.com/?q=41.9440,24.8500" },

                new Place { Id = 9, Name = "Троянски манастир", Category = "Манастир", Region = "Ловеч",
                    ShortDescription = "Третият по големина",
                    Description = "Духовен център.",
                    InterestingFact = "Васил Левски е укриван тук",
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/6/6a/Troyan_monastery.jpg",
                    Latitude = 42.8650, Longitude = 24.7000,
                    GoogleMapsUrl = "https://maps.google.com/?q=42.8650,24.7000" },

                new Place { Id = 10, Name = "Шипка", Category = "История", Region = "Стара Загора",
                    ShortDescription = "Паметник",
                    Description = "Свобода на България.",
                    InterestingFact = "Руско-турска война",
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/3/3c/Shipka.jpg",
                    Latitude = 42.7333, Longitude = 25.3167,
                    GoogleMapsUrl = "https://maps.google.com/?q=42.7333,25.3167" },

                new Place { Id = 11, Name = "Етъра", Category = "Музей", Region = "Габрово",
                    ShortDescription = "Етнографски комплекс",
                    Description = "Жив музей на занаяти.",
                    InterestingFact = "Работещи работилници",
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/2/2f/Etar.jpg",
                    Latitude = 42.8060, Longitude = 25.3340,
                    GoogleMapsUrl = "https://maps.google.com/?q=42.8060,25.3340" },

                new Place { Id = 12, Name = "Копривщица", Category = "Архитектура", Region = "София област",
                    ShortDescription = "Възрожденски град",
                    Description = "Запазена архитектура.",
                    InterestingFact = "Априлско въстание",
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/4/4f/Koprivshtitsa.jpg",
                    Latitude = 42.6333, Longitude = 24.3500,
                    GoogleMapsUrl = "https://maps.google.com/?q=42.6333,24.3500" },

                new Place { Id = 13, Name = "Седемте рилски езера", Category = "Природа", Region = "Рила",
                    ShortDescription = "Ледникови езера",
                    Description = "Най-известните езера.",
                    InterestingFact = "Различни форми",
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/9/97/Seven_Rila_Lakes.jpg",
                    Latitude = 42.2000, Longitude = 23.3000,
                    GoogleMapsUrl = "https://maps.google.com/?q=42.2000,23.3000" },

                new Place { Id = 14, Name = "Стария Пловдив", Category = "Архитектура", Region = "Пловдив",
                    ShortDescription = "Античен град",
                    Description = "Старинна част на града.",
                    InterestingFact = "Римски театър",
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/6/6b/Plovdiv_old_town.jpg",
                    Latitude = 42.1500, Longitude = 24.7500,
                    GoogleMapsUrl = "https://maps.google.com/?q=42.1500,24.7500" },

                new Place { Id = 15, Name = "Асенова крепост", Category = "Крепост", Region = "Пловдив",
                    ShortDescription = "Средновековна крепост",
                    Description = "Крепост край Асеновград.",
                    InterestingFact = "Свързана с цар Иван Асен II",
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/0/0f/Asen_fortress.jpg",
                    Latitude = 41.9890, Longitude = 24.8720,
                    GoogleMapsUrl = "https://maps.google.com/?q=41.9890,24.8720" },

                new Place { Id = 16, Name = "Калиакра", Category = "Природа", Region = "Добрич",
                    ShortDescription = "Нос Калиакра",
                    Description = "Черноморски нос.",
                    InterestingFact = "Легенда за девойките",
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/f/f3/Kaliakra.jpg",
                    Latitude = 43.3667, Longitude = 28.4667,
                    GoogleMapsUrl = "https://maps.google.com/?q=43.3667,28.4667" },

                new Place { Id = 17, Name = "Аладжа манастир", Category = "Манастир", Region = "Варна",
                    ShortDescription = "Скален манастир",
                    Description = "Средновековен манастир.",
                    InterestingFact = "Изсечен в скала",
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/0/08/Aladzha_monastery.jpg",
                    Latitude = 43.2330, Longitude = 27.9300,
                    GoogleMapsUrl = "https://maps.google.com/?q=43.2330,27.9300" },

                new Place { Id = 18, Name = "Деветашка пещера", Category = "Природа", Region = "Ловеч",
                    ShortDescription = "Голяма пещера",
                    Description = "Една от най-красивите.",
                    InterestingFact = "Снимани филми",
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/5/5e/Devetashka_cave.jpg",
                    Latitude = 43.2500, Longitude = 24.4000,
                    GoogleMapsUrl = "https://maps.google.com/?q=43.2500,24.4000" },

                new Place { Id = 19, Name = "Крушунски водопади", Category = "Природа", Region = "Ловеч",
                    ShortDescription = "Водопади",
                    Description = "Карстови водопади.",
                    InterestingFact = "Синьо-зелени басейни",
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/8/89/Krushuna_falls.jpg",
                    Latitude = 43.2410, Longitude = 25.0300,
                    GoogleMapsUrl = "https://maps.google.com/?q=43.2410,25.0300" },

                new Place { Id = 20, Name = "Трапезица", Category = "Крепост", Region = "Велико Търново",
                    ShortDescription = "Исторически хълм",
                    Description = "Част от старата столица.",
                    InterestingFact = "До Царевец",
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/5/5c/Trapezitsa.jpg",
                    Latitude = 43.0800, Longitude = 25.6500,
                    GoogleMapsUrl = "https://maps.google.com/?q=43.0800,25.6500" }
            };
        }
    }
}