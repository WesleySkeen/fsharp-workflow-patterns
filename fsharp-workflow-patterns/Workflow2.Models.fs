module Workflow2Models

    type ExternalServiceRequest =
        { EmailAddress: string
          PhoneNumber: string }
    
    type ExternalServiceCanExecuteResult =
        { CanExecute: bool
          ShouldContinue: bool } 
    
    type IExternalService =
        abstract member CanExecute : ExternalServiceRequest -> ExternalServiceCanExecuteResult
        abstract member Execute : ExternalServiceRequest -> bool
    
    let serviceA = {
        new IExternalService with                             
            member _.CanExecute request: ExternalServiceCanExecuteResult =
                  match request.EmailAddress.Length > 0, request.PhoneNumber.Length > 0 with
                  | true, true -> { CanExecute = true; ShouldContinue =  false }
                  | true, false -> { CanExecute = false; ShouldContinue =  true }
                  | false, true -> { CanExecute = false; ShouldContinue =  true }
                  | false, false -> { CanExecute = false; ShouldContinue =  true }
            
            member _.Execute request : bool = true            
    }
    
    let serviceB = {
        new IExternalService with                             
            member _.CanExecute request: ExternalServiceCanExecuteResult =
                  match request.EmailAddress.Length > 0 with                 
                  | true -> { CanExecute = true; ShouldContinue =  true }
                  | false -> { CanExecute = false; ShouldContinue =  true }
            
            member _.Execute request : bool = true            
    }
    
    let serviceC = {
        new IExternalService with                             
            member _.CanExecute request: ExternalServiceCanExecuteResult =
                  match request.PhoneNumber.Length > 0 with                 
                  | true -> { CanExecute = true; ShouldContinue =  false }
                  | false -> { CanExecute = false; ShouldContinue =  true }
            
            member _.Execute request : bool = true            
    }
    
    let serviceD = {
        new IExternalService with                             
            member _.CanExecute request: ExternalServiceCanExecuteResult =
                  match request.EmailAddress.Length > 0, request.PhoneNumber.Length > 0 with                 
                  | false, false -> { CanExecute = true; ShouldContinue =  false }
                  | _, _ -> { CanExecute = false; ShouldContinue =  false }
            
            member _.Execute request : bool = true            
    }
