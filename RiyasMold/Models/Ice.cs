using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace RiyasMold.Models
{
    public class Ice
    {
        public int Id { get; set; } //this is primary key
        [StringLength(50, MinimumLength = 4)]
        [Required]
        public string Type { get; set; } // type means single or double
        [StringLength(50, MinimumLength = 4)]
        [Required]
        public string Size { get; set; }  // size means small , medium ,large
        [Range(1, 20)]
        public int Grids { get; set; }  // grid means how many ice grids
        [StringLength(50, MinimumLength = 4)]
        [Required]
        public string Color { get; set; } // to define the color available
        [StringLength(50, MinimumLength = 4)]
        [Required]
        public string Shape { get; set; } // in which shape it is
        [Range(1, 100)]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; } // price of the tray
        [StringLength(50, MinimumLength = 4)]
        [Required]
        public string Material { get; set; } // the material of ice tray

        [Range(1, 5)]
        public int Ratings { get; set; } // the ratings given by the costumers to product on sacle of 1 to 5 which is defined in range here 

    }
}
