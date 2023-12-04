namespace fsharp_workflow_patterns

module Workflow1 =
    
    let shouldContinueWorkflow (input: int) = input <> 8
        
    let executeWorkflow =
        let inputs = [1; 2; 3; 4; 5; 6; 7; 8; 9; 10]
        let shouldExecuteCurrentStep = true
        
        inputs
            |> Seq.fold (fun (shouldExecuteCurrentStep: bool) (x: int) ->
                        
                        match shouldExecuteCurrentStep with
                        | true ->
                            let shouldContinue = x |> shouldContinueWorkflow
                                                            
                            match shouldContinue with
                            | true ->
                                printfn $"Continuing from input is {x}"
                            | false ->
                                printfn $"Should not continue as input is {x}"
                            
                            shouldContinue
                        | false -> false
            ) shouldExecuteCurrentStep