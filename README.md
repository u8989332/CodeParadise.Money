# Money

This is a C# implementation of the Money pattern, as described in
[\[Fowler PoEAA\]](https://martinfowler.com/books/eaa.html):


This implementation is baesd on the content of PoEAA book. Some unit testings improve this module. The following is the features:

* [Constructors](#constructors)
* [Getting an amount](#getting-an-amount)
* [Getting a currency](#getting-a-currency)
* [Arithmetic Operations](#arithmetic-operations)
* [Comparison](#comparison)
* [Allocation](#allocation)
  * [Allocation According to Ratios](#allocation-according-to-ratios)
  * [Allocation to N Targets](#allocation-to-n-targets)
* [Currency](#currency)

## Constructors

```csharp
// Create TWD money with double amount
Money twd = new Money(500.5, Currency.TWD);

// Create JPY money with decimal amounto
Money jpy = new Money(200m, Currency.JPY);

// Create USD money with `Dollars` function
Money usd = Money.Dollars(100.25);

```

## Getting an amount

```csharp
Money usd = new Money(26.55, Currency.USD);
decimal amount = usd.Amount;
Console.WriteLine(amount); // 26.55
```

## Getting a currency

```csharp
Money usd = new Money(26.55, Currency.USD);
Currency currency = usd.Currency;
Console.WriteLine(currency.ToString()); // USD
```

## Arithmetic Operations

There are 4 arithmetic operators:

* `+(Money)`
* `-(Money)`
* `*(double or decimal)`
* `/(double or decimal)`

If two money objects have different currency and they use `+` or `-` operators, `ArgumentException` will be thrown.

```csharp
Money usd1 = new Money(20.0, Currency.USD);
Money usd2 = new Money(30.0, Currency.USD);
Money sum = usd1 + usd2;
Console.WriteLine(sum.Amount); // 50.0


Money usd3 = new Money(65.4, Currency.USD);
Money usd4 = new Money(11.1, Currency.USD);
Money diff = usd3 - usd4;
Console.WriteLine(diff.Amount); // 54.3
```

`+` and `-` provide explicit functions `Add` and `Subtract`:
 
```csharp
Money usd1 = new Money(20.0, Currency.USD);
Money usd2 = new Money(30.0, Currency.USD);
Money sum = usd1.Add(usd2);
Console.WriteLine(sum.Amount); // 50.0


Money usd3 = new Money(65.4, Currency.USD);
Money usd4 = new Money(11.1, Currency.USD);
Money diff = usd3.Subtract(usd4);
Console.WriteLine(diff.Amount); // 54.3
```

`*` or `/` can be used with double or decimal number

```csharp
Money usd1 = new Money(31.2, Currency.USD);
Money result1 = usd1 * 10.0;
Console.WriteLine(result1.Amount); // 312


Money usd2 = new Money(200.0, Currency.USD);
Money result2 = usd2 / 80.0;
Console.WriteLine(result2.Amount); // 2.5
```

`*` and `/` provide explicit functions `Multiply` and `Divide`:

```csharp
Money usd1 = new Money(31.2, Currency.USD);
Money result1 = usd1.Multiply(10.0);
Console.WriteLine(result1.Amount); // 312


Money usd2 = new Money(200.0, Currency.USD);
Money result2 = usd2.Divide(80.0);
Console.WriteLine(result2.Amount); // 2.5
```

## Comparison

Equality for operator `==` and function `Equals` is `true` when two money objects have the same currency and the same amount. 

```csharp
Money usd1 = new Money(30.0, Currency.USD);
Money usd2 = new Money(30.0, Currency.USD);
bool result1 = usd1 == usd2; // true;
bool result2 = usd1 != usd2; // false;

Money usd3 = new Money(40.0, Currency.USD);
bool result3 = usd1 == usd3; // false;
bool result4 = usd1 != usd3; // true

Money jpy1 = new Money(30.0, Currency.JPY);
bool result5 = usd1 == jpy1; // false
bool result5 = usd1 != jpy1; // true
```

`CompareTo` comapres two money objects. If they have different currency, `ArgumentException` will be thrown.

```csharp
Money usd1 = new Money(30.0, Currency.USD);
Money usd2 = new Money(40.0, Currency.USD);
Money usd3 = new Money(30.0, Currency.USD);

int result1 = usd1.CompareTo(usd2); // -1
int result2 = usd2.CompareTo(usd1); // 1
int result3 = usd1.CompareTo(usd3); // 0


Money jpy1 = new Money(30.0, Currency.JPY);
int result4 = usd1.CompareTo(jpy1); // throw ArgumentException
```

Comparison operators `>`, `>=`, `<` and `<=` are supported.

```csharp
Money usd1 = new Money(30.0, Currency.USD);
Money usd2 = new Money(40.0, Currency.USD);

bool result1 = usd1 < usd2; // true;
bool result2 = usd1 <= usd2; // true;
bool result3 = usd1 > usd2; // false;
bool result4 = usd1 >= usd2; // false;

```

## Allocation

### Allocation According to Ratios


```csharp
long[] allocation = {3, 7};
Money[] allocations = Money.Dollars(0.05).Allocate(allocation);

Assert.AreEqual(Money.Dollars(0.02), allocations[0]); // true
Assert.AreEqual(Money.Dollars(0.03), allocations[1]); // true
```

### Allocation to N Targets

This method allocates a sum of money into the same amount(almost) amongst N of target.

```csharp
Money[] allocations = Money.Dollars(2.51).Allocate(3);

Assert.AreEqual(3, allocations.Length);
Assert.AreEqual(Money.Dollars(0.84), allocations[0]);
Assert.AreEqual(Money.Dollars(0.84), allocations[1]);
Assert.AreEqual(Money.Dollars(0.83), allocations[2]);
```

## Currency

`Currency` is a `strcut` type. There are 91 kinds of country currency built in this type according to [MSDN - RegionInfo.ISOCurrencySymbol Property](https://docs.microsoft.com/en-us/dotnet/api/system.globalization.regioninfo.isocurrencysymbol?view=net-5.0)
`GetDefaultFractionDigits` function returns the number of digits of the specific currency. The number of digits is defined in [Wiki-ISO 4217](https://en.wikipedia.org/wiki/ISO_4217)

```csharp
Console.WriteLine(Currency.JPY); // JPY
Console.WriteLine(Currency.JPY.GetDefaultFractionDigits()); 0

Console.WriteLine(Currency.USD); // USD
Console.WriteLine(Currency.USD.GetDefaultFractionDigits()); 2
```


# Contact

LiJyu Gao - [Code Paradise](http://glj8989332.blogspot.com/) - b8989332@gmail.com


# Acknowledgements
* [Patterns of Enterprise Application Architecture Book(Amazon)](https://www.amazon.com/Patterns-Enterprise-Application-Architecture-Martin/dp/0321127420?&linkCode=ll1&tag=&linkId=cbd977b2fdd864da1d4d9ad1c5432151&language=zh_TW&ref_=as_li_ss_tl)
* [moneyphp/money](https://github.com/moneyphp/money)
* [LitGroup/money.dart](https://github.com/LitGroup/money.dart)
* [neuhalje/TimeAndMoney](https://github.com/neuhalje/TimeAndMoney)
* [neuhalje/TimeAndMoney](https://github.com/neuhalje/TimeAndMoney)
