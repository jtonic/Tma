open Expecto

let tests =
    test "TMA simple test" {
        let subject = "subject"
        Expect.equal "subject" subject "They should be equal"
    }

[<EntryPoint>]
let main argv = runTestsWithCLIArgs [] argv tests
