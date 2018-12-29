using Npgsql;
using System;
using System.Collections.Generic;

namespace candy_market2
{
    public class CandyStorage
    {
        private const string connString = "Server=127.0.0.1;Port=5432;Database=myDataBase;Integrated Security=true;";

        static List<Candy> _candies = new List<Candy>();
        string tempCandyName = "";
        string tempCandyType = "";
        string tempManufacturer = "";
        string tempFlavorCategory = "";
        DateTime tempDateReceived = new DateTime();

        public IEnumerable<Candy> GetAllCandy()
        {
            var temp = new List<Candy>();
            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();

                using (var cmd = new NpgsqlCommand("SELECT * from candy-shop", conn))
                using (var reader = cmd.ExecuteReader())
                    while (reader.Read())
                        Console.WriteLine(reader.GetString(0));
            }
            return temp;
        }

        internal IList<string> GetCandyTypes()
        {
            IList<string> CandyTypes = new List<string>()
            {
                "Hard Candy",
                "Taffy",
                "Jelly Bean",
                "Chocolate"
            };
            return CandyTypes;
        }

        internal void SetCandyType(string candyType)
        {
            tempCandyType = candyType;
        }

        internal IList<string> GetCandyNames()
        {
            IList<string> CandyNames = new List<string>()
            {
                "Sour/Sweet",
                "Caramel Flavored",
                "Saltwater",
                "Flavored",
                "Chocolate Bars",
                "Truffles"
            };
            return CandyNames;
        }

        internal void SetCandyNames(string candyName)
        {
            tempCandyName = candyName;
        }

        internal IList<string> GetCandyManufacturers()
        {
            IList<string> CandyManufacturers = new List<string>()
            {
                "Jolly Ranchers",
                "Werther's",
                "Laffy Taffy",
                "Starburst",
                "Giradelli",
                "Lindt"
            };
            return CandyManufacturers;
        }

        internal void SetCandyManufacturer(string candyManuf)
        {
            tempManufacturer = candyManuf;
        }

        internal IList<string> GetFlavorCategories()
        {
            IList<string> FlavorCategories = new List<string>()
            {
                "Sour",
                "Sweet",
                "Rich",
                "Nutty",
                "Fruity",
                "Hot"
            };
            return FlavorCategories;
        }

        internal void SetCandyFlavorCategory(string candyFlavorCategory)
        {
            tempFlavorCategory = candyFlavorCategory;
        }

        internal void SetCandyAcquisitionDate(string savedDate)
        {
            tempDateReceived = DateTime.Parse(savedDate);
        }

        internal void SaveNewCandy(ConsoleKey key, string requestType)
        {
            int keyAsInt = (int)key;
            if (requestType == "CandyType")
            {
                switch (keyAsInt)
                {
                    case 97:
                        SetCandyType("Hard Candy");
                        break;
                    case 98:
                        SetCandyType("Taffy");
                        break;
                    case 99:
                        SetCandyType("Jelly Bean");
                        break;
                    case 100:
                        SetCandyType("Chocolate");
                        break;
                    default:
                        SetCandyNames("ERROR");
                        break;
                }
            }
            else if (requestType == "CandyName")
            {
                switch (keyAsInt)
                {
                    case 97:
                        SetCandyNames("Sour/Sweet");
                        break;
                    case 98:
                        SetCandyNames("Caramel Flavored");
                        break;
                    case 99:
                        SetCandyNames("Saltwater");
                        break;
                    case 100:
                        SetCandyNames("Flavored");
                        break;
                    case 101:
                        SetCandyNames("Choclate Bars");
                        break;
                    case 102:
                        SetCandyNames("Truffles");
                        break;
                    default:
                        SetCandyNames("ERROR");
                        break;
                }
            }
            else if (requestType == "CandyManuf")
            {
                switch (keyAsInt)
                {
                    case 97:
                        SetCandyManufacturer("Jolly Ranchers");
                        break;
                    case 98:
                        SetCandyManufacturer("Werther's");
                        break;
                    case 99:
                        SetCandyManufacturer("Laffy Taffy");
                        break;
                    case 100:
                        SetCandyManufacturer("Starburst");
                        break;
                    case 101:
                        SetCandyManufacturer("Giradelli");
                        break;
                    case 102:
                        SetCandyManufacturer("Lindt");
                        break;
                    default:
                        SetCandyNames("ERROR");
                        break;
                }
            }
            else if (requestType == "CandyFlavor")
            {
                switch (keyAsInt)
                {
                    case 97:
                        SetCandyFlavorCategory("Sour");
                        break;
                    case 98:
                        SetCandyFlavorCategory("Sweet");
                        break;
                    case 99:
                        SetCandyFlavorCategory("Rich");
                        break;
                    case 100:
                        SetCandyFlavorCategory("Nutty");
                        break;
                    case 101:
                        SetCandyFlavorCategory("Fruity");
                        break;
                    case 102:
                        SetCandyFlavorCategory("Hot");
                        break;
                    default:
                        SetCandyNames("ERROR");
                        break;
                }
            };
        }

        internal void PersistNewCandyObject()
        {
            _candies.Add(new Candy()
            {
                Name = tempCandyName,
                CandyType = tempCandyType,
                Manufacturer = tempManufacturer,
                FlavorCategory = tempFlavorCategory,
                DateReceived = tempDateReceived,
            });
        }

        public List<Candy> ReturnCandyInventory()
        {
            return _candies;
        }
    }
}