using System;
using System.ComponentModel.DataAnnotations;

namespace MarketList.Models
{
    public class MarketListItem
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int Quantity { get; set; }
        public bool isBought { get; set; }
    }
}
