namespace e_Bazaar.Client.ViewModels
{
    public class Discount
    {
        public int Id { get; set; }
        public int Percentage { get; set; }
        public double Amount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public int ProductId { get; set; }
    }
}
