using System;
using System.Collections.Generic;
using System.Linq;

namespace Telly.Models
{
    public partial class Tvaccessory
    {
        public int AccessoryId { get; set; }
        public string AccessoryName { get; set; } = null!;
        public double? AccessoryLength { get; set; }
        public string? AccessoryImage { get; set; }
        public string? BatteryType { get; set; }
        public int? BrandId { get; set; }
        public virtual Brand? Brand { get; set; }

        // Code-based computed Price (Safe for EF Core: has no setter, so it never looks for a 'price' column in SQL)
        public double Price
        {
            get
            {
                string name = AccessoryName?.ToLower() ?? "";
                if (name.Contains("hdmi")) return 15.00;
                if (name.Contains("remote")) return 25.00;
                if (name.Contains("bracket") || name.Contains("mount")) return 45.00;
                if (name.Contains("cable")) return 12.00;
                return 20.00; // Default fallback price
            }
        }

        // Helper property to get images as a List<string> for your foreach loop
        public List<string> ImageList
        {
            get
            {
                if (string.IsNullOrWhiteSpace(AccessoryImage))
                {
                    string guessedFile = (AccessoryName?.ToLower().Trim() ?? "hdmi") + ".jpg";
                    return new List<string> { Uri.EscapeDataString(guessedFile) };
                }

                return AccessoryImage.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                                     .Select(img => Uri.EscapeDataString(img.Trim()))
                                     .ToList();
            }
        }
    }
}