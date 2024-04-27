module Model =
    type Currency = EUR | USD | MXN                                                                                     // sum ADT (Enums in Java, discriminated union
    type Amount = Amount of decimal                                                                                     // value class (fsharp notion: single-case discriminated union)
    type CurrencyAmount = { amount: Amount; currency: Currency } with                                                   // product ADT (record type) with members (just to show what is possible)
        static member withCurrency currency amount = { amount = amount; currency = currency }

module Core =
    open Model; open System
    
    let convert toCurrency { amount = (Amount amount); currency = fromCurrency } =                                      // pattern match in signature's param (DON'T ABUSE IT)
        let computedAmount = match fromCurrency, toCurrency with                                                        // applied pattern match with exhaustive cases (compiler enforces it)
                                | EUR, MXN -> Amount(amount * 1.2M)
                                | MXN, EUR -> Amount(amount / 1.2M)
                                
                                | EUR, USD -> Amount(amount * 1.1M)
                                | USD, EUR -> Amount(amount / 1.1M)
                                
                                | USD, MXN -> Amount(amount * 1.1M)
                                | MXN, USD -> Amount(amount / 1.1M)
                                
                                | a, b when a = b  -> Amount(amount)
                                | _ -> failwith "Invalid conversion"
        { amount = computedAmount; currency = toCurrency }

    let buy format currencyAmount =
        let formattedAmount = String.Format(format, currencyAmount.amount |> function Amount amount -> amount)
        printfn $"Buying something useful for %s{formattedAmount} %A{currencyAmount.currency} ..."        

module Util =
    open System; open Model
    
    let bankFormat = "{0:0,0.00}"
    
    let format pattern { amount = (Amount amount); currency = _ } =
        String.Format(pattern, amount)

// Usage
open Model; open Core;

(Amount 1000.0M)                                                                                                 // value class constructor  
    |> CurrencyAmount.withCurrency MXN                                                                                   
    |> convert EUR                                                                                        // partial application (currying), point-free style
    |> convert USD
    |> buy Util.bankFormat                                                                                              

(Amount 1000.0M)                                                                                                   
    |> fun amount -> { amount = amount; currency = MXN }                                                  // using lambda expression  
    |> convert EUR                                                                                        
    |> convert USD
    |> buy Util.bankFormat 
