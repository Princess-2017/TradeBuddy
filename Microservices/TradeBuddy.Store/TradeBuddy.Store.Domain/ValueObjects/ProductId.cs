public class ProductId
{
    public Guid Value { get; }

    // سازنده بدون پارامتر برای EF Core
    private ProductId() { }

    public ProductId(Guid value)
    {
        Value = value;
    }

    public override bool Equals(object obj)
    {
        return obj is ProductId other && Value.Equals(other.Value);
    }

    public override int GetHashCode()
    {
        return Value.GetHashCode();
    }
}
