using System.ComponentModel.DataAnnotations;

namespace ApiProduct.Application.Dto.Product.Request.Add
{
    public class AddProductRequestDto
    {
        [Required]
        public string Name { get;  set; }

        [Required]
        public string StatusName { get;  set; }

        [Range(0, int.MaxValue)]
        public int Stock { get;  set; }

        [Required]
        public string Descripcion { get;  set; }

        [Required]
        public decimal Price { get;  set; }
    }
}
