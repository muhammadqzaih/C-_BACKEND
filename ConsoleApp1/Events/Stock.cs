namespace ConsoleApp1.Events;

public delegate void StockPriceChangeHandler(Stock stock, decimal oldPrice);

public class Stock
{
    private string name;
    private decimal price;
    public event StockPriceChangeHandler onPriceChanged;
    public string Name => this.name;

    public decimal Price
    {
        get => this.price;
        set => this.price = value;  
    }

    public Stock(string stockName)
    {
        this.name = stockName;
    }

    public void ChangeStockByPrice(decimal percentage)
    {
        this.price += Math.Round(this.price * percentage, 2);
        if (onPriceChanged != null)
        {
            onPriceChanged(this, this.price);
        }
    }
}