open System
open System.Collections.Generic
// ----------------- 1.1 -----------------
// model definition
// ---------------------------------------
module Domain =
    type Consultant = | Consultant of string
    type IncomingCall = {
        Id: int
        ClientId: int
        CallTime: DateTime
        AnswerTime: DateTime option
        EndTime: DateTime option
        Consultant: Consultant
    }
    type CallCenter = {
        mutable Counter: int
        Calls: Queue<IncomingCall>
    }
// ----------------- 1.2 -----------------
// behaviour definition
// ---------------------------------------
open Domain
module CallCenter =
    let call clientId consultant callCenter =
        callCenter.Counter <- callCenter.Counter + 1
        let newCall =
            { Id = callCenter.Counter
              ClientId = clientId
              CallTime = DateTime.Now
              AnswerTime = None
              EndTime = None
              Consultant  =  consultant }    
        callCenter.Calls.Enqueue newCall
        printfn $"Call from {clientId} at {newCall.CallTime} assigned to {consultant} with id {newCall.Id}"
        callCenter
    let areWaitingCalls callCenter =
        callCenter.Calls.Count > 0
    let answerCall consultant callCenter =
        let call = { callCenter.Calls.Dequeue() with AnswerTime = Some DateTime.Now; Consultant = consultant }
        printfn $"Answered call {call.Id} from {call.ClientId} answered by {consultant} at {call.AnswerTime}"
        call
    let endCall call =
        let endedCall = { call with EndTime = Some DateTime.Now }
        printfn $"Ended call %A{endedCall}"
// ----------------- 1.3 -----------------
// app
// ---------------------------------------
open CallCenter
let app =
    let callCenter = { Counter = 0; Calls = Queue() }
    let consultant = Consultant "Tony"
    
    let rec processCalls callCenter: Async<CallCenter> = async {
        if areWaitingCalls callCenter then
            let rand = Random()
            do! Async.Sleep (rand.Next (500, 1000))
            callCenter |> answerCall consultant |> endCall
            return! processCalls callCenter
        else
            return callCenter
        }
    
    callCenter
        |> call 1234 consultant
        |> call 5678 consultant
        |> call 1468 consultant
        |> call 9641 consultant
        |> processCalls
        |> Async.RunSynchronously
        |> ignore
