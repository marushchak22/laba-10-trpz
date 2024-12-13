using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
	public class BrandType
	{
		[Key]
		public int BrandTypeID { get; set; }

		[Required(ErrorMessage = "Оберіть тип велосипеду")]
		public int BicycleTypeID { get; set; }

		[Required(ErrorMessage = "Назва марки є обов'язковою")]
		public string BrandName { get; set; }

		[Required(ErrorMessage = "Країна є обов'язковою")]
		public string Country { get; set; }

		public virtual BicycleType? BicycleType { get; set; }
	}
}
