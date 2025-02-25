//namespace SmartEnum;

////public enum CreditCard
////{
////    Standard = 1,
////    Premium = 2,
////    Platinum = 3
////}


//public abstract class CreditCard : Enumeration<CreditCard>
//{
//    //public static readonly CreditCard Standard = new(1, nameof(Standard));
//    public static readonly CreditCard Standard = new StandardCreditCard();

//    public static readonly CreditCard Premium = new PremiumCreditCard();

//    public static readonly CreditCard Platinum = new PlatinumCreditCard();
//    private CreditCard(int value, string name)
//        : base(value, name)
//    {
//    }

//    public abstract double Discount { get; }

//    private sealed class StandardCreditCard : CreditCard
//    {
//        public StandardCreditCard()
//            : base(1, nameof(StandardCreditCard))
//        { }
//        public override double Discount => 0.01;
//    }
//    private sealed class PremiumCreditCard : CreditCard
//    {
//        public PremiumCreditCard()
//            : base(2, nameof(PremiumCreditCard))
//        { }
//        public override double Discount => 0.05;
//    }
//    private sealed class PlatinumCreditCard : CreditCard
//    {
//        public PlatinumCreditCard()
//            : base(3, nameof(PlatinumCreditCard))
//        { }
//        public override double Discount => 0.1;
//    }
//}

using SmartEnum;

public abstract class CreditCard : Enumeration<CreditCard>
{
    public static readonly CreditCard Standard = new StandardCreditCard();
    public static readonly CreditCard Premium = new PremiumCreditCard();
    public static readonly CreditCard Platinum = new PlatinumCreditCard();

    private CreditCard(int value, string name)
        : base(value, name)
    { }

    public abstract double Discount { get; }

    private sealed class StandardCreditCard : CreditCard
    {
        public StandardCreditCard()
            : base(1, nameof(StandardCreditCard))
        { }

        public override double Discount => 0.01; // 1% Discount
    }

    private sealed class PremiumCreditCard : CreditCard
    {
        public PremiumCreditCard()
            : base(2, nameof(PremiumCreditCard))
        { }

        public override double Discount => 0.05; // 5% Discount
    }

    private sealed class PlatinumCreditCard : CreditCard
    {
        public PlatinumCreditCard()
            : base(3, nameof(PlatinumCreditCard))
        { }

        public override double Discount => 0.1; // 10% Discount
    }
}
