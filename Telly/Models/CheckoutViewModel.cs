using System.ComponentModel.DataAnnotations;

namespace Telly.Models
{
    public class CheckoutViewModel
    {
        [Required(ErrorMessage = "Full Name is required.")]
        [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters.")]
        public string FullName { get; set; } = null!;

        [Required(ErrorMessage = "Delivery Address is required.")]
        [StringLength(200, ErrorMessage = "Address cannot exceed 200 characters.")]
        public string Address { get; set; } = null!;

        [Required(ErrorMessage = "Card Number is required.")]
        [CreditCard(ErrorMessage = "Please enter a valid credit card number.")]
        public string CardNumber { get; set; } = null!;

        [Required(ErrorMessage = "Expiry Date is required.")]
        [RegularExpression(@"^(0[1-9]|1[0-2])\/?([0-9]{2})$", ErrorMessage = "Format must be MM/YY.")]
        public string ExpiryDate { get; set; } = null!;

        [Required(ErrorMessage = "CVV is required.")]
        [RegularExpression(@"^\d{3,4}$", ErrorMessage = "CVV must be 3 or 4 digits.")]
        public string Cvv { get; set; } = null!;

        // Holds the serialized JSON string of cart items from client localStorage
        public string? CartJson { get; set; }
    }
}