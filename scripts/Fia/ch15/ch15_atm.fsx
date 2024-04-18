// -------------------------------------------
// 1. ATM simple application (architecture) - OOP
// -------------------------------------------


type Customer = {
  Name: string;
  Balance: decimal;
}

let describeCustomer customer =
  printfn $"Welcome, {customer.Name}!"
  if customer.Balance < 0M then
    printfn $"You owe ${System.Math.Abs customer.Balance} to bank"
  else
    printfn $"You have a positive balance of {customer.Balance}"
    
describeCustomer { Name = "Tony"
                   Balance = 20M }

// -------------------------------------------
// 1.1. OOP
// -------------------------------------------
  
module Printers =
  
  type IPrinter =
    abstract Print: string -> unit
  let toConsole = { new IPrinter with
                      override _.Print(text) = printfn $"{text}" }
  let toFile filename = { new IPrinter with
                 override _.Print(text) = System.IO.File.AppendAllText(filename, text) }
  
  type ATM (customer: Customer) =
    member this.DescribeCustomer (printer: IPrinter) =
      printer.Print $"Welcome, {customer.Name}"
      if customer.Balance < 0M then
        printer.Print $"You owe {System.Math.Abs customer.Balance} to the bank"
      else
        printer.Print $"You have a positive balance of {customer.Balance}"

//-------------------------------------------
// 1.2. OOP - usage
//-------------------------------------------
open Printers

let main =
  let customer = { Name = "Tony"
                   Balance = 10M }
  ATM(customer).DescribeCustomer toConsole

// -------------------------------------------
// 2. ATM simple application (architecture) - FP
// -------------------------------------------

module BusinessFp = 
  let describeCustomerFp printer customer =
    printer $"Welcome, {customer.Name}!"
    if customer.Balance < 0M then
      printer $"You owe ${System.Math.Abs customer.Balance} to bank"
    else
      printer $"You have a positive balance of {customer.Balance}"

module PrintersFp =
  let toConsoleFp text = printfn $"{text}"
  let toFileFp filename text =
    System.IO.File.AppendAllText(filename, text)

open BusinessFp
open PrintersFp
let mainFp =
  let customer = { Name = "Tony"
                   Balance = 4000M }
  customer
    |> describeCustomerFp toConsoleFp
  customer
    |> describeCustomerFp (toFileFp "/Users/tony/developer/github/dotnet/Tma/scripts/Fia/ch15/customer.txt")
  
