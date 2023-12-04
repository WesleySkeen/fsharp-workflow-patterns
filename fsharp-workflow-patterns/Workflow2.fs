namespace fsharp_workflow_patterns

open Workflow2Models

module Workflow2 =
    
        
    let externalServices: IExternalService seq =
        [
            serviceA
            serviceB
            serviceC
            serviceD
        ]
        
    let executeWorkflow
        (request: ExternalServiceRequest) =
            
            let shouldExecuteCurrentStep = true
            
            externalServices
                |> Seq.fold (fun (shouldExecuteCurrentStep: bool) (externalService: IExternalService) ->
                            
                            match shouldExecuteCurrentStep with
                            | true ->
                                let result = externalService.CanExecute request
                                                                
                                match result.CanExecute with
                                | true ->
                                    printfn $"Executing {externalService.ToString()}"
                                | false ->
                                    printfn $"Skipping {externalService.ToString()}"
                                
                                result.ShouldContinue
                            | false -> false
                ) shouldExecuteCurrentStep