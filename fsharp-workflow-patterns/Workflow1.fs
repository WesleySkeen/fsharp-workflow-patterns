namespace fsharp_workflow_patterns

module Workflow1 =
    
    let shouldContinueWorkflow (input: int) = input <> 8
        
    let executeWorkflow =
        // Inputs for the workflow to iterate over
        let inputs = [1; 2; 3; 4; 5; 6; 7; 8; 9; 10]
        // Setting up the default flag to use to check if we should continue the workflow
        let shouldExecuteCurrentStep = true
        
        inputs
            |> Seq.fold (fun (shouldExecuteCurrentStep: bool) (x: int) ->
                // Check if we should continue the workflow
                match shouldExecuteCurrentStep with
                | true ->
                    // using the current input, check if we should continue the workflow
                    let shouldContinue = x |> shouldContinueWorkflow
                                             
                    match shouldContinue with
                    | true ->
                        printfn $"Continuing from input is {x}"
                    | false ->
                        printfn $"Should not continue as input is {x}"
                    // set state
                    shouldContinue
                | false -> 
                    // set state
                    false
            ) shouldExecuteCurrentStep
