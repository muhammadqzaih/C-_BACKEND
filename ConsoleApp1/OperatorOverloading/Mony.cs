namespace ConsoleApp1.OperatorOverloading;

public class Money
{
    private int amount;

    public int Amount
    {
        get => amount;
        set => amount = value;
    }

    public Money(int amount)
    {
        this.amount = amount;
    }

    public static Money operator +(Money mony1, Money mony2)
    {
        return new Money(mony2.Amount + mony1.Amount);
    }

    public static Money operator -(Money mony1, Money mony2)
    {
        return new Money(mony2.Amount - mony1.Amount);
    }

    public static bool operator >(Money mony1, Money mony2)
    {
        return mony2.Amount > mony1.Amount;
    }

    public static bool operator <(Money mony1, Money mony2)
    {
        return mony2.Amount > mony1.Amount;
    }

    public static bool operator >=(Money mony1, Money mony2)
    {
        return mony2.Amount >= mony1.Amount;
    }
    
    public static bool operator <=(Money mony1, Money mony2)
    {
        return mony2.Amount <= mony1.Amount;
    }
    // ... all thinks all operators 
}