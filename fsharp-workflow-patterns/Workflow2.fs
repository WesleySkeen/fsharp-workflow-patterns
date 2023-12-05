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
                        let result = request |> externalService.CanExecute
                                                        
                        match result.CanExecute with
                        | true -> externalService.Execute request
                        | false -> printfn $"Skipping {externalService.GetType().Name}"
                                                
                        result.ShouldContinue
                    | false -> false
                ) shouldExecuteCurrentStep`
