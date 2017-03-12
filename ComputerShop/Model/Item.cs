namespace ComputerShop.Model
{
    struct Item
    {
        public int productID;
        public int amount;

        public Item(int productID, int amount)
        {
            this.productID = productID;
            this.amount = amount;
        }
    }
}
