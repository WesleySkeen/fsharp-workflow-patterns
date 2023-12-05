module Workflow2Models

    type ExternalServiceRequest =
        { EmailAddress: string
          PhoneNumber: string
          PostCode: string }
    
    type ExternalServiceCanExecuteResult =
        { CanExecute: bool
          ShouldContinue: bool } 
    
    type IExternalService =
        abstract member CanExecute : ExternalServiceRequest -> ExternalServiceCanExecuteResult
        abstract member Execute : ExternalServiceRequest -> unit
    
    let serviceA = {
        new IExternalService with                             
            member _.CanExecute request: ExternalServiceCanExecuteResult =
                  match
                      request.EmailAddress.Length > 0,
                      request.PhoneNumber.Length > 0,
                      request.PostCode.Length > 0 with                 
                  | true, true, true -> { CanExecute = true; ShouldContinue =  false }
                  | _, _, _ -> { CanExecute = false; ShouldContinue =  true }
            
            member _.Execute request = printfn "Executing service A"
    }
    
    let serviceB = {
        new IExternalService with                             
            member _.CanExecute request: ExternalServiceCanExecuteResult =
                  match request.PostCode.Length > 0 with
                  | true -> { CanExecute = true; ShouldContinue =  true }
                  | false -> { CanExecute = false; ShouldContinue =  true }                  
            
            member _.Execute request = printfn "Executing service B"
    }
    
    let serviceC = {
        new IExternalService with                             
            member _.CanExecute request: ExternalServiceCanExecuteResult =
                  match request.EmailAddress.Length > 0 with                 
                  | true -> { CanExecute = true; ShouldContinue =  true }
                  | false -> { CanExecute = false; ShouldContinue =  true }
            
            member _.Execute request = printfn "Executing service C"
    }
    
    let serviceD = {
        new IExternalService with                             
            member _.CanExecute request: ExternalServiceCanExecuteResult =
                  match request.PhoneNumber.Length > 0 with                 
                  | true -> { CanExecute = true; ShouldContinue =  true }
                  | false -> { CanExecute = false; ShouldContinue =  true }
            
            member _.Execute request = printfn "Executing service D"
    }        
