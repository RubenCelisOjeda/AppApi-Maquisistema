using System.ComponentModel.DataAnnotations;

namespace ApiProduct.Application.Dto.Product.Request.Update
{
    public class UpdateProductRequestDto
    {
        [Required]
        public int ProductId { get; private set; }

        [Required]
        public string Name { get; private set; }

        [Required]
        public string StatusName { get; private set; }

        [Range(0,int.MaxValue)]
        public int Stock { get; private set; }

        [Required]
        public string Descripcion { get; private set; }

        [Required]
        public decimal Price { get; private set; }
    }
}
