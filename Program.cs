//using SmartEnum;

////var creditCard = CreditCard.Platinum;
//var creditCard = CreditCard.FromValue(3);

////var discount = creditCard switch
////{
////    CreditCard.Standard => 0.01,
////    CreditCard.Premium => 0.05,
////    CreditCard.Platinum => 0.1
////};

//Console.WriteLine($"Discount for {creditCard} is {creditCard.Discount:P}");

//Console.ReadKey();
// Example usage
var creditCard = CreditCard.FromValue(3); // Platinum Credit Card

Console.WriteLine($"Discount for {creditCard} is {creditCard.Discount:P}");

// You can also use FromName if you have a string representation of the card
var platinumCard = CreditCard.FromName("PlatinumCreditCard");
Console.WriteLine($"Discount for {platinumCard} is {platinumCard.Discount:P}");

Console.ReadKey();
